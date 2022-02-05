using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsolaEncriptacionEstandar.Metodos;
using ConsolaEncriptacionEstandar.Config;

namespace ConsolaEncriptacionEstandar
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        MLogin metodosLogin = new MLogin();
        SeguridadAES seguridadAES = new SeguridadAES();
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string res1 = metodosLogin.GetUser(txtUsuario.Text);
            if (res1 == "")
            {
                if (txtUsuario.Text == "Gaia_Admin")
                {
                    if (txtClave.Text == "*Gaia2022!")
                    {
                        this.Hide();
                        //InicioGaia frm = new InicioGaia();
                        //frm.ShowDialog();
                        Inicio frm = new Inicio();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Clave incorrecta");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario incorrecto");
                }
            }
            else
            {
                string cadenaDesenc = seguridadAES.Desencriptar(res1);
                if (cadenaDesenc == txtClave.Text)
                {
                    int res2 = metodosLogin.GetUserTipo(txtUsuario.Text);
                    if (res2 == 1)
                    {
                        this.Hide();
                        Inicio frm = new Inicio();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else if (res2 == 2 || res2 == 3)
                    {

                        this.Hide();
                        Inicio frm = new Inicio();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al conectarse con el servidor");
                    }

                }
                else
                {
                    MessageBox.Show("Clave incorrecta");
                }
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
