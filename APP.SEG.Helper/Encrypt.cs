﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace APP.SEG.Helper
{
    public class Encrypt
    {
        #region "Métodos"
        /// <summary>
        /// Función que encripta una cadena (string)
        /// Fecha de Creación: [27/04/2011] Synopsis
        /// Modificaciones: Ninguna
        /// </summary>
        /// <param name="cadenaEntrada">cadena que se desea encriptar</param>
        /// <returns>cadena encriptada</returns>
        public static String EncriptarContrasenha(String cadenaEntrada)
        {
            CryptographyManager crypto = EnterpriseLibraryContainer.Current.GetInstance<CryptographyManager>();
            return crypto.EncryptSymmetric(Constantes.SYMMPROVIDER, cadenaEntrada);
        }

        /// <summary>
        /// Función que encripta una cadena (string)
        /// Fecha de Creación: [27/04/2011] Synopsis
        /// Modificaciones: Ninguna
        /// </summary>
        /// <param name="cadenaEntrada">cadena que se desea desencriptar ; la cadena desencriptada debe estar encriptada desde la pc de Desarrollo
        /// Se puede encriptar de nuevo utilizando UTIL/Encriptar.aspx
        /// </param>
        /// <returns>cadena desencriptada</returns>
        public static String DesencriptarContrasenha(String cadenaEntrada)
        {
            CryptographyManager crypto = EnterpriseLibraryContainer.Current.GetInstance<CryptographyManager>();
            return crypto.DecryptSymmetric(Constantes.SYMMPROVIDER, cadenaEntrada);
        }

        #endregion
    }
}
