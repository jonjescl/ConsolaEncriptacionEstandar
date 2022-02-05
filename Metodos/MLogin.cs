using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolaEncriptacionEstandar.Config;

namespace ConsolaEncriptacionEstandar.Metodos
{
    public class MLogin
    {
        ConexionSQLCommand conn = new ConexionSQLCommand();
        public int GetUserTipo(string usuario)
        {
            int r = 0;
           
            try
            {
                //lista de parametros
                List<Parametros> parametros = new List<Parametros>();

                // añadimos parámetro(s)
                parametros.Add(new Parametros() { nombre = "user", valor= usuario });
               
                string query = "SELECT a.tipo FROM tbacceso as a where usuario=@user and a.activo = 1";
                //DataTable res =conn.SqlListar(query,parametros);
                var res = conn.SqlListar(query, parametros).Rows[0].ItemArray[0];
                if (res==null)
                {
                    r = 0;
                }
                else
                {
                    r = Convert.ToInt32(res);
                }
            }
            catch (Exception)
            {
                r = 0;
            }
            return r;
        }
        public string GetUser(string usuario)
        {
            string r = "";
            try
            {
                //lista de parametros
                List<Parametros> parametros = new List<Parametros>();

                // añadimos parámetro(s)
                parametros.Add(new Parametros() { nombre = "user", valor = usuario });

                string query = " SELECT a.clave FROM tbacceso as a where usuario=@user and a.activo = 1";
                //DataTable res =conn.SqlListar(query,parametros);
                var res = conn.SqlListar(query, parametros).Rows[0].ItemArray[0];
                if (res == null)
                {
                    r = "";
                }
                else
                {
                    r = res.ToString();
                }
            }
            catch (Exception ex)
            {
                r = "";

            }
            return r;
        }

      
    }
}
