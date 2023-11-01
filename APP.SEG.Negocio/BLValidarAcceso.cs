using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.SEG.Entidades;
using APP.SEG.AccesoDatos;
using System.Transactions;
using APP.SEG.Helper;

namespace APP.SEG.Negocio
{
    public class BLValidarAcceso
    {




        public BERespuestaAcceso ValidarAcceso(BEValidaAcceso beValidaAcceso)
        {
            DAUsuario daUsuario = new DAUsuario();
            DAAcceso daAcceso = new DAAcceso();
            BERespuestaAcceso respuestaAcceso = new BERespuestaAcceso();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beValidaAcceso.UsuarioServicio, beValidaAcceso.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                int idUsuarioRespuesta = -1;
                string codigoRespuesta = string.Empty;

                BEUsuario usuario = daUsuario.ObtenerUsuarioPorCodigo(beValidaAcceso.UsuarioLogueo);

                if (usuario != null)
                {
                    if (usuario.EstadoUsuario)
                    {
                        string claveDesencriptada = Encrypt.DesencriptarContrasenha(usuario.Password);

                        if (claveDesencriptada.Equals(beValidaAcceso.ClaveLogueo))
                        {
                            usuario = daAcceso.ValidarPermisoUsuario(usuario.IdUsuario, beValidaAcceso.IdAplicacion, beValidaAcceso.IdRol, 0);
                            int idRol = usuario.PermisoUsuario.BERol.IdRol;
                            if (usuario != null)
                            {
                                if (usuario.PasswordCaduca && usuario.FechaCaduca.Date < DateTime.Now.Date)
                                {
                                    respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_LOGUEO_CLAVE_EXPIRADA;
                                    InsertarAuditoriaUsuario(idUsuarioRespuesta, idUsuarioRespuesta, "Contraseña expirada", 2);
                                }
                                else
                                {
                                    if (usuario.CambiarPasswordEnInicio)
                                    {
                                        respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_LOGUEO_USUARIO_DEBE_CAMBIAR_CLAVE;
                                        InsertarAuditoriaUsuario(idUsuarioRespuesta, idUsuarioRespuesta, "Cambiar password en inicio", 2);
                                    }
                                    else
                                    {
                                        respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_LOGUEO_EXISTOSO;
                                        respuestaAcceso.BEUsuario = usuario;
                                        respuestaAcceso.BEUsuario.PermisoUsuario = new BEPermisoUsuario();
                                        respuestaAcceso.BEUsuario.PermisoUsuario.BERol = new BERol();
                                        respuestaAcceso.BEUsuario.PermisoUsuario.BERol.IdRol = idRol;

                                        InsertarAuditoriaUsuario(usuario.IdUsuario, usuario.IdUsuario, "Logueo Exitoso", 1);
                                    }
                                }
                            }
                            else
                            {
                                respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_LOGUEO_USUARIO_NO_TIENE_PERMISOS_APLICACION;
                                InsertarAuditoriaUsuario(idUsuarioRespuesta, idUsuarioRespuesta, "Usuario no tiene permisos para esta aplicación", 2);
                            }

                        }
                        else
                        {
                            respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_LOGUEO_CLAVE_ERRONEA;
                            InsertarAuditoriaUsuario(idUsuarioRespuesta, idUsuarioRespuesta, "Contraseña incorrecta", 2);
                        }
                    }
                    else
                    {
                        respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_LOGUEO_USUARIO_INACTIVO;
                        InsertarAuditoriaUsuario(idUsuarioRespuesta, idUsuarioRespuesta, "El usuario esta inactivo", 2);
                    }
                }
                else
                {
                    respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_LOGUEO_CLAVE_ERRONEA;
                }
            }
            else
            {
                respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
            }

            return respuestaAcceso;
        }

        private static void InsertarAuditoriaUsuario(int idUsuarioAfectado, int idUsuarioAfectador, string observacion, int tipoOperacion)
        {
            DAAcceso daAcceso = new DAAcceso();
            BEAuditoriaUsuario beAuditoriaUsuario = new BEAuditoriaUsuario();
            beAuditoriaUsuario.IdUsuarioAfectado = idUsuarioAfectado;
            beAuditoriaUsuario.IdUsuarioAfectador = idUsuarioAfectador;
            beAuditoriaUsuario.Observacion = observacion;
            beAuditoriaUsuario.IdTipoOperacion = tipoOperacion;
            daAcceso.InsertarAuditoriaUsuario(beAuditoriaUsuario);
        }

        public BERespuestaActualizaClave ActualizarClaveExpirada(BEActualizaClave beActualizaClave)
        {
            BERespuestaActualizaClave respuestaActualizaClave = new BERespuestaActualizaClave();
            DAAcceso daAcceso = new DAAcceso();
            DAUsuario daUsuario = new DAUsuario();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beActualizaClave.UsuarioServicio, beActualizaClave.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                if (ValidarPasswordValido(beActualizaClave.NuevaClave))
                {
                    BEUsuario usuario = daUsuario.ObtenerUsuarioPorCodigo(beActualizaClave.CodigoUsuario);
                    if (usuario != null && Encrypt.DesencriptarContrasenha(usuario.Password).Equals(beActualizaClave.ClaveAnterior))
                    {
                        bool claveValida = ValidarUltimas13Claves(usuario.IdUsuario, beActualizaClave.NuevaClave);

                        if (claveValida)
                        {
                            using (TransactionScope transaccion = new TransactionScope())
                            {
                                beActualizaClave.IdUsuario = usuario.IdUsuario;
                                beActualizaClave.NuevaClave = Encrypt.EncriptarContrasenha(beActualizaClave.NuevaClave);
                                daAcceso.ActualizarClave(beActualizaClave);

                                BEUsuarioClave beUsuarioClave = new BEUsuarioClave();
                                beUsuarioClave.IdUsuario = beActualizaClave.IdUsuario;
                                beUsuarioClave.ClaveRegistrada = beActualizaClave.NuevaClave;
                                beUsuarioClave.FechaRegistro = DateTime.Now;

                                daAcceso.InsertarUsuarioClave(beUsuarioClave);

                                usuario = daAcceso.ValidarPermisoUsuario(usuario.IdUsuario, beActualizaClave.IdAplicacion, beActualizaClave.IdRol, 0);
                                if (usuario != null)
                                {
                                    respuestaActualizaClave.BEUsuario = usuario;
                                }
                                transaccion.Complete();
                                respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_CLAVE_ACTUALIZADA_CORRECTAMENTE;
                            }
                        }
                        else
                        {
                            respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_CLAVE_REPETIDA_13_ULTIMAS;
                        }
                    }
                    else
                    {
                        respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_USUARIO_INVALIDO;
                    }

                }
                else
                {
                    respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS;
                }
            }
            else
            {
                respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
            }

            return respuestaActualizaClave;
        }

        public BERespuestaActualizaClave ActualizarClaveExpiradaWrapUp(BEActualizaClave beActualizaClave)
        {
            BERespuestaActualizaClave respuestaActualizaClave = new BERespuestaActualizaClave();
            DAAcceso daAcceso = new DAAcceso();
            DAUsuario daUsuario = new DAUsuario();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beActualizaClave.UsuarioServicio, beActualizaClave.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                BEUsuario usuario = daUsuario.ObtenerUsuarioPorCodigo(beActualizaClave.CodigoUsuario);
                if (usuario != null && Encrypt.DesencriptarContrasenha(usuario.Password).Equals(beActualizaClave.ClaveAnterior))
                {
                    bool claveValida = ValidarUltimas13Claves(usuario.IdUsuario, beActualizaClave.NuevaClave);

                    if (claveValida)
                    {
                        using (TransactionScope transaccion = new TransactionScope())
                        {
                            beActualizaClave.IdUsuario = usuario.IdUsuario;
                            beActualizaClave.NuevaClave = Encrypt.EncriptarContrasenha(beActualizaClave.NuevaClave);
                            daAcceso.ActualizarClave(beActualizaClave);

                            BEUsuarioClave beUsuarioClave = new BEUsuarioClave();
                            beUsuarioClave.IdUsuario = beActualizaClave.IdUsuario;
                            beUsuarioClave.ClaveRegistrada = beActualizaClave.NuevaClave;
                            beUsuarioClave.FechaRegistro = DateTime.Now;

                            daAcceso.InsertarUsuarioClave(beUsuarioClave);

                            usuario = daAcceso.ValidarPermisoUsuario(usuario.IdUsuario, beActualizaClave.IdAplicacion, beActualizaClave.IdRol, 0);
                            if (usuario != null)
                            {
                                respuestaActualizaClave.BEUsuario = usuario;
                            }
                            transaccion.Complete();
                            respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_CLAVE_ACTUALIZADA_CORRECTAMENTE;
                        }
                    }
                    else
                    {
                        respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_CLAVE_REPETIDA_13_ULTIMAS;
                    }
                }
                else
                {
                    respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_USUARIO_INVALIDO;
                }
            }
            else
            {
                respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
            }

            return respuestaActualizaClave;
        }

        private bool ValidarUltimas13Claves(int idUsuario, string nuevaClave)
        {
            bool claveValida = true;
            DAAcceso daAcceso = new DAAcceso();

            List<BEUsuarioClave> lista = daAcceso.ObtenerUltimas13Claves(idUsuario);
            foreach (BEUsuarioClave usuarioClave in lista)
            {
                if (Encrypt.DesencriptarContrasenha(usuarioClave.ClaveRegistrada).Equals(nuevaClave))
                {
                    claveValida = false;
                }

            }

            return claveValida;
        }


        public BERespuestaRol ListarRol(BEConsultaServicio beConsultaServicio)
        {
            BERespuestaRol respuestaRol = new BERespuestaRol();
            DAAcceso daAcceso = new DAAcceso();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beConsultaServicio.UsuarioServicio, beConsultaServicio.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                DARol daRol = new DARol();
                respuestaRol.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_EXITOSA_LISTA_ROLES;
                respuestaRol.ListaRoles = daRol.ListarRolesPorAplicacion(beConsultaServicio.IdAplicacion);
            }
            else
            {
                respuestaRol.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
                respuestaRol.ListaRoles = null;
            }
            return respuestaRol;
        }

        public BERespuestaPermisoObjeto ListarPermisoObjetoPorFormulario(BEConsultaServicio beConsultaServicio)
        {
            DAAcceso daAcceso = new DAAcceso();
            BERespuestaPermisoObjeto respuestaPermisoObjeto = new BERespuestaPermisoObjeto();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beConsultaServicio.UsuarioServicio, beConsultaServicio.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                respuestaPermisoObjeto.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_EXITOSA_LISTA_PERMISO_OBJETO;
                respuestaPermisoObjeto.ListaObjetos = daAcceso.ListarPermisoObjetoPorFormulario(beConsultaServicio);
            }
            else
            {
                respuestaPermisoObjeto.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
                respuestaPermisoObjeto.ListaObjetos = null;
            }

            return respuestaPermisoObjeto;
        }

        public BERespuestaPermisoObjeto ListarPermisoObjetoPorFormularioxUsuario(BEConsultaServicio beConsultaServicio)
        {
            DAAcceso daAcceso = new DAAcceso();
            BERespuestaPermisoObjeto respuestaPermisoObjeto = new BERespuestaPermisoObjeto();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beConsultaServicio.UsuarioServicio, beConsultaServicio.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                respuestaPermisoObjeto.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_EXITOSA_LISTA_PERMISO_OBJETO;
                respuestaPermisoObjeto.ListaObjetos = daAcceso.ListarPermisoObjetoPorFormularioxUsuario(beConsultaServicio);
            }
            else
            {
                respuestaPermisoObjeto.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
                respuestaPermisoObjeto.ListaObjetos = null;
            }

            return respuestaPermisoObjeto;
        }



        public BERespuestaPermisoObjeto ListarPermisoObjetoMenuOpciones(BEConsultaServicio beConsultaServicio)
        {
            DAAcceso daAcceso = new DAAcceso();
            BERespuestaPermisoObjeto respuestaPermisoObjeto = new BERespuestaPermisoObjeto();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beConsultaServicio.UsuarioServicio, beConsultaServicio.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                respuestaPermisoObjeto.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_EXITOSA_LISTA_PERMISO_OBJETO;
                respuestaPermisoObjeto.ListaObjetos = daAcceso.ListarPermisoObjetoMenuOpciones(beConsultaServicio);
            }
            else
            {
                respuestaPermisoObjeto.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
                respuestaPermisoObjeto.ListaObjetos = null;
            }

            return respuestaPermisoObjeto;
        }
        public BERespuestaPermisoObjeto ListarPermisoObjetoMenuOpcionesxUsuario(BEConsultaServicio beConsultaServicio)
        {
            DAAcceso daAcceso = new DAAcceso();
            BERespuestaPermisoObjeto respuestaPermisoObjeto = new BERespuestaPermisoObjeto();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beConsultaServicio.UsuarioServicio, beConsultaServicio.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                respuestaPermisoObjeto.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_EXITOSA_LISTA_PERMISO_OBJETO;
                respuestaPermisoObjeto.ListaObjetos = daAcceso.ListarPermisoObjetoMenuOpcionesxUsuario(beConsultaServicio);
            }
            else
            {
                respuestaPermisoObjeto.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
                respuestaPermisoObjeto.ListaObjetos = null;
            }

            return respuestaPermisoObjeto;
        }


        public BERespuestaActualizaClave CambiarClave(BEActualizaClave beActualizaClave)
        {
            BERespuestaActualizaClave respuestaActualizaClave = new BERespuestaActualizaClave();
            DAAcceso daAcceso = new DAAcceso();
            DAUsuario daUsuario = new DAUsuario();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beActualizaClave.UsuarioServicio, beActualizaClave.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                if (ValidarPasswordValido(beActualizaClave.NuevaClave))
                {

                    BEUsuario usuario = daUsuario.ObtenerUsuarioPorCodigo(beActualizaClave.CodigoUsuario);
                    if (usuario != null && Encrypt.DesencriptarContrasenha(usuario.Password).Equals(beActualizaClave.ClaveAnterior))
                    {
                        bool claveValida = ValidarUltimas13Claves(usuario.IdUsuario, beActualizaClave.NuevaClave);

                        if (claveValida)
                        {
                            using (TransactionScope transaccion = new TransactionScope())
                            {
                                beActualizaClave.IdUsuario = usuario.IdUsuario;
                                beActualizaClave.NuevaClave = Encrypt.EncriptarContrasenha(beActualizaClave.NuevaClave);

                                daAcceso.ActualizarClave(beActualizaClave);

                                BEUsuarioClave beUsuarioClave = new BEUsuarioClave();
                                beUsuarioClave.IdUsuario = beActualizaClave.IdUsuario;
                                beUsuarioClave.ClaveRegistrada = beActualizaClave.NuevaClave;
                                beUsuarioClave.FechaRegistro = DateTime.Now;

                                daAcceso.InsertarUsuarioClave(beUsuarioClave);

                                transaccion.Complete();
                                respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_CLAVE_ACTUALIZADA_CORRECTAMENTE;
                            }
                        }
                        else
                        {
                            respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_CLAVE_REPETIDA_13_ULTIMAS;
                        }
                    }
                    else
                    {
                        respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_USUARIO_INVALIDO;
                    }
                }
                else
                {
                    respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS;
                }
            }
            else
            {
                respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
            }

            return respuestaActualizaClave;
        }

        public BERespuestaActualizaClave CambiarClaveWrapUp(BEActualizaClave beActualizaClave)
        {
            BERespuestaActualizaClave respuestaActualizaClave = new BERespuestaActualizaClave();
            DAAcceso daAcceso = new DAAcceso();
            DAUsuario daUsuario = new DAUsuario();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beActualizaClave.UsuarioServicio, beActualizaClave.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                BEUsuario usuario = daUsuario.ObtenerUsuarioPorCodigo(beActualizaClave.CodigoUsuario);
                if (usuario != null && Encrypt.DesencriptarContrasenha(usuario.Password).Equals(beActualizaClave.ClaveAnterior))
                {
                    bool claveValida = ValidarUltimas13Claves(usuario.IdUsuario, beActualizaClave.NuevaClave);

                    if (claveValida)
                    {
                        using (TransactionScope transaccion = new TransactionScope())
                        {
                            beActualizaClave.IdUsuario = usuario.IdUsuario;
                            beActualizaClave.NuevaClave = Encrypt.EncriptarContrasenha(beActualizaClave.NuevaClave);

                            daAcceso.ActualizarClave(beActualizaClave);

                            BEUsuarioClave beUsuarioClave = new BEUsuarioClave();
                            beUsuarioClave.IdUsuario = beActualizaClave.IdUsuario;
                            beUsuarioClave.ClaveRegistrada = beActualizaClave.NuevaClave;
                            beUsuarioClave.FechaRegistro = DateTime.Now;

                            daAcceso.InsertarUsuarioClave(beUsuarioClave);

                            transaccion.Complete();
                            respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_CLAVE_ACTUALIZADA_CORRECTAMENTE;
                        }
                    }
                    else
                    {
                        respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_CLAVE_REPETIDA_13_ULTIMAS;
                    }
                }
                else
                {
                    respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_USUARIO_INVALIDO;
                }
            }
            else
            {
                respuestaActualizaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
            }

            return respuestaActualizaClave;
        }

        public bool ValidarPasswordValido(string nuevoPassword)
        {
            bool valido = false;
            string expresionRegular = "^(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9{CARACTERES_ESPECIALES}]*$|^(?=.{8,})(?=.*\\d)(?=.*[A-Z])(?=.*[{CARACTERES_ESPECIALES}])[a-zA-Z0-9{CARACTERES_ESPECIALES}]*$|^(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[{CARACTERES_ESPECIALES}])[a-zA-Z0-9{CARACTERES_ESPECIALES}]*$|^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[{CARACTERES_ESPECIALES}])[a-zA-Z0-9{CARACTERES_ESPECIALES}]*$";
            expresionRegular = expresionRegular.Replace("{CARACTERES_ESPECIALES}", Constantes.CLAVE_SIMBOLOS_ESPECIALES);
            if (System.Text.RegularExpressions.Regex.IsMatch(nuevoPassword, expresionRegular))
            {
                valido = true;
            }
            return valido;
        }

        public BERespuestaEncriptaClave EncriptarPassword(BEEncriptaClave beEncriptaClave)
        {
            string passwordEncriptado = string.Empty;

            DAAcceso daAcceso = new DAAcceso();
            BERespuestaAcceso respuestaAcceso = new BERespuestaAcceso();
            BERespuestaEncriptaClave beRespuestaEncriptaClave = new BERespuestaEncriptaClave();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beEncriptaClave.UsuarioServicio, beEncriptaClave.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                passwordEncriptado = Encrypt.EncriptarContrasenha(beEncriptaClave.PasswordDesencriptado);
                beRespuestaEncriptaClave.Clave = passwordEncriptado;
                beRespuestaEncriptaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_ENCRIPTACION_EXITOSA;
            }
            else
            {
                respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
            }


            return beRespuestaEncriptaClave;
        }

        public BERespuestaEncriptaClave DesencriptarPassword(BEEncriptaClave beEncriptaClave)
        {
            string passwordDesencriptado = string.Empty;

            DAAcceso daAcceso = new DAAcceso();
            BERespuestaAcceso respuestaAcceso = new BERespuestaAcceso();
            BERespuestaEncriptaClave beRespuestaEncriptaClave = new BERespuestaEncriptaClave();

            bool accesoServicioValido = daAcceso.VerificarAccesoServicioWeb(beEncriptaClave.UsuarioServicio, beEncriptaClave.ClaveUsuarioServicio);

            if (accesoServicioValido)
            {
                passwordDesencriptado = Encrypt.DesencriptarContrasenha(beEncriptaClave.PasswordEncriptado);
                beRespuestaEncriptaClave.Clave = passwordDesencriptado;
                beRespuestaEncriptaClave.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_DESENCRIPTACION_EXITOSA;
            }
            else
            {
                respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB;
            }


            return beRespuestaEncriptaClave;
        }
    }
}
