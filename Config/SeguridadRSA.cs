using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaEncriptacionEstandar.Config
{
    public class SeguridadRSA
    {
        readonly CspParameters _cspp = new CspParameters();
        RSACryptoServiceProvider _rsa;
       
        public string Encriptar(string cadena)
        {
            string cadenaSalida = "";
            try
            {
                string rutaClavePublica = @"" + Properties.Settings.Default.rutaclavePublica;
                string _xmlFile = new StreamReader(rutaClavePublica).ReadToEnd();
                byte[] _dataEncriptada = GenerarEncript(cadena, _xmlFile);
                cadenaSalida = Convert.ToBase64String(_dataEncriptada);
            }
            catch (Exception ex)
            {
                cadenaSalida = "ERROR";
            }

            return cadenaSalida;

        }
        public static byte[] GenerarEncript(string texto, string XMLPublico)
        {
            RSACryptoServiceProvider _RSA = new RSACryptoServiceProvider(2048);
            _RSA.FromXmlString(XMLPublico);
            byte[] dataEncriptada = _RSA.Encrypt(Encoding.ASCII.GetBytes(texto), false);
            return dataEncriptada;
        }
        public byte[] generarClavePublica(string KeyName)
        {
            _cspp.KeyContainerName = KeyName;
            _rsa = new RSACryptoServiceProvider(_cspp)
            {
                PersistKeyInCsp = true
            };
            string clavePublicaXML = this._rsa.ToXmlString(false);
            return Encoding.ASCII.GetBytes(clavePublicaXML);
        }
        public byte[] generarClavePrivada(string KeyName)
        {
            _cspp.KeyContainerName = KeyName;
            _rsa = new RSACryptoServiceProvider(_cspp)
            {
                PersistKeyInCsp = true
            };
            string clavePublicaXML = this._rsa.ToXmlString(true);
            return Encoding.ASCII.GetBytes(clavePublicaXML);
        }
        public static byte[] Desencriptar(string textoEncrptado, string XMLPrivado)
        {
            RSACryptoServiceProvider _RSA = new RSACryptoServiceProvider(2048);
            _RSA.FromXmlString(XMLPrivado);
            byte[] dataDesencriptada = _RSA.Decrypt(Convert.FromBase64String(textoEncrptado), false);
            return dataDesencriptada;

        }
    }
}
