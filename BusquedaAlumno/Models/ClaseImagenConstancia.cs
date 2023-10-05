using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BusquedaAlumno.Models
{
    public class ClaseImagenConstancia
    {
        public int Id { get; set; }
        public int IdTipoImagen { get; set; }
        public string NombreTipoImagen { get; set; }
        public int IdCongreso { get; set; }
        public string CongresoNombre { get; set; }
        public string ImagenNombre { get; set; }
        public decimal AnguloNombre { get; set; }
        public decimal AlturaNombre { get; set; }
        public decimal MargenNombre { get; set; }
        public string ImagenUrl { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }


        public static ClaseImagenConstancia ConsultarImagenConstancia(int idCongreso)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("raym7109_sa.spConsultarImagenConstancia", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCongreso", idCongreso);
            SqlDataReader dr;
            ClaseImagenConstancia c = new ClaseImagenConstancia();
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                c.ImagenNombre = dr.GetString(0);
                c.AnguloNombre = dr.GetDecimal(1);
                c.AlturaNombre = dr.GetDecimal(2);
                c.MargenNombre = dr.GetDecimal(3);
                c.ImagenUrl = dr.GetString(4);
            }
            dr.Close();
            conx.Close();
            return c;
        }
        public static List<ClaseImagenConstancia> TablaImagenConstancias(int idTipoImagen)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("raym7109_sa.spTablaImagenConstancias", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdTipoImagen", idTipoImagen);
            SqlDataReader dr;
            ClaseImagenConstancia c;
            List<ClaseImagenConstancia> lista = new List<ClaseImagenConstancia>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new ClaseImagenConstancia();
                c.Id = dr.GetInt32(0);
                c.IdTipoImagen = dr.GetInt32(1);
                c.NombreTipoImagen = dr.GetString(2);
                c.IdCongreso = dr.GetInt32(3);
                c.CongresoNombre = dr.GetString(4);
                c.ImagenNombre = dr.GetString(5);
                c.AnguloNombre = dr.GetDecimal(6);
                c.AlturaNombre = dr.GetDecimal(7);
                c.MargenNombre = dr.GetDecimal(8);
                c.ImagenUrl = dr.GetString(9);
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
            SqlCommand command = new SqlCommand("raym7109_sa.spGuardarImagenConstancia", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@IdTipoImagen", IdTipoImagen);
            command.Parameters.AddWithValue("@IdCongreso", IdCongreso);
            command.Parameters.AddWithValue("@Nombre", ImagenNombre);
            command.Parameters.AddWithValue("@AnguloNombre", AnguloNombre);
            command.Parameters.AddWithValue("@AlturaNombre", AlturaNombre);
            command.Parameters.AddWithValue("@MargenNombre", MargenNombre);
            command.Parameters.AddWithValue("@ImagenUrl", ImagenUrl);
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
        public string Borrar(int id)
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("raym7109_sa.spBorrarImagenConstancia", conx);
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