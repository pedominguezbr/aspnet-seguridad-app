using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.SEG.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
namespace APP.SEG.AccesoDatos
{
    public class DAUsuario
    {
        #region Constantes
        private const string UP_USUARIO_ACTUALIZAR = "up_Usuario_Actualizar";
        private const string UP_USUARIO_SSEE_ACTUALIZA = "up_UsuarioSSEE_Actualizar";
        private const string UP_VALIDA_LIMITE_USUARIOS = "up_Valida_Limite_Usuarios";
        private const string INT_ID_USUARIO = "IntIdusuario";
        private const string VCH_CODIGO_USUARIO = "VchCodigousuario";
        private const string VCH_NOMBRES = "VchNombres";
        private const string VCH_APELLIDO_PATERNO = "VchApellidopaterno";
        private const string VCH_APELLIDO_MATERNO = "VchApellidomaterno";
        private const string INT_ID_TIPO_USUARIO = "IntIdtipousuario";
        private const string INT_ID_AREA = "IntIdarea";
        private const string INT_ID_OFICINA = "IntIdoficina";
        private const string BIT_REQUIERE_PASSWORD = "BitRequierepassword";
        private const string BIT_PASSWORD_CADUCA = "BitPasswordcaduca";
        private const string DTM_FECHA_CADUCA = "DtmFechacaduca";
        private const string BIT_CAMBIAR_PASSWORD_INICIO = "BitCambiarpasswordensinicio";
        private const string BIT_ESTADO_USUARIO = "BitEstadousuario";
        private const string VCH_CORREO_ELECTRONICO = "VchCorreoElectronico";

        //
        private const string UP_USUARIO_INSERTAR = "up_Usuario_Insertar";
        private const string UP_USUARIO_CONTRATISTA_INSERTAR = "up_Usuario_Contratista_Insertar";
        private const string DTM_FECHA_CREACION = "DtmFechacreacion";
        private const string INT_ID_USUARIO_CREACION = "IntIdusuariocreacion";
        private const string VCH_PASSWORD = "VchPassword";
        private const string INT_PAGO_TERCERO = "IntPagoTercero";
        private const string UP_USUARIO_LISTAR_ID = "up_Usuario_Listar_Id";

        // PROCEDURE LISTAR
        private const string UP_USUARIO_LISTAR = "up_Usuario_Listar";
        private const string ID_USUARIO = "IdUsuario";
        private const string CODIGO_USUARIO = "CodigoUsuario";
        private const string NOMBRES = "Nombres";
        private const string APELLIDO_PATERNO = "ApellidoPaterno";
        private const string APELLIDO_MATERNO = "ApellidoMaterno";
        private const string ID_TIPO_USUARIO = "IdTipoUsuario";
        private const string ID_AREA = "IdArea";
        private const string ID_OFICINA = "IdOficina";
        private const string REQUIERE_PASSWORD = "RequierePassword";
        private const string PASSWORD = "Password";
        private const string PASSWORD_CADUCA = "PasswordCaduca";
        private const string FECHA_CADUCA = "FechaCaduca";
        private const string CAMBIAR_PASSWORD_INICIO = "CambiarPasswordEnSInicio";
        private const string FECHA_CREACION = "FechaCreacion";
        private const string ID_USUARIO_CREACION = "IdUsuarioCreacion";
        private const string ESTADO_USUARIO = "EstadoUsuario";
        private const string PAGO_TERCERO = "PagoTercero";
        private const string CORREO_ELECTRONICO = "CorreoElectronico";
        private const string INT_CODIGO_MENSAJE = "IntCodigoMensaje";
        private const string INT_ID_TIPOEMPRESA = "IdTipoEmpresa";
        private const string INT_ID_EMPRESA = "IdEmpresa";
        private const string VCH_NOMEMPRESA = "NomEmpresa";
        private const string ID_APLICACION = "IdAplicacion";
        //PROCEDURE ELIMINAR
        private const string UP_USUARIO_ELIMINAR = "up_Usuario_Eliminar";
        private const string UP_USUARIO_OBTENER_CODIGO = "up_Usuario_Obtener_Codigo";

        private const string UP_EMPRESA_USUARIOXTIPOEMPRESA = "up_Empresa_UsuarioxTipoEmpresa";
        private const string UP_LISTA_CLIENTE_CONTRATISTA = "up_Lista_Cliente_Contratista";

        //PROCEDURE LISTAR_CLIENTE_CONTRATISTA
        private const string INT_ID_TIPO_EMPRESA = "IntIdtipoempresa";
        private const string INT_ID_USUARIO_LOGUEADO = "IntIdusuariologueado";
        private const string INT_ID_MODO = "IntIdmodo";
        private const string INT_ID_APLICACION = "IntIdaplicacion";
        private const string INT_ID_ROL = "IntIdRol";
        private const string INT_ID_TIPO_CLIENTE = "IntIdTipoCliente";
        private const string BIT_BORRA_CLIENTES = "BitBorraClientes";
        private const string RUC = "Ruc";
        private const string IDTIPOEMPRESA = "IdTipoEmpresa";
        private const string NOMTIPOEMPRESA = "NomTipoEmpresa";
        private const string ASIGNADO = "Asignado";
        private const string IDROL = "IdRol";
        private const string NOMBREROL = "NombreRol";
        private const string INT_RESULTADO = "IntResultado";

        #endregion

        #region Variables

        private Database db;

        #endregion Fin Variables locales

        #region Constructor
        public DAUsuario()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }
        #endregion

        #region Metodos
        public bool ActualizarUsuario(BEUsuario beUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_ACTUALIZAR);

            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, beUsuario.IdUsuario);
            db.AddInParameter(cmd, VCH_CODIGO_USUARIO, DbType.String, beUsuario.CodigoUsuario);
            //db.AddInParameter(cmd, VCH_CODIGO_USUARIO, DbType.String, 1);
            db.AddInParameter(cmd, VCH_NOMBRES, DbType.String, beUsuario.Nombres);
            db.AddInParameter(cmd, VCH_APELLIDO_PATERNO, DbType.String, beUsuario.ApellidoPaterno);
            db.AddInParameter(cmd, VCH_APELLIDO_MATERNO, DbType.String, beUsuario.ApellidoMaterno);
            db.AddInParameter(cmd, INT_ID_TIPO_USUARIO, DbType.Int32, beUsuario.TipoUsuario.IdTipoUsuario);
            db.AddInParameter(cmd, INT_ID_AREA, DbType.Int32, beUsuario.IdArea);
            db.AddInParameter(cmd, INT_ID_OFICINA, DbType.Int32, beUsuario.Oficina.IdOficina);
            //@BitRequierepassword   BIT_REQUIERE_PASSWORD
            db.AddInParameter(cmd, VCH_PASSWORD, DbType.String, beUsuario.Password);
            db.AddInParameter(cmd, BIT_REQUIERE_PASSWORD, DbType.Int32, beUsuario.RequierePassword);
            db.AddInParameter(cmd, BIT_PASSWORD_CADUCA, DbType.Int32, beUsuario.PasswordCaduca);
            if (beUsuario.PasswordCaduca)
            {
                db.AddInParameter(cmd, DTM_FECHA_CADUCA, DbType.DateTime, beUsuario.FechaCaduca.Date);
            }
            else
            {
                db.AddInParameter(cmd, DTM_FECHA_CADUCA, DbType.DateTime, DBNull.Value);
            }
            db.AddInParameter(cmd, BIT_CAMBIAR_PASSWORD_INICIO, DbType.Int32, beUsuario.CambiarPasswordEnInicio);
            //db.AddInParameter(cmd, DTM_FECHA_CREACION, DbType.DateTime, beUsuario.FechaCreacion);
            //db.AddInParameter(cmd, INT_ID_USUARIO_CREACION, DbType.Int32, 1);
            db.AddInParameter(cmd, BIT_ESTADO_USUARIO, DbType.Int32, beUsuario.EstadoUsuario);
            db.AddInParameter(cmd, INT_PAGO_TERCERO, DbType.Int32, beUsuario.PagoTercero);
            db.AddInParameter(cmd, VCH_CORREO_ELECTRONICO, DbType.String, beUsuario.CorreoElectronico);
            db.ExecuteNonQuery(cmd);
            return true;
        }

        public bool ActualizarUsuarioSSEE(BEUsuario beUsuario, List<BEEmpresa> listaEmpresa, int IdAplicacion, int IdTipoCliente)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_SSEE_ACTUALIZA);

            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, beUsuario.IdUsuario);
            db.AddInParameter(cmd, VCH_NOMBRES, DbType.String, beUsuario.Nombres);
            db.AddInParameter(cmd, VCH_APELLIDO_PATERNO, DbType.String, beUsuario.ApellidoPaterno);
            db.AddInParameter(cmd, VCH_APELLIDO_MATERNO, DbType.String, beUsuario.ApellidoMaterno);
            db.AddInParameter(cmd, INT_ID_TIPO_USUARIO, DbType.Int32, beUsuario.TipoUsuario.IdTipoUsuario);
            db.AddInParameter(cmd, BIT_ESTADO_USUARIO, DbType.Int32, beUsuario.EstadoUsuario);
            db.AddInParameter(cmd, VCH_CORREO_ELECTRONICO, DbType.String, beUsuario.CorreoElectronico);
            db.AddInParameter(cmd, INT_ID_ROL, DbType.Int32, beUsuario.PermisoUsuario.BERol.IdRol);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, IdAplicacion);
            db.AddInParameter(cmd, INT_ID_TIPO_CLIENTE, DbType.Int32, IdTipoCliente);
            db.AddInParameter(cmd, BIT_BORRA_CLIENTES, DbType.Int32, 1);
            db.ExecuteNonQuery(cmd);

            // Inserta Empresa al Usuario Contratista.
            DAEmpresa oDAEmpresa = new DAEmpresa();
            foreach (BEEmpresa oBEEmpresa in listaEmpresa)
            {
                if (oBEEmpresa.Ruc != null)
                {
                    BEEmpresa oBEEmpresaAux = new BEEmpresa();
                    oBEEmpresaAux = oDAEmpresa.ObtenerEmpresaxRuc(oBEEmpresa.Ruc);
                    oDAEmpresa.InsertarEmpresaUsuario(oBEEmpresaAux.IdEmpresa, beUsuario.IdUsuario, IdAplicacion);
                }
                else
                {
                    oDAEmpresa.InsertarEmpresaUsuario(oBEEmpresa.IdEmpresa, beUsuario.IdUsuario, IdAplicacion);
                }

            }

            oDAEmpresa.EliminarEmpresaxUsuario_Usuario(beUsuario.IdUsuario, IdAplicacion);

            return true;
        }


        public bool EliminarUsuario(int idUsuario, ref int codigoMensaje)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_ELIMINAR);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, idUsuario);
            db.AddOutParameter(cmd, INT_CODIGO_MENSAJE, DbType.Int16, 0);
            db.ExecuteNonQuery(cmd);

            if (db.GetParameterValue(cmd, INT_CODIGO_MENSAJE) != null && db.GetParameterValue(cmd, INT_CODIGO_MENSAJE) != DBNull.Value)
            {
                codigoMensaje = Convert.ToInt16(db.GetParameterValue(cmd, INT_CODIGO_MENSAJE).ToString());
            }

            return true;
        }

        public bool InsertarUsuario(BEUsuario beUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_INSERTAR);
            db.AddOutParameter(cmd, INT_ID_USUARIO, DbType.Int32, beUsuario.IdUsuario);
            db.AddInParameter(cmd, VCH_CODIGO_USUARIO, DbType.String, beUsuario.CodigoUsuario);
            db.AddInParameter(cmd, VCH_NOMBRES, DbType.String, beUsuario.Nombres);
            db.AddInParameter(cmd, VCH_APELLIDO_PATERNO, DbType.String, beUsuario.ApellidoPaterno);
            db.AddInParameter(cmd, VCH_APELLIDO_MATERNO, DbType.String, beUsuario.ApellidoMaterno);
            db.AddInParameter(cmd, INT_ID_TIPO_USUARIO, DbType.Int32, beUsuario.TipoUsuario.IdTipoUsuario);
            db.AddInParameter(cmd, INT_ID_AREA, DbType.Int32, beUsuario.IdArea);
            db.AddInParameter(cmd, INT_ID_OFICINA, DbType.Int32, beUsuario.Oficina.IdOficina);
            db.AddInParameter(cmd, BIT_REQUIERE_PASSWORD, DbType.Int32, beUsuario.RequierePassword);
            db.AddInParameter(cmd, VCH_PASSWORD, DbType.String, beUsuario.Password);
            db.AddInParameter(cmd, BIT_PASSWORD_CADUCA, DbType.Int32, beUsuario.PasswordCaduca);
            db.AddInParameter(cmd, DTM_FECHA_CADUCA, DbType.DateTime, DBNull.Value);
            db.AddInParameter(cmd, BIT_CAMBIAR_PASSWORD_INICIO, DbType.Int32, beUsuario.CambiarPasswordEnInicio);
            db.AddInParameter(cmd, DTM_FECHA_CREACION, DbType.DateTime, DateTime.Now);
            db.AddInParameter(cmd, INT_ID_USUARIO_CREACION, DbType.Int32, 100);
            db.AddInParameter(cmd, BIT_ESTADO_USUARIO, DbType.Int32, beUsuario.EstadoUsuario);
            db.AddInParameter(cmd, INT_PAGO_TERCERO, DbType.Int32, beUsuario.PagoTercero);
            db.AddInParameter(cmd, VCH_CORREO_ELECTRONICO, DbType.String, beUsuario.CorreoElectronico);
            db.ExecuteNonQuery(cmd);
            if (db.GetParameterValue(cmd, INT_ID_USUARIO) != null && db.GetParameterValue(cmd, INT_ID_USUARIO) != DBNull.Value)
            {
                beUsuario.IdUsuario = Convert.ToInt16(db.GetParameterValue(cmd, INT_ID_USUARIO).ToString());
            }
            return true;
        }

        public bool InsertarUsuarioContratista(BEUsuario beUsuario, List<BEEmpresa> listaEmpresa, int IdAplicacion)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_INSERTAR);

            db.AddOutParameter(cmd, INT_ID_USUARIO, DbType.Int32, beUsuario.IdUsuario);
            db.AddInParameter(cmd, VCH_CODIGO_USUARIO, DbType.String, beUsuario.CodigoUsuario);
            db.AddInParameter(cmd, VCH_NOMBRES, DbType.String, beUsuario.Nombres);
            db.AddInParameter(cmd, VCH_APELLIDO_PATERNO, DbType.String, beUsuario.ApellidoPaterno);
            db.AddInParameter(cmd, VCH_APELLIDO_MATERNO, DbType.String, beUsuario.ApellidoMaterno);
            db.AddInParameter(cmd, INT_ID_TIPO_USUARIO, DbType.Int32, beUsuario.TipoUsuario.IdTipoUsuario);
            db.AddInParameter(cmd, INT_ID_AREA, DbType.Int32, beUsuario.IdArea);
            db.AddInParameter(cmd, INT_ID_OFICINA, DbType.Int32, beUsuario.Oficina.IdOficina);
            db.AddInParameter(cmd, BIT_REQUIERE_PASSWORD, DbType.Int32, beUsuario.RequierePassword);
            db.AddInParameter(cmd, VCH_PASSWORD, DbType.String, beUsuario.Password);
            db.AddInParameter(cmd, BIT_PASSWORD_CADUCA, DbType.Int32, beUsuario.PasswordCaduca);
            db.AddInParameter(cmd, DTM_FECHA_CADUCA, DbType.DateTime, DBNull.Value);
            db.AddInParameter(cmd, BIT_CAMBIAR_PASSWORD_INICIO, DbType.Int32, beUsuario.CambiarPasswordEnInicio);
            db.AddInParameter(cmd, DTM_FECHA_CREACION, DbType.DateTime, DateTime.Now);
            db.AddInParameter(cmd, INT_ID_USUARIO_CREACION, DbType.Int32, 100);
            db.AddInParameter(cmd, BIT_ESTADO_USUARIO, DbType.Int32, beUsuario.EstadoUsuario);
            db.AddInParameter(cmd, INT_PAGO_TERCERO, DbType.Int32, beUsuario.PagoTercero);
            db.AddInParameter(cmd, VCH_CORREO_ELECTRONICO, DbType.String, beUsuario.CorreoElectronico);
            db.ExecuteNonQuery(cmd);
            if (db.GetParameterValue(cmd, INT_ID_USUARIO) != null && db.GetParameterValue(cmd, INT_ID_USUARIO) != DBNull.Value)
            {
                beUsuario.IdUsuario = Convert.ToInt16(db.GetParameterValue(cmd, INT_ID_USUARIO).ToString());
            }
            //Asigna Permiso al usuario
            DAPermisoUsuario oDAPermisoUsuario = new DAPermisoUsuario();
            BEPermisoUsuario oBEPermisoUsuario = new BEPermisoUsuario();

            oBEPermisoUsuario.beUsuario = new BEUsuario();
            oBEPermisoUsuario.beUsuario.IdUsuario = beUsuario.IdUsuario;
            oBEPermisoUsuario.BERol = new BERol();
            oBEPermisoUsuario.BERol.IdRol = beUsuario.PermisoUsuario.BERol.IdRol;
            oBEPermisoUsuario.BEAplicacion = new BEAplicacion();
            oBEPermisoUsuario.BEAplicacion.IdAplicacion = IdAplicacion;
            oBEPermisoUsuario.IdUsuarioCreacion = 100;
            oBEPermisoUsuario.FechaCreacion = DateTime.Now.Date;
            oBEPermisoUsuario.Estado = true;

            oDAPermisoUsuario.InsertarPermisoUsuario(oBEPermisoUsuario);

            // Inserta Empresa al Usuario Contratista.
            DAEmpresa oDAEmpresa = new DAEmpresa();
            foreach (BEEmpresa oBEEmpresa in listaEmpresa)
            {
                if (oBEEmpresa.Ruc != null)
                {
                    BEEmpresa oBEEmpresaAux = new BEEmpresa();
                    oBEEmpresaAux = oDAEmpresa.ObtenerEmpresaxRuc(oBEEmpresa.Ruc);
                    oDAEmpresa.InsertarEmpresaUsuario(oBEEmpresaAux.IdEmpresa, beUsuario.IdUsuario, IdAplicacion);
                }
                else
                {
                    oDAEmpresa.InsertarEmpresaUsuario(oBEEmpresa.IdEmpresa, beUsuario.IdUsuario, IdAplicacion);
                }

            }
            return true;
        }

        public List<BEUsuario> ListarUsuario(BEBusquedaUsuario beBusquedaUsuario)
        {
            List<BEUsuario> listaUsuario = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_LISTAR);
            db.AddInParameter(cmd, VCH_NOMBRES, DbType.String, beBusquedaUsuario.NombreUsuario);
            db.AddInParameter(cmd, VCH_APELLIDO_PATERNO, DbType.String, beBusquedaUsuario.ApellidoPaternoUsuario);
            db.AddInParameter(cmd, VCH_APELLIDO_MATERNO, DbType.String, beBusquedaUsuario.ApellidoMaternoUsuario);
            listaUsuario = new List<BEUsuario>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BEUsuario beUsuario = new BEUsuario();
                    beUsuario.IdUsuario = Int32.Parse(dr[ID_USUARIO].ToString());
                    beUsuario.CodigoUsuario = dr[CODIGO_USUARIO].ToString();
                    beUsuario.Nombres = dr[NOMBRES].ToString();
                    beUsuario.ApellidoPaterno = dr[APELLIDO_PATERNO].ToString();
                    beUsuario.ApellidoMaterno = dr[APELLIDO_MATERNO].ToString();
                    beUsuario.TipoUsuario.IdTipoUsuario = Int32.Parse(dr[ID_TIPO_USUARIO].ToString());
                    beUsuario.IdArea = Int32.Parse(dr[ID_AREA].ToString());
                    beUsuario.Oficina.IdOficina = Int32.Parse(dr[ID_OFICINA].ToString());
                    beUsuario.RequierePassword = Boolean.Parse(dr[REQUIERE_PASSWORD].ToString());
                    beUsuario.Password = dr[PASSWORD].ToString();
                    beUsuario.PasswordCaduca = Boolean.Parse(dr[PASSWORD_CADUCA].ToString());
                    if (dr[FECHA_CADUCA] != null && dr[FECHA_CADUCA] != DBNull.Value)
                    {
                        beUsuario.FechaCaduca = DateTime.Parse(dr[FECHA_CADUCA].ToString());
                    }
                    beUsuario.CambiarPasswordEnInicio = Boolean.Parse(dr[CAMBIAR_PASSWORD_INICIO].ToString());
                    beUsuario.FechaCreacion = DateTime.Parse(dr[DTM_FECHA_CREACION].ToString());
                    beUsuario.PermisoUsuario.IdUsuarioCreacion = Int32.Parse(dr[ID_USUARIO_CREACION].ToString());
                    beUsuario.EstadoUsuario = Boolean.Parse(dr[ESTADO_USUARIO].ToString());
                    beUsuario.CorreoElectronico = dr[CORREO_ELECTRONICO].ToString();
                    listaUsuario.Add(beUsuario);
                }

            }
            return listaUsuario;
        }


        public BEUsuario ObtenerUsuario(int idUsuario)
        {
            BEUsuario beUsuario = null;
            List<BEUsuario> listaUsuario = new List<BEUsuario>();

            //Configurando el stored procedure
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_LISTAR_ID);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, idUsuario);

            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                //Recorremos los resultados del stored procedure
                if (dr.Read())
                {
                    //Llenamos el objeto
                    beUsuario = new BEUsuario();
                    beUsuario.IdUsuario = Int32.Parse(dr[ID_USUARIO].ToString());
                    beUsuario.CodigoUsuario = dr[CODIGO_USUARIO].ToString();
                    beUsuario.Nombres = dr[NOMBRES].ToString();
                    beUsuario.ApellidoPaterno = dr[APELLIDO_PATERNO].ToString();
                    beUsuario.ApellidoMaterno = dr[APELLIDO_MATERNO].ToString();
                    beUsuario.TipoUsuario = new BETipoUsuario();
                    beUsuario.TipoUsuario.IdTipoUsuario = Int32.Parse(dr[ID_TIPO_USUARIO].ToString());
                    beUsuario.Area = new BEArea();
                    beUsuario.Area.IdArea = Int32.Parse(dr[ID_AREA].ToString());
                    beUsuario.Oficina = new BEOficina();
                    beUsuario.Oficina.IdOficina = Int32.Parse(dr[ID_OFICINA].ToString());
                    beUsuario.CorreoElectronico = dr[CORREO_ELECTRONICO].ToString();
                    byte valrequierepassword = Convert.ToByte(dr[REQUIERE_PASSWORD]);
                    if (valrequierepassword == 1)
                    {
                        beUsuario.RequierePassword = true;
                    }
                    else
                    {
                        beUsuario.RequierePassword = false;
                    }

                    beUsuario.Password = dr[PASSWORD].ToString();
                    byte valpasswordcaduca = Convert.ToByte(dr[PASSWORD_CADUCA]);

                    //if ((dr[PASSWORD_CADUCA].ToString()) == "1")
                    if (valpasswordcaduca == 1)
                    {
                        beUsuario.PasswordCaduca = true;
                    }
                    else
                    {
                        beUsuario.PasswordCaduca = false;
                    }

                    beUsuario.Password = dr[PASSWORD].ToString();
                    if (dr[FECHA_CADUCA] != null && dr[FECHA_CADUCA] != DBNull.Value)
                    {
                        beUsuario.FechaCaduca = DateTime.Parse(dr[FECHA_CADUCA].ToString());
                    }
                    byte valcambiapasswordinicio = Convert.ToByte(dr[CAMBIAR_PASSWORD_INICIO]);
                    //if ((dr[CAMBIAR_PASSWORD_INICIO].ToString()) == "1")
                    if (valcambiapasswordinicio == 1)
                    {
                        beUsuario.CambiarPasswordEnInicio = true;
                    }
                    else
                    {
                        beUsuario.CambiarPasswordEnInicio = false;
                    }

                    beUsuario.FechaCreacion = DateTime.Parse(dr[FECHA_CREACION].ToString());
                    beUsuario.PagoTercero = Convert.ToInt16(dr[PAGO_TERCERO].ToString());
                    byte valestadousuario = Convert.ToByte(dr[ESTADO_USUARIO]);
                    if (valestadousuario == 1)
                    {
                        beUsuario.EstadoUsuario = true;
                    }
                    else
                    {
                        beUsuario.EstadoUsuario = false;
                    }

                    listaUsuario.Add(beUsuario);
                }
            }
            return beUsuario;
        }


        public List<BEUsuario> BuscarUsuario(BEUsuario beUsuario)
        {
            //BEUsuario beUsuario = null;
            List<BEUsuario> listaUsuario = new List<BEUsuario>();

            //Configurando el stored procedure
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_LISTAR);
            db.AddInParameter(cmd, VCH_NOMBRES, DbType.String, beUsuario.Nombres + "%");
            db.AddInParameter(cmd, VCH_APELLIDO_PATERNO, DbType.String, beUsuario.ApellidoPaterno + "%");
            db.AddInParameter(cmd, VCH_APELLIDO_MATERNO, DbType.String, beUsuario.ApellidoMaterno + "%");
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                //Recorremos los resultados del stored procedure
                while (dr.Read())
                {
                    //Llenamos el objeto
                    beUsuario = new BEUsuario();
                    beUsuario.IdUsuario = Int32.Parse(dr[ID_USUARIO].ToString());
                    beUsuario.CodigoUsuario = dr[CODIGO_USUARIO].ToString();
                    beUsuario.Nombres = dr[NOMBRES].ToString();
                    beUsuario.ApellidoPaterno = dr[APELLIDO_PATERNO].ToString();
                    beUsuario.ApellidoMaterno = dr[APELLIDO_MATERNO].ToString();
                    beUsuario.TipoUsuario = new BETipoUsuario();
                    beUsuario.TipoUsuario.IdTipoUsuario = Int32.Parse(dr[ID_TIPO_USUARIO].ToString());
                    beUsuario.Area = new BEArea();
                    beUsuario.Area.IdArea = Int32.Parse(dr[ID_AREA].ToString());
                    beUsuario.Oficina = new BEOficina();
                    beUsuario.Oficina.IdOficina = Int32.Parse(dr[ID_OFICINA].ToString());
                    beUsuario.CorreoElectronico = dr[CORREO_ELECTRONICO].ToString();
                    byte valRequierePassword = Convert.ToByte(dr[REQUIERE_PASSWORD]);
                    //if ((dr[REQUIERE_PASSWORD].ToString()) == "1")
                    if (valRequierePassword == 1)
                    {
                        beUsuario.RequierePassword = true;
                    }
                    else
                    {
                        beUsuario.RequierePassword = false;
                    }
                    //beUsuario.RequierePassword = Boolean.Parse(dr[REQUIERE_PASSWORD].ToString());
                    beUsuario.Password = dr[PASSWORD].ToString();
                    byte valPasswordCaduca = Convert.ToByte(dr[PASSWORD_CADUCA]);
                    if (valPasswordCaduca == 1)
                    {
                        beUsuario.PasswordCaduca = true;
                    }
                    else
                    {
                        beUsuario.PasswordCaduca = false;
                    }
                    //beUsuario.PasswordCaduca = Boolean.Parse(dr[PASSWORD].ToString());
                    beUsuario.Password = dr[PASSWORD].ToString();

                    if (dr[FECHA_CADUCA] != null && dr[FECHA_CADUCA] != DBNull.Value)
                    {
                        beUsuario.FechaCaduca = DateTime.Parse(dr[FECHA_CADUCA].ToString());
                    }
                    //beUsuario.CambiarPasswordEnInicio = Boolean.Parse(dr[CAMBIAR_PASSWORD_INICIO].ToString());
                    byte val = Convert.ToByte(dr[CAMBIAR_PASSWORD_INICIO]);
                    //if ((dr[CAMBIAR_PASSWORD_INICIO].ToString()) == "1")
                    if (val == 1)
                    {
                        beUsuario.CambiarPasswordEnInicio = true;
                    }
                    else
                    {
                        beUsuario.CambiarPasswordEnInicio = false;
                    }

                    beUsuario.FechaCreacion = DateTime.Parse(dr[FECHA_CREACION].ToString());
                    //beUsuario.PermisoUsuario.IdUsuarioCreacion = Int32.Parse(dr[ID_USUARIO_CREACION].ToString());
                    byte val1 = Convert.ToByte(dr[ESTADO_USUARIO]);
                    //if ((dr[ESTADO_USUARIO].ToString()) == "1")
                    if (val1 == 1)
                    {
                        beUsuario.EstadoUsuario = true;
                    }
                    else
                    {
                        beUsuario.EstadoUsuario = false;
                    }
                    //beUsuario.EstadoUsuario = Boolean.Parse(dr[ESTADO_USUARIO].ToString());
                    listaUsuario.Add(beUsuario);
                }
            }
            return listaUsuario;
        }

        public BEUsuario ObtenerUsuarioPorCodigo(string codigoUsuario)
        {
            BEUsuario beUsuario = null;

            //Configurando el stored procedure
            DbCommand cmd = db.GetStoredProcCommand(UP_USUARIO_OBTENER_CODIGO);
            db.AddInParameter(cmd, VCH_CODIGO_USUARIO, DbType.String, codigoUsuario);

            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                //Recorremos los resultados del stored procedure
                if (dr.Read())
                {
                    //Llenamos el objeto
                    beUsuario = new BEUsuario();
                    beUsuario.IdUsuario = Int32.Parse(dr[ID_USUARIO].ToString());
                    beUsuario.CodigoUsuario = dr[CODIGO_USUARIO].ToString();
                    beUsuario.Nombres = dr[NOMBRES].ToString();
                    beUsuario.ApellidoPaterno = dr[APELLIDO_PATERNO].ToString();
                    beUsuario.ApellidoMaterno = dr[APELLIDO_MATERNO].ToString();
                    beUsuario.TipoUsuario = new BETipoUsuario();
                    beUsuario.TipoUsuario.IdTipoUsuario = Int32.Parse(dr[ID_TIPO_USUARIO].ToString());
                    beUsuario.Area = new BEArea();
                    beUsuario.Area.IdArea = Int32.Parse(dr[ID_AREA].ToString());
                    beUsuario.Oficina = new BEOficina();
                    beUsuario.Oficina.IdOficina = Int32.Parse(dr[ID_OFICINA].ToString());
                    beUsuario.CorreoElectronico = dr[CORREO_ELECTRONICO].ToString();

                    byte valrequierepassword = Convert.ToByte(dr[REQUIERE_PASSWORD]);
                    if (valrequierepassword == 1)
                    {
                        beUsuario.RequierePassword = true;
                    }
                    else
                    {
                        beUsuario.RequierePassword = false;
                    }

                    beUsuario.Password = dr[PASSWORD].ToString();
                    byte valpasswordcaduca = Convert.ToByte(dr[PASSWORD_CADUCA]);

                    //if ((dr[PASSWORD_CADUCA].ToString()) == "1")
                    if (valpasswordcaduca == 1)
                    {
                        beUsuario.PasswordCaduca = true;
                    }
                    else
                    {
                        beUsuario.PasswordCaduca = false;
                    }

                    beUsuario.Password = dr[PASSWORD].ToString();
                    if (dr[FECHA_CADUCA] != null && dr[FECHA_CADUCA] != DBNull.Value)
                    {
                        beUsuario.FechaCaduca = DateTime.Parse(dr[FECHA_CADUCA].ToString());
                    }
                    byte valcambiapasswordinicio = Convert.ToByte(dr[CAMBIAR_PASSWORD_INICIO]);
                    //if ((dr[CAMBIAR_PASSWORD_INICIO].ToString()) == "1")
                    if (valcambiapasswordinicio == 1)
                    {
                        beUsuario.CambiarPasswordEnInicio = true;
                    }
                    else
                    {
                        beUsuario.CambiarPasswordEnInicio = false;
                    }

                    beUsuario.FechaCreacion = DateTime.Parse(dr[FECHA_CREACION].ToString());
                    beUsuario.PagoTercero = Convert.ToInt16(dr[PAGO_TERCERO].ToString());
                    byte valestadousuario = Convert.ToByte(dr[ESTADO_USUARIO]);
                    if (valestadousuario == 1)
                    {
                        beUsuario.EstadoUsuario = true;
                    }
                    else
                    {
                        beUsuario.EstadoUsuario = false;
                    }
                }
            }
            return beUsuario;
        }

        public List<BEEmpresa> ListarEmpresaxUsuario(int IdUsuario, int IdTipoEmpresa,int IdAplicacion)
        {
             List<BEEmpresa> listaEmpresa = new List<BEEmpresa>();
             DbCommand cmd = db.GetStoredProcCommand(UP_EMPRESA_USUARIOXTIPOEMPRESA);

             db.AddInParameter(cmd, ID_USUARIO, DbType.Int32, IdUsuario);
             db.AddInParameter(cmd, INT_ID_TIPOEMPRESA,DbType.Int32,IdTipoEmpresa);
             db.AddInParameter(cmd, ID_APLICACION, DbType.Int32, IdAplicacion);

             using (IDataReader dr = db.ExecuteReader(cmd))
             {
                 //Recorremos los resultados del stored procedure
                 while (dr.Read())
                 {
                     BEEmpresa oBEEmpresa = new BEEmpresa();
                     oBEEmpresa.IdEmpresa = Int32.Parse(dr[INT_ID_EMPRESA].ToString());
                     oBEEmpresa.NomEmpresa = dr[VCH_NOMEMPRESA].ToString();
                     oBEEmpresa.BETipoEmpresa = new BETipoEmpresa();
                     oBEEmpresa.BETipoEmpresa.IdTipoEmpresa = IdTipoEmpresa;
                     oBEEmpresa.Ruc = dr[RUC].ToString();
                     listaEmpresa.Add(oBEEmpresa);
                 }
             }
             return listaEmpresa;
        }
        public List<BEUsuario> ListaContratistaxEmpresa(int IdTipoEmpresa, int IdUsuario, int IdUsuarioLogueado, int IdModo, int IdAplicacion)
        {
            List<BEUsuario> listaUsuario = new List<BEUsuario>();
            DbCommand cmd = db.GetStoredProcCommand(UP_LISTA_CLIENTE_CONTRATISTA);

            db.AddInParameter(cmd, INT_ID_TIPO_EMPRESA, DbType.Int32, IdTipoEmpresa);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, IdUsuario);
            db.AddInParameter(cmd, INT_ID_USUARIO_LOGUEADO, DbType.Int32, IdUsuarioLogueado);
            db.AddInParameter(cmd, INT_ID_MODO, DbType.Int32, IdModo);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, IdAplicacion);

            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                //Recorremos los resultados del stored procedure
                while (dr.Read())
                {
                    BEUsuario oBEUsuario = new BEUsuario();
                    oBEUsuario.IdUsuario = Int32.Parse(dr[ID_USUARIO].ToString());
                    oBEUsuario.CodigoUsuario = dr[CODIGO_USUARIO].ToString();
                    oBEUsuario.Nombres = dr[NOMBRES].ToString();
                    oBEUsuario.ApellidoPaterno = dr[APELLIDO_PATERNO].ToString();
                    oBEUsuario.ApellidoMaterno = dr[APELLIDO_MATERNO].ToString();
                    oBEUsuario.CorreoElectronico = dr[CORREO_ELECTRONICO].ToString();
                    oBEUsuario.PermisoUsuario = new BEPermisoUsuario();
                    oBEUsuario.PermisoUsuario.BERol = new BERol();
                    oBEUsuario.PermisoUsuario.BERol.IdRol = Int32.Parse(dr[IDROL].ToString());
                    oBEUsuario.PermisoUsuario.BERol.NombreRol = dr[NOMBREROL].ToString();
                    listaUsuario.Add(oBEUsuario);
                }
            }

            return listaUsuario;
        }
        public List<BEEmpresa> ListaClientexContratista(int IdTipoEmpresa, int IdUsuario, int IdUsuarioLogueado, int IdModo, int IdAplicacion)
        {
            List<BEEmpresa> listaEmpresa = new List<BEEmpresa>();
            DbCommand cmd = db.GetStoredProcCommand(UP_LISTA_CLIENTE_CONTRATISTA);

            db.AddInParameter(cmd, INT_ID_TIPO_EMPRESA, DbType.Int32, IdTipoEmpresa);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, IdUsuario);
            db.AddInParameter(cmd, INT_ID_USUARIO_LOGUEADO, DbType.Int32, IdUsuarioLogueado);
            db.AddInParameter(cmd, INT_ID_MODO, DbType.Int32, IdModo);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, IdAplicacion);

            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                //Recorremos los resultados del stored procedure
                while (dr.Read())
                {
                    BEEmpresa oBEEmpresa = new BEEmpresa();
                    oBEEmpresa.IdEmpresa = Int32.Parse(dr[INT_ID_EMPRESA].ToString());
                    oBEEmpresa.NomEmpresa = dr[VCH_NOMEMPRESA].ToString();
                    oBEEmpresa.Ruc = dr[RUC].ToString();
                    oBEEmpresa.BETipoEmpresa = new BETipoEmpresa();
                    oBEEmpresa.BETipoEmpresa.IdTipoEmpresa = Int32.Parse(dr[IDTIPOEMPRESA].ToString());
                    oBEEmpresa.BETipoEmpresa.NomTipoEmpresa = dr[NOMTIPOEMPRESA].ToString();
                    if (Int32.Parse(dr[ASIGNADO].ToString()) > 0)
                        oBEEmpresa.checkValor = true;
                    else
                        oBEEmpresa.checkValor = false;

                    listaEmpresa.Add(oBEEmpresa);
                }
            }

            return listaEmpresa;
        }

        public int CantidadUsuarios(String CodigoUsuario, int IdRol)
        {
            int cantidad = 0;
            DbCommand cmd = db.GetStoredProcCommand(UP_VALIDA_LIMITE_USUARIOS);

            db.AddInParameter(cmd, VCH_CODIGO_USUARIO, DbType.String, CodigoUsuario);
            db.AddInParameter(cmd, INT_ID_ROL, DbType.Int32, IdRol);
            db.AddOutParameter(cmd, INT_RESULTADO, DbType.Int32, cantidad);

            db.ExecuteNonQuery(cmd);

            cantidad = Convert.ToInt16(db.GetParameterValue(cmd, INT_RESULTADO).ToString());

            return cantidad;

        }

        #endregion
    }
}
