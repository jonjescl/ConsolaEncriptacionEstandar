using ConsolaEncriptacionEstandar.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ConsolaEncriptacionEstandar
{
    public partial class GenerarLlaves : Form
    {
        public GenerarLlaves()
        {
            InitializeComponent();
        }
        public static string Modulo;
        public static string Exponente;
        public static string D;

        SeguridadRSA seguridadRSA = new SeguridadRSA();
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string _clave = txtclave.Text.Trim();
            if (_clave == string.Empty)
            {
                MessageBox.Show("Por favor rellene el campo contraseña");
            }
            else
            {

                FolderBrowserDialog _browser = new FolderBrowserDialog();
                if (_browser.ShowDialog() == DialogResult.OK)
                {
                    string carpeta = _browser.SelectedPath;
                    string carpetaDefault = "";
                    carpetaDefault = Path.GetDirectoryName(@"" + Properties.Settings.Default.rutaclavePublica);
                    FileStream _filestream = new FileStream(Path.Combine(carpetaDefault, "PublicKey.xml"), FileMode.Create, FileAccess.Write);
                    //byte[] _publicBytes = _mrsa.CrearClavePublica();
                    byte[] _publicBytes = seguridadRSA.generarClavePublica(_clave);
                    _filestream.Write(_publicBytes, 0, _publicBytes.Length);
                    _filestream.Close();

                    _filestream = new FileStream(Path.Combine(carpeta, "PrivateKey.xml"), FileMode.Create, FileAccess.Write);
                    //byte[] _pribateBytes = _mrsa.CrearClavePrivada();
                    byte[] _pribateBytes = seguridadRSA.generarClavePrivada(_clave);
                    _filestream.Write(_pribateBytes, 0, _pribateBytes.Length);
                    string ruta_generada = _filestream.Name;
                    _filestream.Close();
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(ruta_generada);

                    XmlNodeList xMod = xDoc.GetElementsByTagName("Modulus");
                    XmlNodeList xExp = xDoc.GetElementsByTagName("Exponent");
                    XmlNodeList xD = xDoc.GetElementsByTagName("D");
                    string _mod = "";
                    string _exp = "";
                    string _d = "";
                    foreach (XmlElement nodo in xMod)
                    {
                        _mod = nodo.InnerText;
                    }
                    foreach (XmlElement nodo in xExp)
                    {
                        _exp = nodo.InnerText;
                    }
                    foreach (XmlElement nodo in xD)
                    {
                        _d = nodo.InnerText;
                    }
                    Modulo = _mod;
                    Exponente = _exp;
                    D = _d;
                    MessageBox.Show("Llaves generadas exitosamente!");   
                    ResumenLllavePrivada _frmR = new ResumenLllavePrivada();
                    _frmR.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
