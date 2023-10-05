using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace BusquedaAlumno.Models
{
    public class ClaseProfesor
    {
        public string NumeroEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int IdCongreso { get; set; }
        public string NumeroEmpleado_IdCongreso { get; set; }
        public string ImagenUrl { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }



        public string GuardarLista(int idCongreso,string[] listaNombres)
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command=new SqlCommand("spGuardarLista",conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@IdCongreso",""));
            command.Parameters.Add(new SqlParameter("@Nombre",""));
            try
            {
                conx.Open();

                foreach(string nombre in listaNombres)
                {
                    command.Parameters["@IdCongreso"].Value = idCongreso;
                    command.Parameters["@Nombre"].Value = nombre.ToUpper().Trim();
                    command.ExecuteNonQuery();
                }


                conx.Close();
            }
            catch(Exception error) {
                respuesta=error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }


        public string Guardar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarProfesorConstancia", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NumeroEmpleado", NumeroEmpleado);
            command.Parameters.AddWithValue("@Nombre", Nombre.ToUpper().Trim());
            if (Carrera == null)
            {
                Carrera = string.Empty;
            }
            command.Parameters.AddWithValue("@Carrera", Carrera.ToUpper().Trim());
            if (Telefono == null)
            {
                Telefono = string.Empty;
            }
            command.Parameters.AddWithValue("@Telefono", Telefono);
            if (Correo == null)
            {
                Correo = string.Empty;
            }
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@IdCongreso", IdCongreso);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch(Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        public string Modificar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spModificarProfesorConstancia", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NumeroEmpleado", NumeroEmpleado);
            command.Parameters.AddWithValue("@Nombre", Nombre.ToUpper().Trim());
            if (Carrera == null)
            {
                Carrera = string.Empty;
            }
            command.Parameters.AddWithValue("@Carrera", Carrera.ToUpper().Trim());
            if (Telefono == null)
            {
                Telefono = string.Empty;
            }
            command.Parameters.AddWithValue("@Telefono", Telefono);
            if (Correo == null)
            {
                Correo = string.Empty;
            }
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@IdCongreso", IdCongreso);
            command.Parameters.AddWithValue("@NumeroEmpleado_IdCongreso", NumeroEmpleado_IdCongreso);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch(Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        public string Borrar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarProfesorConstancia", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NumeroEmpleado_IdCongreso", NumeroEmpleado_IdCongreso);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch(Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        public static List<ClaseProfesor> ListaRegistroProfesor(int idCongreso, string numeroEmpleado_nombre)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spListaRegistroProfesor", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCongreso", idCongreso);
            command.Parameters.AddWithValue("@NumeroEmpleado_Nombre", numeroEmpleado_nombre);
            SqlDataReader dr;
            List<ClaseProfesor> lista = new List<ClaseProfesor>();
            ClaseProfesor cp;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                cp = new ClaseProfesor();
                cp.NumeroEmpleado = dr.GetString(0);
                cp.Nombre = dr.GetString(1);
                cp.Carrera = dr.GetString(2);
                cp.IdCongreso = dr.GetInt32(5);
                lista.Add(cp);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public static List<ClaseProfesor> ListaCargarModificarProfesorConstancia(string numeroEmpleado_idCongreso)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spCargarModificarProfesorConstancia", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NumeroEmpleado_IdCongreso", numeroEmpleado_idCongreso);
            SqlDataReader dr;
            List<ClaseProfesor> lista = new List<ClaseProfesor>();
            ClaseProfesor cp;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                cp = new ClaseProfesor();
                cp.NumeroEmpleado = dr.GetString(0);
                cp.Nombre = dr.GetString(1);
                cp.Carrera = dr.GetString(2);
                cp.Telefono = dr.GetString(3);
                cp.Correo = dr.GetString(4);
                cp.IdCongreso = dr.GetInt32(5);
                lista.Add(cp);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
    }
}