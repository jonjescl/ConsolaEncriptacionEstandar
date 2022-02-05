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
    public partial class Sociedades_Cuentas : Form
    {
        public Sociedades_Cuentas()
        {
            InitializeComponent();
        }
        FuncionesAuxiliares funcionesAuxiliares = new FuncionesAuxiliares();
        MSociedadesCuentas metodosSociedadCuenta = new MSociedadesCuentas();
        private void Sociedades_Cuentas_Load(object sender, EventArgs e)
        {
            //cargar combos y tabla
            //CargarTaba();
            //CargarCombo();
        }
        public void CargarTaba()
        {
            ////**** EJEMPLO ****////
            //funcionesAuxiliares.llenarGrid(dtgSociedadC,
            //    metodosSociedadCuenta.listar());
           
        }
        public void CargarCombo()
        {
            ////**** EJEMPLO ****////
            //funcionesAuxiliares.llenarComboBox(cmbBanco,
            //    metodosBanco.listaBancos(), "banco", "id");

        }
        private void dtgSociedadC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dtgSociedadC.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar registro?", "◄ AVISO ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        // lógica para eliminar
                    }
                    else
                    {

                    }
                }
                if (this.dtgSociedadC.Columns[e.ColumnIndex].Name == "Modificar")
                {
                    // cargar los datos a los controles para luego modificar

                }
            }
            catch (Exception ex)
            {

               
            }
           
        }

        private void dtgSociedadC_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgSociedadC.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgSociedadC.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\delete.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgSociedadC.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dtgSociedadC.Columns[e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;

            }
            if (e.ColumnIndex >= 0 && this.dtgSociedadC.Columns[e.ColumnIndex].Name == "Modificar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgSociedadC.Rows[e.RowIndex].Cells["Modificar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\edit.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgSociedadC.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dtgSociedadC.Columns[e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;

            }

        }

        private void btnNuevaSoc_Click(object sender, EventArgs e)
        {
            Sociedades frmSociedades = new Sociedades();
            frmSociedades.ShowDialog();
        }

        private void btnNuevaC_Click(object sender, EventArgs e)
        {
            Cuentas frmCuentas = new Cuentas();
            frmCuentas.ShowDialog();
        }
    }
}
