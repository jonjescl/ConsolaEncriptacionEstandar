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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }
        MBancos metodosBanco = new MBancos();
        MUsuarios metodosUsuario = new MUsuarios();
        FuncionesAuxiliares funcionesAuxiliares = new FuncionesAuxiliares();
        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarBancos();
            CargarUsuarios();
        }
        public void CargarBancos()
        {
            funcionesAuxiliares.llenarComboBox(cmbBanco,
                metodosBanco.listaBancos(), "banco", "id");
        }
        public void CargarUsuarios()
        {
            funcionesAuxiliares.llenarGrid(dtgUsuarios,
                metodosUsuario.listarUsuarios());
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // lógica para nuevo registro
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

        private void dtgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dtgUsuarios.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar registro?", "◄ AVISO ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        // lógica para eliminar
                    }
                    else
                    {

                    }
                }
                if (this.dtgUsuarios.Columns[e.ColumnIndex].Name == "Modificar")
                {
                    // cargar los datos a los controles para luego modificar

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // lógica para editar registro
        }
    }
}
