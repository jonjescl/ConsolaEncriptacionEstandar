using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsolaEncriptacionEstandar.Config
{
    public class FuncionesAuxiliares
    {

        ConexionSQLCommand conn = new ConexionSQLCommand();
        public void llenarGrid(DataGridView dtg, DataTable dt)
        {
            dtg.Columns.Clear();
            if (dt.Rows.Count>0)
            {
               
                var newdt = new DataTable();
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    newdt.Columns.Add(dt.Columns[i].ColumnName.ToUpper());
                }

                foreach (DataRow row in dt.Rows)
                {

                    newdt.Rows.Add(row.ItemArray);
                }
                dtg.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
                dtg.DataSource = newdt;
                dtg.Columns[0].Visible = false;
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "Modificar";
                btn.HeaderText = "";
                btn.UseColumnTextForButtonValue = true;
                dtg.Columns.Add(btn);
                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                btn2.Name = "Eliminar";
                btn2.HeaderText = "";
                btn2.UseColumnTextForButtonValue = true;
                dtg.Columns.Add(btn2);
                dtg.FirstDisplayedScrollingRowIndex = dtg.SelectedRows[0].Index;
            }
           

        }

        public void llenarComboBox(ComboBox cmb,DataTable dt, string DisplayMember, string ValueMember)
        {
            cmb.DataSource = dt;
            cmb.DisplayMember = DisplayMember;
            cmb.ValueMember = ValueMember;
        }

        public void GeberarLog(string mensaje)
        {
           
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros() { nombre = "mensaje", valor = mensaje });
            conn.GenerarLog(parametros);
        }
   
    
    }
}
