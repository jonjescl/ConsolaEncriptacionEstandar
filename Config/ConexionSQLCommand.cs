using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsolaEncriptacionEstandar.Config
{
    public class ConexionSQLCommand
    {
        
        public DataTable SqlListar(string sql, List<Parametros> lista)
        {
            DataTable dataTable = new DataTable();
            int motor = Properties.Settings.Default.motorSQL;
            //Sqlite
            if (motor== 1)
            {
                SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.cadenaConexion); 
                conn.Open();
                try
                {

                    SQLiteCommand conector = new SQLiteCommand(sql, conn);

                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    SQLiteDataReader dr = conector.ExecuteReader();

                    //DataTable _Table = dr.GetSchemaTable();

                    dataTable.Load(dr);

                    //foreach (DataRow row in dataTable.Rows)
                    //{
                    //    string dt = row[0].ToString();

                    //}
                    //foreach (DataRow row in schemaTable.Rows)
                    //{
                    //    foreach (DataColumn column in schemaTable.Columns)
                    //    {
                    //        string x = column.ColumnName;
                    //        object a = row[column];
                    //    }
                    //}
                    // while (dr.Read())
                    //{

                    //// Get the Row with all its column values..
                    //dr.GetValues(values);

                    //// Add this Row to ArrayList.
                    //al.Add(values);
                    // }
                    //while (dr.Read())

                    //{
                    //    int r = int.Parse(dr[0].ToString());
                    //}
                }
                catch (Exception ex)
                {
                    dataTable = new DataTable();

                }
                conn.Close();
            }
            //PGSQL
            else if (motor == 2)
            {
                NpgsqlConnection conn = new NpgsqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                    NpgsqlCommand conector = new NpgsqlCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    NpgsqlDataReader dr = conector.ExecuteReader();
                    
                    //DataTable _Table = dr.GetSchemaTable();

                    dataTable.Load(dr);
                }
                catch (Exception ex)
                {

                    dataTable = new DataTable();
                }
                conn.Close();
            }
            // SQL server
            else if (motor==3)
            {

                SqlConnection conn = new SqlConnection(@""+Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {

                    SqlCommand conector = new SqlCommand(sql, conn);

                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }

                    SqlDataReader dr = conector.ExecuteReader();
                    dataTable.Load(dr);

                }
                catch (Exception ex)
                {
                    dataTable = new DataTable();

                }
                conn.Close();
            }
            else
            {
                dataTable = new DataTable();
            }
            return dataTable;
        }

        public int SqlInsert(string sql, List<Parametros> lista)
        {
            int motor = Properties.Settings.Default.motorSQL;
            int r = 2;
            //Sqlite
            if (motor == 1)
            {
                
                SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                    SQLiteCommand conector = new SQLiteCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                  
                    SQLiteDataReader dr = conector.ExecuteReader();
                    r = 1;
                }
                catch (Exception ex)
                {
                    r = 2;

                }
                conn.Close();
            }
            //PGSQL
            else if (motor == 2)
            {
                NpgsqlConnection conn = new NpgsqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                   
                    NpgsqlCommand conector = new NpgsqlCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    NpgsqlDataReader dr = conector.ExecuteReader();
                    r = 1;
                }
                catch (Exception ex)
                {

                    r = 2;
                }
                conn.Close();
            }
            // SQL Server
            else if (motor==3)
            {

                SqlConnection conn = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {

                    SqlCommand conector = new SqlCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }

                    SqlDataReader dr = conector.ExecuteReader();
                    r = 1;
                }
                catch (Exception ex)
                {

                    r = 2;
                }
                conn.Close();
            }
            else
            {
                r = 2;
            }
            return r;
        }

        public int SqlInsertScalar(string sql, List<Parametros> lista)
        {
            int motor = Properties.Settings.Default.motorSQL;
            int r = 0;
            //Sqlite
            if (motor == 1)
            {

                SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                    sql += "; select last_insert_rowid();";
                    SQLiteCommand conector = new SQLiteCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    var res = conector.ExecuteScalar();
                    r = int.Parse(res.ToString());
                }
                catch (Exception ex)
                {
                    r = 0;

                }
                conn.Close();
            }
            //PGSQL
            else if (motor == 2)
            {
                NpgsqlConnection conn = new NpgsqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                    sql += "   RETURNING id;";
                    NpgsqlCommand conector = new NpgsqlCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    var resPG = conector.ExecuteScalar();
                    r = int.Parse(resPG.ToString());
                }
                catch (Exception ex)
                {

                    r = 0;
                }
                conn.Close();
            }
            // SQL Server
            else if (motor==3)
            {

                SqlConnection conn = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                    sql += "  SELECT SCOPE_IDENTITY()";

                    SqlCommand conector = new SqlCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    var resSQL = conector.ExecuteScalar();
                    r = int.Parse(resSQL.ToString());
                }
                catch (Exception ex)
                {

                    r = 0;
                }
                conn.Close();
            }
            else
            {
                r = 0;
            }
            return r;
        }
        public int SqlModify(string sql, List<Parametros> lista)
        {
            int motor = Properties.Settings.Default.motorSQL;
            int r = 0;
            //Sqlite
            if (motor==1)
            {
                
                SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                    SQLiteCommand conector = new SQLiteCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    SQLiteDataReader dr = conector.ExecuteReader();
                    r = 1;
                }
                catch (Exception ex)
                {
                    r = 2;

                }
                conn.Close();

            }
            //PGSQL
            else if (motor==2)
            {
                NpgsqlConnection conn = new NpgsqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {

                    NpgsqlCommand conector = new NpgsqlCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    NpgsqlDataReader dr = conector.ExecuteReader();
                    r = 1;
                }
                catch (Exception ex)
                {

                    r = 2;
                }
                conn.Close();
            }
            // SQL Server
            else if (motor == 3)
            {

                SqlConnection conn = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {

                    SqlCommand conector = new SqlCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }

                    SqlDataReader dr = conector.ExecuteReader();
                    r = 1;
                }
                catch (Exception ex)
                {

                    r = 2;
                }
                conn.Close();
            }
            else
            {
                r=2;
            }

            return r;
        }

        public int SqlDelete(string sql, List<Parametros> lista)
        {
            int motor = Properties.Settings.Default.motorSQL;
            int r = 0;
            //Sqlite
            if (motor == 1)
            {
               
                SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                    SQLiteCommand conector = new SQLiteCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    SQLiteDataReader dr = conector.ExecuteReader();
                    r = 1;
                }
                catch (Exception ex)
                {
                    r = 2;

                }
                conn.Close();

            }
            //PGSQL
            else if (motor == 2)
            {
                NpgsqlConnection conn = new NpgsqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {

                    NpgsqlCommand conector = new NpgsqlCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    NpgsqlDataReader dr = conector.ExecuteReader();
                    r = 1;
                }
                catch (Exception ex)
                {

                    r = 2;
                }
                conn.Close();
            }
            // SQL Server
            else if (motor == 3)
            {

                SqlConnection conn = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {

                    SqlCommand conector = new SqlCommand(sql, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }

                    SqlDataReader dr = conector.ExecuteReader();
                    r = 1;
                }
                catch (Exception ex)
                {

                    r = 2;
                }
                conn.Close();
            }
            else
            {
                r = 2;
            }
            return r;
        }
       
        public void GenerarLog(List<Parametros> lista)
        {
            int motor = Properties.Settings.Default.motorSQL;
          
            //Sqlite
            if (motor == 1)
            {

                SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                    string fecha = DateTime.Now.ToString();
                    string query = "INSERT INTO tblogconsola (mensaje,fecha)";
                    query += " VALUES (@mensaje,@fecha)";
                   
                    SQLiteCommand conector = new SQLiteCommand(query, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    conector.Parameters.AddWithValue("fecha", fecha);
                    SQLiteDataReader dr = conector.ExecuteReader();
                   
                }
                catch (Exception ex)
                {
                   

                }
                conn.Close();

            }
            //PGSQL
            else if (motor == 2)
            {

                NpgsqlConnection conn = new NpgsqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                    string fecha = DateTime.Now.ToString();
                    string query = "INSERT INTO tblogconsola (mensaje,fecha)";
                    query += " VALUES (@mensaje,@fecha)";

                    NpgsqlCommand conector = new NpgsqlCommand(query, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    conector.Parameters.AddWithValue("fecha", fecha);
                    NpgsqlDataReader dr = conector.ExecuteReader();

                }
                catch (Exception ex)
                {


                }
                conn.Close();
            }
            // SQL Server
            else if (motor==3)
            {

                SqlConnection conn = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                conn.Open();
                try
                {
                    string fecha = DateTime.Now.ToString();
                    string query = "INSERT INTO tblogconsola (mensaje,fecha)";
                    query += " VALUES (@mensaje,@fecha)";

                    SqlCommand conector = new SqlCommand(query, conn);
                    foreach (var item in lista)
                    {
                        conector.Parameters.AddWithValue(item.nombre, item.valor);
                    }
                    conector.Parameters.AddWithValue("fecha", fecha);
                    SqlDataReader dr = conector.ExecuteReader();
                    
                }
                catch (Exception ex)
                {


                }
                conn.Close();
            }

            
        }
    }
}
