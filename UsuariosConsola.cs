using ConsolaEncriptacionEstandar.Clases;
using ConsolaEncriptacionEstandar.Config;
using ConsolaEncriptacionEstandar.Metodos;
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
    public partial class UsuariosConsola : Form
    {
        public UsuariosConsola()
        {
            InitializeComponent();
        }

        private void UsuariosConsola_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
            CargarTipos();
        }
        MUsuariosConsola metodosUsuarios = new MUsuariosConsola();
        SeguridadAES seguridadAES = new SeguridadAES();
        FuncionesAuxiliares funcionesAuxiliares = new FuncionesAuxiliares();
       
        public void cargarUsuarios()
        {
            var dt = metodosUsuarios.listarUsuariosConsola();
            funcionesAuxiliares.llenarGrid(dtgUsuarios, dt);
        }
        public void CargarTipos()
        {
            List<CTiposUsuario> lista = new List<CTiposUsuario>();

            lista.Add(new CTiposUsuario() { id = 0, tipo = "SELECCIONE UN TIPO..." });
            lista.Add(new CTiposUsuario() { id = 1, tipo = "Gaia" });
            lista.Add(new CTiposUsuario() { id = 2, tipo = "Administrador" });
            lista.Add(new CTiposUsuario() { id = 3, tipo = "Usuario Experto" });
            cmbTipo.DataSource = lista;
            cmbTipo.DisplayMember = "tipo";
            cmbTipo.ValueMember = "id";
        }
      

        public void DesabilitarUsuario(int _id)
        {
            int res = metodosUsuarios.Desabilitar_InicioSesion(_id);
            if (res == 1)
            {
                MessageBox.Show("Usuario desabilitado exitosamete!");
                cargarUsuarios();
            }
            else
            {
                MessageBox.Show("Error al conectarse con el servidor");
            }
        }
        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            string cadenaEncriptada;
            string _clave1 = txtClave.Text;
            string _clave2 = txtRepetir.Text;
            string _user = txtUsuario.Text.Trim();
            int _idTipo = int.Parse(cmbTipo.SelectedValue.ToString());
            if (_idTipo == 0 || _user == string.Empty || _clave1 == "" || _clave2 == "" || _clave1 == " " || _clave2 == " ")
            {
                MessageBox.Show("Por favor rellene todos los campos");
            }
            else
            {
                if (_clave1 == _clave2)
                {
                    cadenaEncriptada = seguridadAES.Encriptar(_clave1);
                    if (cadenaEncriptada == "ERROR")
                    {
                        MessageBox.Show("Ha ocurrido un error al encriptar contraseña");
                    }
                    else
                    {
                       
                        int res = metodosUsuarios.Registrar_InicioSesion(_user, cadenaEncriptada, _idTipo);
                        if (res == 1)
                        {
                            MessageBox.Show("Usuario registrado exitosamete!");
                            txtUsuario.Clear();
                            txtClave.Clear();
                            txtRepetir.Clear();
                            cargarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Error al conectarse con el servidor");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }

            }
        }

      
        private void btnEditar_Click(object sender, EventArgs e)
        {
            string cadenaEncriptada;
            string _clave1 = txtClave.Text;
            string _clave2 = txtRepetir.Text;
            string _user = txtUsuario.Text.Trim();
            int _idTipo = int.Parse(cmbTipo.SelectedValue.ToString());
            int _id = int.Parse(lblID.Text);
            if (_idTipo == 0 || _user == string.Empty || _clave1 == "" || _clave2 == "" || _clave1 == " " || _clave2 == " ")
            {
                MessageBox.Show("Por favor rellene todos los campos");
            }
            else
            {
                if (_clave1 == _clave2)
                {
                    cadenaEncriptada = seguridadAES.Encriptar(_clave1);
                    if (cadenaEncriptada == "ERROR")
                    {
                        MessageBox.Show("Ha ocurrido un error al encriptar contraseña");
                    }
                    else
                    {

                        int res = metodosUsuarios.Modificar_InicioSesion(_id, _user, cadenaEncriptada, _idTipo);
                        if (res == 1)
                        {
                            MessageBox.Show("Usuario modificado exitosamete!");
                            txtUsuario.Clear();
                            txtClave.Clear();
                            txtRepetir.Clear();
                            cargarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Error al conectarse con el servidor");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }

            }
        }

        private void dtgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dtgUsuarios.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (MessageBox.Show("Esta seguro que desea desanilitar usuario", "◄ AVISO ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        int id = int.Parse(dtgUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                        DesabilitarUsuario(id);
                    }
                    else
                    {

                    }
                }
                if (this.dtgUsuarios.Columns[e.ColumnIndex].Name == "Modificar")
                {
                    try
                    {
                        string claveDesencriptada = seguridadAES.Desencriptar(dtgUsuarios.SelectedRows[0].Cells[2].Value.ToString());
                        if (claveDesencriptada == "ERROR")
                        {
                            MessageBox.Show("Ha ocurrido un error al desencriptar clave");
                        }
                        else
                        {
                            int id = int.Parse(dtgUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                            lblID.Text = id.ToString();
                            txtUsuario.Text = dtgUsuarios.SelectedRows[0].Cells[1].Value.ToString();
                            txtClave.Text = claveDesencriptada;
                            txtRepetir.Text = claveDesencriptada;
                            cmbTipo.SelectedValue = int.Parse(dtgUsuarios.SelectedRows[0].Cells[4].Value.ToString()); ;
                            //cargarUsuarios();
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se pudo seleccionar usuario");
                    }
                }
            }
            catch (Exception ex)
            {

                
            }
         
        }

        private void dtgUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgUsuarios.Columns[e.ColumnIndex].Index == 2 && e.Value != null)
            {
                dtgUsuarios.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void dtgUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgUsuarios.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgUsuarios.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\delete.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgUsuarios.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dtgUsuarios.Columns[e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;

            }
            if (e.ColumnIndex >= 0 && this.dtgUsuarios.Columns[e.ColumnIndex].Name == "Modificar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgUsuarios.Rows[e.RowIndex].Cells["Modificar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\edit.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgUsuarios.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dtgUsuarios.Columns[e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;

            }
        }
   

    }
}
