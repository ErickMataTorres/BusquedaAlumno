using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BusquedaAlumno.Models
{
    public class ClaseTipoConstancia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<ClaseTipoConstancia> ConsultarTipoConstancia(int parametro)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spConsultarTipoImagen", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Parametro", parametro);
            SqlDataReader dr;
            ClaseTipoConstancia c;
            List<ClaseTipoConstancia> lista = new List<ClaseTipoConstancia>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new ClaseTipoConstancia();
                c.Id = dr.GetInt32(0);
                c.Nombre = dr.GetString(1);
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public string Guardar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarTipoConstancia", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Nombre", Nombre.ToUpper().Trim());
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch (Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        public string Borrar(int id)
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarTipoConstancia", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch (Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
    }
}