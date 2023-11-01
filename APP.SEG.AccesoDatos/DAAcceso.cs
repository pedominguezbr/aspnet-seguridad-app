using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using APP.SEG.Entidades;
using System.Data;

namespace APP.SEG.AccesoDatos
{
    public class DAAcceso
    {
        #region Constantes


        private const string INT_ID_USUARIO = "IntIdusuario";
        private const string BIT_REQUIERE_PASSWORD = "BitRequierepassword";
        private const string VCH_PASSWORD = "VchPassword";
        private const string BIT_PASSWORD_CADUCA = "BitPasswordcaduca";
        private const string DTM_FECHA_CADUCA = "DtmFechacaduca";
        private const string BIT_CAMBIAR_PASSWORD_EN_S_INICIO = "BitCambiarpasswordensinicio";

        private const string UP_USUARIO_ACTUALIZAR_PASSWORD = "up_Usuario_Actualizar_Password";
        private const string UP_USUARIOCLAVE_VALIDAR_ANTERIORES = "up_Usuarioclave_Validar_Anteriores";
        private const string UP_USUARIOCLAVE_INSERTAR = "up_Usuarioclave_Insertar";
        private const string UP_APLICACIONSERVICIOWEB_VALIDARACCESOSERVICIOWEB = "up_Aplicacionservicioweb_ValidarAccesoServicioWeb";
        private const string UP_PERMISOOBJETO_LISTAR_ACCESO = "up_PermisoObjeto_Listar_Acceso";
        private const string UP_PERMISOOBJETO_LISTAR_ACCESO_USUARIO = "up_PermisoObjeto_Listar_AccesoxUsuario";


        private const string VCH_CLAVE_REGISTRADA = "VchClaveregistrada";
        private const string CLAVE_INVALIDA = "CLAVE_INVALIDA";

        private const string INT_ID_CLAVE = "IntIdclave";
        private const string DTM_FECHA_REGISTRO = "DtmFecharegistro";
        private const string BIT_ESTADO_CLAVE = "BitEstadoclave";

        private const string VCH_USUARIO_SERVICIO_WEB = "VchUsuarioservicioweb";
        private const string VCH_CLAVE_USUARIO_SERVICIO_WEB = "VchClaveusuarioservicioweb";

        private const string INT_ID_ROL = "IntIdRol";
        private const string INT_ID_APLICACION = "IntIdAplicacion";

        private const string ID_OBJETO = "IdObjeto";
        private const string NOMBRE_FISICO_OBJETO = "NombreFisicoObjeto";
        private const string DESCRIPCION_OBJETO = "DescripcionObjeto";
        private const string ETIQUETA_OBJETO = "EtiquetaObjeto";
        private const string ID_TIPO_OBJETO = "IdTipoObjeto";
        private const string URL_OBJETO = "UrlObjeto";
        private const string ID_OBJETO_PADRE = "IdObjetoPadre";
        private const string ID_APLICACION = "IdAplicacion";
        private const string ESTADO_OBJETO = "EstadoObjeto";
        private const string ESTADO_PERMISO_OBJETO = "EstadoPermisoObjeto";
        private const string VCH_NOMBRE_FORMULARIO = "VchNombreFormulario";

        private const string VCH_CODIGO_USUARIO = "VchCodigousuario";
        private const string VCH_PASSWORD_VALIDA = "VchPasswordValida";
        private const string INT_CODIGO_MENSAJE = "IntCodigoMensaje";

        private const string CODIGO_USUARIO = "CodigoUsuario";
        private const string PASSWORD = "Password";
        private const string ID_USUARIO = "IdUsuario";
        private const string REQUIERE_PASSWORD = "RequierePassword";
        private const string PASSWORD_CADUCA = "PasswordCaduca";
        private const string FECHA_CADUCA = "FechaCaduca";
        private const string CAMBIAR_PASSWORD_EN_S_INICIO = "CambiarPasswordEnSInicio";

        private const string UP_USUARIO_LISTAR_ACCESO = "up_Usuario_Listar_Acceso";

        private const string INT_ID_AREA = "IntIdArea";

        private const string NOMBRES = "Nombres";
        private const string APELLIDO_PATERNO = "ApellidoPaterno";
        private const string APELLIDO_MATERNO = "ApellidoMaterno";
        private const string ID_TIPO_USUARIO = "IdTipoUsuario";
        private const string ID_AREA = "IdArea";
        private const string ID_OFICINA = "IdOficina";
        private const string FECHA_CREACION = "FechaCreacion";
        private const string ID_USUARIO_CREACION = "IdUsuarioCreacion";
        private const string ESTADO_USUARIO = "EstadoUsuario";
        private const string PAGO_TERCERO = "PagoTercero";
        private const string ID_ROL = "IdRol";

        private const string UP_AUDITORIAUSUARIO_INSERTAR = "up_Auditoriausuario_Insertar";
        private const string INT_ID_USUARIO_AFECTADO = "IntIdusuarioafectado";
        private const string INT_ID_USUARIO_AFECTADOR = "IntIdusuarioafectador";
        private const string INT_ID_TIPO_OPERACION = "IntIdtipooperacion";
        private const string VCH_OBSERVACION = "VchObservacion";

        private const string UP_PERMISOOBJETO_LISTAR_MENU_ACCESO = "up_PermisoObjeto_Listar_Menu_Acceso";
        private const string CLAVEREGISTRADA = "CLAVEREGISTRADA";
        private const string UP_PERMISOOBJETO_LISTAR_MENU_ACCESOXUSUARIO = "up_PermisoObjeto_Listar_Menu_AccesoxUsuario";

        #endregion

        #region Variables
        private Database db;
        #endregion

        #region Constructor
        public DAAcceso()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }
        #endregion

        #region Metodos



        //public List<BERol> ListarRol(BEConsultaServicio beConsultaServicio)
        //{
        //    List<BERol> listaRol = new List<BERol>();
        //    return listaRol;
        //}

        public List<BEObjeto> ListarPermisoObjetoPorFormulario(BEConsultaServicio beValidaPermisoObjeto)
        {
            List<BEObjeto> listaBeObjeto;

            DbCommand cmd = db.GetStoredProcCommand(UP_PERMISOOBJETO_LISTAR_ACCESO);
            db.AddInParameter(cmd, INT_ID_ROL, DbType.Int32, beValidaPermisoObjeto.IdRol);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, beValidaPermisoObjeto.IdAplicacion);
            db.AddInParameter(cmd, VCH_NOMBRE_FORMULARIO, DbType.String, beValidaPermisoObjeto.NombreFormulario);
            listaBeObjeto = new List<BEObjeto>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                BEObjeto beObjeto = null;
                while (dr.Read())
                {
                    beObjeto = new BEObjeto();
                    beObjeto.IdObjeto = Convert.ToInt16(dr[ID_OBJETO].ToString());

                    beObjeto.NombreFisicoObjeto = dr[NOMBRE_FISICO_OBJETO].ToString();
                    beObjeto.DescripcionObjeto = dr[DESCRIPCION_OBJETO].ToString();
                    beObjeto.EtiquetaObjeto = dr[ETIQUETA_OBJETO].ToString();
                    BETipoObjeto tipoObjeto = new BETipoObjeto();
                    tipoObjeto.IdTipoObjeto = Convert.ToInt16(dr[ID_TIPO_OBJETO].ToString());
                    beObjeto.TipoObjeto = tipoObjeto;
                    beObjeto.UrlObjeto = dr[URL_OBJETO].ToString();
                    if (dr[ID_OBJETO_PADRE] != DBNull.Value)
                    {
                        beObjeto.IdObjetoPadre = Convert.ToInt16(dr[ID_OBJETO_PADRE].ToString());
                    }
                    else
                    {
                        beObjeto.IdObjetoPadre = -1;
                    }

                    beObjeto.EstadoObjeto = Convert.ToBoolean(dr[ESTADO_OBJETO]);
                    beObjeto.EstadoPermisoObjeto = Convert.ToBoolean(dr[ESTADO_PERMISO_OBJETO]);
                    listaBeObjeto.Add(beObjeto);
                }
            }

            return listaBeObjeto;
        }

        public List<BEObjeto> ListarPermisoObjetoPorFormularioxUsuario(BEConsultaServicio beValidaPermisoObjeto)
        {
            List<BEObjeto> listaBeObjeto;

            DbCommand cmd = db.GetStoredProcCommand(UP_PERMISOOBJETO_LISTAR_ACCESO_USUARIO);
            db.AddInParameter(cmd, ID_USUARIO, DbType.Int32, beValidaPermisoObjeto.IdUsuario);
            db.AddInParameter(cmd, ID_APLICACION, DbType.Int32, beValidaPermisoObjeto.IdAplicacion);
            db.AddInParameter(cmd, VCH_NOMBRE_FORMULARIO, DbType.String, beValidaPermisoObjeto.NombreFormulario);
            listaBeObjeto = new List<BEObjeto>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                BEObjeto beObjeto = null;
                while (dr.Read())
                {
                    beObjeto = new BEObjeto();
                    beObjeto.IdObjeto = Convert.ToInt16(dr[ID_OBJETO].ToString());
                    beObjeto.NombreFisicoObjeto = dr[NOMBRE_FISICO_OBJETO].ToString();
                    beObjeto.DescripcionObjeto = dr[DESCRIPCION_OBJETO].ToString();
                    beObjeto.EtiquetaObjeto = dr[ETIQUETA_OBJETO].ToString();
                    BETipoObjeto tipoObjeto = new BETipoObjeto();
                    tipoObjeto.IdTipoObjeto = Convert.ToInt16(dr[ID_TIPO_OBJETO].ToString());
                    beObjeto.TipoObjeto = tipoObjeto;
                    beObjeto.UrlObjeto = dr[URL_OBJETO].ToString();
                    if (dr[ID_OBJETO_PADRE] != DBNull.Value)
                    {
                        beObjeto.IdObjetoPadre = Convert.ToInt16(dr[ID_OBJETO_PADRE].ToString());
                    }
                    else
                    {
                        beObjeto.IdObjetoPadre = -1;
                    }

                    beObjeto.EstadoObjeto = Convert.ToBoolean(dr[ESTADO_OBJETO]);
                    beObjeto.EstadoPermisoObjeto = Convert.ToBoolean(dr[ESTADO_PERMISO_OBJETO]);
                    listaBeObjeto.Add(beObjeto);
                }
            }

            return listaBeObjeto;
        }


        public List<BEObjeto> ListarPermisoObjetoMenuOpciones(BEConsultaServicio beValidaPermisoObjeto)
        {
            List<BEObjeto> listaBeObjeto;

            DbCommand cmd = db.GetStoredProcCommand(UP_PERMISOOBJETO_LISTAR_MENU_ACCESO);

            db.AddInParameter(cmd, INT_ID_ROL, DbType.Int32, beValidaPermisoObjeto.IdRol);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, beValidaPermisoObjeto.IdAplicacion);

            listaBeObjeto = new List<BEObjeto>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                BEObjeto beObjeto = null;
                while (dr.Read())
                {
                    beObjeto = new BEObjeto();
                    beObjeto.IdObjeto = Convert.ToInt16(dr[ID_OBJETO].ToString());

                    beObjeto.NombreFisicoObjeto = dr[NOMBRE_FISICO_OBJETO].ToString();
                    beObjeto.DescripcionObjeto = dr[DESCRIPCION_OBJETO].ToString();
                    beObjeto.EtiquetaObjeto = dr[ETIQUETA_OBJETO].ToString();
                    BETipoObjeto tipoObjeto = new BETipoObjeto();
                    tipoObjeto.IdTipoObjeto = Convert.ToInt16(dr[ID_TIPO_OBJETO].ToString());
                    beObjeto.TipoObjeto = tipoObjeto;
                    beObjeto.UrlObjeto = dr[URL_OBJETO].ToString();
                    if (dr[ID_OBJETO_PADRE] != DBNull.Value)
                    {
                        beObjeto.IdObjetoPadre = Convert.ToInt16(dr[ID_OBJETO_PADRE].ToString());
                    }
                    else
                    {
                        beObjeto.IdObjetoPadre = -1;
                    }

                    beObjeto.EstadoObjeto = Convert.ToBoolean(dr[ESTADO_OBJETO]);
                    beObjeto.EstadoPermisoObjeto = Convert.ToBoolean(dr[ESTADO_PERMISO_OBJETO]);
                    listaBeObjeto.Add(beObjeto);
                }
            }

            return listaBeObjeto;
        }

        public List<BEObjeto> ListarPermisoObjetoMenuOpcionesxUsuario(BEConsultaServicio beValidaPermisoObjeto)
        {
            List<BEObjeto> listaBeObjeto;

            DbCommand cmd = db.GetStoredProcCommand(UP_PERMISOOBJETO_LISTAR_MENU_ACCESOXUSUARIO);

            db.AddInParameter(cmd, ID_USUARIO, DbType.Int32, beValidaPermisoObjeto.IdUsuario);
            db.AddInParameter(cmd, ID_APLICACION, DbType.Int32, beValidaPermisoObjeto.IdAplicacion);

            listaBeObjeto = new List<BEObjeto>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                BEObjeto beObjeto = null;
                while (dr.Read())
                {
                    beObjeto = new BEObjeto();
                    beObjeto.IdObjeto = Convert.ToInt16(dr[ID_OBJETO].ToString());

                    beObjeto.NombreFisicoObjeto = dr[NOMBRE_FISICO_OBJETO].ToString();
                    beObjeto.DescripcionObjeto = dr[DESCRIPCION_OBJETO].ToString();
                    beObjeto.EtiquetaObjeto = dr[ETIQUETA_OBJETO].ToString();
                    BETipoObjeto tipoObjeto = new BETipoObjeto();
                    tipoObjeto.IdTipoObjeto = Convert.ToInt16(dr[ID_TIPO_OBJETO].ToString());
                    beObjeto.TipoObjeto = tipoObjeto;
                    beObjeto.UrlObjeto = dr[URL_OBJETO].ToString();
                    if (dr[ID_OBJETO_PADRE] != DBNull.Value)
                    {
                        beObjeto.IdObjetoPadre = Convert.ToInt16(dr[ID_OBJETO_PADRE].ToString());
                    }
                    else
                    {
                        beObjeto.IdObjetoPadre = -1;
                    }

                    beObjeto.EstadoObjeto = Convert.ToBoolean(dr[ESTADO_OBJETO]);
                    beObjeto.EstadoPermisoObjeto = Convert.ToBoolean(dr[ESTADO_PERMISO_OBJETO]);
                    listaBeObjeto.Add(beObjeto);
                }
            }

            return listaBeObjeto;
        }


        public bool ActualizarClave(BEActualizaClave beActualizaClave)
        {

            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_ACTUALIZAR_PASSWORD);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int16, beActualizaClave.IdUsuario);
            db.AddInParameter(cmd, BIT_REQUIERE_PASSWORD, DbType.Int16, 1);//TODO: CAMBIAR
            db.AddInParameter(cmd, VCH_PASSWORD, DbType.String, beActualizaClave.NuevaClave);
            db.AddInParameter(cmd, BIT_PASSWORD_CADUCA, DbType.Int16, 1);   //NO DEBERIA CAMBIARSE AQUI
            db.AddInParameter(cmd, DTM_FECHA_CADUCA, DbType.DateTime, DateTime.Now.AddMonths(3));
            db.AddInParameter(cmd, BIT_CAMBIAR_PASSWORD_EN_S_INICIO, DbType.Int16, 0);//TODO: CAMBIAR
            db.ExecuteNonQuery(cmd);

            return true;
        }

        public List<BEUsuarioClave> ObtenerUltimas13Claves(int idUsuario)
        {
            List<BEUsuarioClave> listaClaves = new List<BEUsuarioClave>();
            BEUsuarioClave beUsuarioClave;
            //Configurando el stored procedure
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIOCLAVE_VALIDAR_ANTERIORES);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int16, idUsuario);

            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                //Recorremos los resultados del stored procedure
                while (dr.Read())
                {
                    beUsuarioClave = new BEUsuarioClave();
                    beUsuarioClave.ClaveRegistrada = dr[CLAVEREGISTRADA].ToString();
                    listaClaves.Add(beUsuarioClave);
                }
            }

            return listaClaves;
        }

        public bool InsertarUsuarioClave(BEUsuarioClave beUsuarioClave)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIOCLAVE_INSERTAR);
            db.AddOutParameter(cmd, INT_ID_CLAVE, DbType.Int32, -1);
            db.AddInParameter(cmd, VCH_CLAVE_REGISTRADA, DbType.String, beUsuarioClave.ClaveRegistrada);
            db.AddInParameter(cmd, DTM_FECHA_REGISTRO, DbType.DateTime, beUsuarioClave.FechaRegistro);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int16, beUsuarioClave.IdUsuario);
            db.AddInParameter(cmd, BIT_ESTADO_CLAVE, DbType.Int16, 1);//TODO: CAMBIAR
            db.ExecuteNonQuery(cmd);

            return true;
        }

        public bool VerificarAccesoServicioWeb(string idUsuarioServicio, string claveUsuarioServicio)
        {
            bool accesoValido = false;

            //Configurando el stored procedure
            DbCommand cmd = db.GetStoredProcCommand(UP_APLICACIONSERVICIOWEB_VALIDARACCESOSERVICIOWEB);
            db.AddInParameter(cmd, VCH_USUARIO_SERVICIO_WEB, DbType.String, idUsuarioServicio);
            db.AddInParameter(cmd, VCH_CLAVE_USUARIO_SERVICIO_WEB, DbType.String, claveUsuarioServicio);

            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                //Recorremos los resultados del stored procedure
                if (dr.Read())
                {
                    accesoValido = true;
                }
            }

            return accesoValido;
        }


        public BEUsuario ValidarPermisoUsuario(int idUsuario, int idAplicacion, int idRol, int idArea)
        {
            BEUsuario usuario = null;

            //Configurando el stored procedure
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_LISTAR_ACCESO);



            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int16, idUsuario);
            db.AddInParameter(cmd, INT_ID_AREA, DbType.Int16, idArea);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int16, idAplicacion);
            db.AddInParameter(cmd, INT_ID_ROL, DbType.Int16, idRol);



            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                //Recorremos los resultados del stored procedure
                if (dr.Read())
                {
                    usuario = new BEUsuario();
                    usuario.IdUsuario = Convert.ToInt32(dr[ID_USUARIO].ToString());
                    usuario.CodigoUsuario = dr[CODIGO_USUARIO].ToString();
                    usuario.Nombres = dr[NOMBRES].ToString();
                    usuario.ApellidoPaterno = dr[APELLIDO_PATERNO].ToString();
                    usuario.ApellidoMaterno = dr[APELLIDO_MATERNO].ToString();
                    usuario.TipoUsuario = new BETipoUsuario();
                    usuario.TipoUsuario.IdTipoUsuario = Convert.ToInt32(dr[ID_TIPO_USUARIO].ToString());
                    usuario.Oficina = new BEOficina();
                    usuario.Oficina.IdOficina = Convert.ToInt32(dr[ID_OFICINA].ToString());
                    usuario.Area = new BEArea();
                    usuario.Area.IdArea = Convert.ToInt32(dr[ID_AREA].ToString());
                    usuario.IdArea = Convert.ToInt32(dr[ID_AREA].ToString());
                    usuario.PasswordCaduca = Convert.ToBoolean(dr[PASSWORD_CADUCA].ToString());
                    if (dr[FECHA_CADUCA] != DBNull.Value)
                    {
                        usuario.FechaCaduca = Convert.ToDateTime(dr[FECHA_CADUCA].ToString());
                    }
                    else
                    {
                        usuario.FechaCaduca = DateTime.MaxValue;
                    }
                    usuario.CambiarPasswordEnInicio = Convert.ToBoolean(dr[CAMBIAR_PASSWORD_EN_S_INICIO].ToString());
                    usuario.EstadoUsuario = Convert.ToBoolean(dr[ESTADO_USUARIO]);
                    usuario.PagoTercero = Convert.ToInt16(dr[PAGO_TERCERO]);
                    usuario.PermisoUsuario = new BEPermisoUsuario();
                    usuario.PermisoUsuario.BERol = new BERol();
                    usuario.PermisoUsuario.BERol.IdRol = Convert.ToInt32(dr[ID_ROL].ToString());
                }
            }

            return usuario;
        }

        public bool InsertarAuditoriaUsuario(BEAuditoriaUsuario beAuditoriaUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_AUDITORIAUSUARIO_INSERTAR);

            db.AddInParameter(cmd, INT_ID_USUARIO_AFECTADO, DbType.Int16, beAuditoriaUsuario.IdUsuarioAfectado);
            db.AddInParameter(cmd, INT_ID_USUARIO_AFECTADOR, DbType.Int16, beAuditoriaUsuario.IdUsuarioAfectador);
            db.AddInParameter(cmd, INT_ID_TIPO_OPERACION, DbType.Int16, beAuditoriaUsuario.IdTipoOperacion);
            db.AddInParameter(cmd, VCH_OBSERVACION, DbType.String, beAuditoriaUsuario.Observacion);
            db.ExecuteNonQuery(cmd);

            return true;
        }
        #endregion
    }
}
