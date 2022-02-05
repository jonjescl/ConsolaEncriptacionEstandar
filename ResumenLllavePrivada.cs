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
    public partial class ResumenLllavePrivada : Form
    {
        public ResumenLllavePrivada()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResumenLllavePrivada_Load(object sender, EventArgs e)
        {

            txtD.Text = GenerarLlaves.D;
            txtModulo.Text = GenerarLlaves.Modulo;
            txtExponente.Text = GenerarLlaves.Exponente;
        }

        private void txtModulo_Click(object sender, EventArgs e)
        {
            txtModulo.SelectAll();
        }

        private void txtD_Click(object sender, EventArgs e)
        {
            txtD.SelectAll();
        }

        private void txtExponente_Click(object sender, EventArgs e)
        {
            txtExponente.SelectAll();
        }
    }
}
