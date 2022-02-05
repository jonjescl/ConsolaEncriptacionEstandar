using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsolaEncriptacionEstandar
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

      
        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void btnUsuariosConsola_Click(object sender, EventArgs e)
        {
            UsuariosConsola frmUsuariosConsola = new UsuariosConsola();
            frmUsuariosConsola.ShowDialog();
        }

        private void btnBancos_Click(object sender, EventArgs e)
        {
            Bancos frmBancos = new Bancos();
            frmBancos.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios frmUsuarios = new Usuarios();
            frmUsuarios.ShowDialog();
        }

        private void btnSociedades_Click(object sender, EventArgs e)
        {
            Sociedades frmSociedades = new Sociedades();
            frmSociedades.ShowDialog();
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            Cuentas frmCuentas = new Cuentas();
            frmCuentas.ShowDialog();
        }

        private void btnSociedadCuenta_Click(object sender, EventArgs e)
        {
            Sociedades_Cuentas frmSociedades = new Sociedades_Cuentas();
            frmSociedades.ShowDialog();
        }

        private void btnPreguntasSeguridad_Click(object sender, EventArgs e)
        {
            PreguntasSeguridad frmPreguntas = new PreguntasSeguridad();
            frmPreguntas.ShowDialog();
        }

        private void btnGenerarllavesRSA_Click(object sender, EventArgs e)
        {
            GenerarLlaves frmGenerarllaves = new GenerarLlaves();
            frmGenerarllaves.ShowDialog();
        }
    }
}
