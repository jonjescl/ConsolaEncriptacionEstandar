using ConsolaEncriptacionEstandar.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaEncriptacionEstandar.Metodos
{
    public class MUsuariosConsola
    {

        ConexionSQLCommand conn = new ConexionSQLCommand();
        public DataTable listarUsuariosConsola()
        {
            //lista de parametros
            List<Parametros> parametros = new List<Parametros>();
            string query = "SELECT id, usuario,clave,activo,tipo FROM tbacceso WHERE activo=1";
            DataTable data = conn.SqlListar(query, parametros);
            return data;

        }

        public int Registrar_InicioSesion(string usuario, string clave, int tipo)
        {
            int r = 0;
           
            try
            {
                //lista de parametros
                List<Parametros> parametros = new List<Parametros>();
                parametros.Add(new Parametros() { nombre = "usuario", valor = usuario });
                parametros.Add(new Parametros() { nombre = "clave", valor = clave });
                parametros.Add(new Parametros() { nombre = "tipo", valor = tipo });
                parametros.Add(new Parametros() { nombre = "activo", valor = 1 });

                string query = "INSERT INTO tbacceso (usuario,clave,tipo,activo)";
                query += " VALUES (@usuario,@clave,@tipo,@activo)";
                r= conn.SqlInsertScalar(query, parametros);
                if (r==0)
                {
                    r = 2;
                }
                else
                {
                    r = 1;
                }

              
            }
            catch (Exception ex)
            {
                r = 2;

            }
            return r;
        }
        public int Modificar_InicioSesion(int id,string usuario, string clave, int tipo)
        {
            int r = 0;

            try
            {
                //lista de parametros
                List<Parametros> parametros = new List<Parametros>();
                parametros.Add(new Parametros() { nombre = "usuario", valor = usuario });
                parametros.Add(new Parametros() { nombre = "clave", valor = clave });
                parametros.Add(new Parametros() { nombre = "tipo", valor = tipo });
                parametros.Add(new Parametros() { nombre = "activo", valor = 1 });
                parametros.Add(new Parametros() { nombre = "id", valor = id });

                string query = "UPDATE tbacceso SET usuario=@usuario,clave=@clave,tipo=@tipo,activo=@activo ";
                query += " WHERE id=@id";
                r = conn.SqlModify(query, parametros);
              


            }
            catch (Exception ex)
            {
                r = 2;

            }


            return r;
        }

        public int Desabilitar_InicioSesion(int id)
        {
            int r = 0;

            try
            {
                //lista de parametros
                List<Parametros> parametros = new List<Parametros>();
             
                parametros.Add(new Parametros() { nombre = "id", valor = id });

                string query = "UPDATE tbacceso SET activo = 2 ";
                query += " WHERE id=@id";
                r = conn.SqlModify(query, parametros);
            }
            catch (Exception ex)
            {
                r = 2;
            }
            return r;
        }
    }
}
