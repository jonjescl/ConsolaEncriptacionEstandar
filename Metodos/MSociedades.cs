using ConsolaEncriptacionEstandar.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaEncriptacionEstandar.Metodos
{
    public class MSociedades
    {
        ConexionSQLCommand conn = new ConexionSQLCommand();
        ////**** EJEMPLO INSERT ****////
        //public int Registrar(string campo1, string campo2...)
        //{
        //int r = 0;
        //try
        //{
        ////lista de parametros
        //List<Parametros> parametros = new List<Parametros>();
        //parametros.Add(new Parametros() { nombre = "value1", valor = value1 });
        //parametros.Add(new Parametros() { nombre = "value2", valor = value2 });


        //string query = "INSERT INTO tabla (value1,value2)";
        //query += " VALUES (@value1,@value2)";

        //// tiene dos opciones:

        ////* 1: SqlInsertScalar devuelve el id autogenerado
        ////r = conn.SqlInsertScalar(query, parametros);
        ////if (r == 0)
        ////{
        ////    r = 2;
        ////}
        ////else
        ////{
        ////    r = 1;
        ////}

        ////* 2: SqlInsert devuelve 1 si se ingreso y 2 si da error
        ////r = conn.SqlInsert(query, parametros);


        //}
        //catch (Exception ex)
        //{
        //    r = 2;

        //}
        //return r;
        //}

        ////**** EJEMPLO UPDATE ****////
        //public int Modificar_InicioSesion(int id, string value1, string cvalue2)
        //{
        //    int r = 0;

        //    try
        //    {
        //        ////lista de parametros
        //        //List<Parametros> parametros = new List<Parametros>();
        //        //parametros.Add(new Parametros() { nombre = "value1", valor = value1 });
        //        //parametros.Add(new Parametros() { nombre = "value2", valor = value2 });
        //        //parametros.Add(new Parametros() { nombre = "id", valor = id });
        //        //string query = "UPDATE tabla SET value1=@value1,value2=@value2 ";
        //        //query += " WHERE id=@id";
        //        //r = conn.SqlModify(query, parametros);
        //        //// r retorna 1 si esta ok y 2 si da error


        //    }
        //    catch (Exception ex)
        //    {
        //        r = 2;

        //    }


        //    return r;
        //}


        ////**** EJEMPLO SELECT ****////
        //public DataTable listar()
        //{
        //    ////lista de parametros
        //    List<Parametros> parametros = new List<Parametros>();
        //    string query = "SELECT value1,value2 FROM tabla";
        //    DataTable data = conn.SqlListar(query, parametros);
        //    return data;
        //    ////retorna datatable

        //}
    }
}
