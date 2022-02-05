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
    public partial class Bancos : Form
    {
        public Bancos()
        {
            InitializeComponent();
        }
        FuncionesAuxiliares funcionesAuxiliares = new FuncionesAuxiliares();
        MBancos metodosBanco = new MBancos();
        private void Bancos_Load(object sender, EventArgs e)
        {
            CargarBancos();
        }
        public void CargarBancos()
        {
            funcionesAuxiliares.llenarGrid(dtgBancos,
                metodosBanco.listaBancos());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // lógica para nuevo registro
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // lógica para editar registro
        }

        private void dtgBancos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dtgBancos.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar registro?", "◄ AVISO ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        // lógica para eliminar
                    }
                    else
                    {

                    }
                }
                if (this.dtgBancos.Columns[e.ColumnIndex].Name == "Modificar")
                {
                    // cargar los datos a los controles para luego modificar

                }
            }
            catch (Exception ex)
            {

                
            }
          
        }

        private void dtgBancos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgBancos.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgBancos.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\delete.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgBancos.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dtgBancos.Columns[e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;

            }
            if (e.ColumnIndex >= 0 && this.dtgBancos.Columns[e.ColumnIndex].Name == "Modificar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgBancos.Rows[e.RowIndex].Cells["Modificar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\edit.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgBancos.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dtgBancos.Columns[e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;

            }

        }
    }
}
