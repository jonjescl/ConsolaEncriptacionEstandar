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
    public partial class PreguntasSeguridad : Form
    {
        public PreguntasSeguridad()
        {
            InitializeComponent();
        }
        FuncionesAuxiliares funcionesAuxiliares = new FuncionesAuxiliares();
        MPreguntasSeguridad metodosPreguntas = new MPreguntasSeguridad();
        private void PreguntasSeguridad_Load(object sender, EventArgs e)
        {
            //cargar combos y tabla
            //CargarTaba();
            //CargarCombo();
        }
        public void CargarTaba()
        {
            ////**** EJEMPLO ****////
            //funcionesAuxiliares.llenarGrid(dtgPreguntas,
            //    metodosPreguntas.listar());

        }
        public void CargarCombo()
        {
            ////**** EJEMPLO ****////
            //funcionesAuxiliares.llenarComboBox(cmbBanco,
            //    metodosBanco.listaBancos(), "banco", "id");

        }
        private void dtgPreguntas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dtgPreguntas.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar registro?", "◄ AVISO ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        // lógica para eliminar
                    }
                    else
                    {

                    }
                }
                if (this.dtgPreguntas.Columns[e.ColumnIndex].Name == "Modificar")
                {
                    // cargar los datos a los controles para luego modificar

                }
            }
            catch (Exception ex)
            {

                
            }
           
        }

        private void dtgPreguntas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgPreguntas.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgPreguntas.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\delete.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgPreguntas.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dtgPreguntas.Columns[e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;

            }
            if (e.ColumnIndex >= 0 && this.dtgPreguntas.Columns[e.ColumnIndex].Name == "Modificar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgPreguntas.Rows[e.RowIndex].Cells["Modificar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\edit.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgPreguntas.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dtgPreguntas.Columns[e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;

            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // lógica para nuevo registro
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // lógica para editar registro
        }
    }
}
