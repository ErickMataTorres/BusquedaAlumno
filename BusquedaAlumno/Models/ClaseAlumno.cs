using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusquedaAlumno.Models
{
    public class ClaseAlumno
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        public string Telefono { get; set; }
        public string FolioRecibo { get; set; }
        public string Taller { get; set; }
        public int Turno { get; set; }
        public string Correo { get; set; }
        public string Horario { get; set; }
        public string Profesor { get; set; }
        public string Matricula_IdCongreso { get; set; }
        public int IdCongreso { get; set; }
        public string Folio_Const { get; set; }
        public string NombreImagen { get; set; }
        public decimal AnguloNombre { get; set; }
        public decimal AlturaNombre { get; set; }
        public decimal MargenNombre { get; set; }
        public string ImagenUrl { get; set; }

        public ClaseAlumno ImprimirConstanciaAlumno(string matricula_idCongreso, int idTipoImagen)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spImprimirConstanciaAlumno", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Matricula_IdCongreso", matricula_idCongreso);
            command.Parameters.AddWithValue("@IdTipoImagen", idTipoImagen);
            SqlDataReader dr;
            ClaseAlumno ca=new ClaseAlumno();
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                ca.Folio_Const = dr.GetInt32(0).ToString();
                ca.Matricula = dr.GetString(1);
                ca.Nombre = dr.GetString(2);
                ca.Carrera = dr.GetString(3);
                ca.Telefono = dr.GetString(4);
                ca.Correo = dr.GetString(5);
                ca.IdCongreso = dr.GetInt32(6);
                ca.Profesor = dr.GetString(7);
                ca.NombreImagen = dr.GetString(8);
                ca.AnguloNombre = dr.GetDecimal(9);
                ca.AlturaNombre = dr.GetDecimal(10);
                ca.MargenNombre = dr.GetDecimal(11);
                ca.ImagenUrl = dr.GetString(12);
            }
            dr.Close();
            conx.Close();
            return ca;
        }
        public static List<ClaseAlumno> ListaAlumnoConstancia(int idCongreso, string matricula_nombre)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spListaConstanciaAlumno", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCongreso", idCongreso);
            command.Parameters.AddWithValue("@Matricula_Nombre", matricula_nombre);
            SqlDataReader dr;
            List<ClaseAlumno> lista = new List<ClaseAlumno>();
            ClaseAlumno ca;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                ca = new ClaseAlumno();
                ca.Matricula = dr.GetString(0);
                ca.Nombre = dr.GetString(1);
                ca.Carrera = dr.GetString(2);
                ca.IdCongreso = dr.GetInt32(5);
                lista.Add(ca);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public string ModificarDatosAlumno()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spModificarDatosAlumno", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre", Nombre.ToUpper().Trim());
            command.Parameters.AddWithValue("@Carrera", Carrera.ToUpper().Trim());
            command.Parameters.AddWithValue("@Telefono", Telefono);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@Matricula_IdCongreso", Matricula_IdCongreso);
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
        public static List<ClaseAlumno> CargarModificarAlumno(string matricula_idCongreso)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spCargarModificarAlumno", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Matricula_IdCongreso", matricula_idCongreso);
            SqlDataReader dr;
            List<ClaseAlumno> l = new List<ClaseAlumno>();
            ClaseAlumno ca;
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                ca = new ClaseAlumno();
                ca.Matricula = dr.GetString(0);
                ca.Nombre = dr.GetString(1);
                ca.Carrera = dr.GetString(2);
                ca.Telefono = dr.GetString(3);
                ca.Correo = dr.GetString(4);
                ca.Matricula_IdCongreso = dr.GetString(5);
                l.Add(ca);
            }
            dr.Close();
            conx.Close();
            return l;
        }

        public static List<ClaseAlumno> ListaModificarAlumno(int opcion,string textoBuscar, int idCongreso)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spListaModificarAlumno", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion",opcion);
            command.Parameters.AddWithValue("@TextoBuscar", textoBuscar);
            command.Parameters.AddWithValue("@IdCongreso", idCongreso);
            SqlDataReader dr;
            List<ClaseAlumno> l = new List<ClaseAlumno>();
            ClaseAlumno ca;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                ca = new ClaseAlumno();
                ca.Matricula = dr.GetString(0);
                ca.Nombre = dr.GetString(1);
                ca.Carrera = dr.GetString(2);
                ca.Telefono = dr.GetString(3);
                ca.Correo = dr.GetString(4);
                ca.Matricula_IdCongreso = dr.GetString(5);
                ca.IdCongreso = dr.GetInt32(6);
                l.Add(ca);
            }
            dr.Close();
            conx.Close();
            return l;
        }
        public static List<ClaseAlumno> Lista(string matricula,int idCongreso)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("raym7109_sa.spBuscarAlumno", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Matricula", matricula);
            command.Parameters.AddWithValue("@IdCongreso", idCongreso);
            SqlDataReader dr;
            List<ClaseAlumno> l = new List<ClaseAlumno>();
            ClaseAlumno ca;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                ca = new ClaseAlumno();
                if (matricula == null || matricula == string.Empty)
                {
                    ca.Matricula = dr.GetString(0).Trim();
                }
                else
                {
                    ca.Matricula = dr.GetString(0).Trim();
                }
                ca.Nombre = dr.GetString(1);
                ca.Carrera = dr.GetString(2);
                ca.Taller = dr.GetString(3);
                ca.Horario = dr.GetString(4);
                ca.IdCongreso = dr.GetInt32(5);
                l.Add(ca);
            }
            dr.Close();
            conx.Close();
            return l;
        }
        public static List<ClaseAlumno> ListaImprimir(string matricula_idCongreso)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spImprimirReciboAlumno", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Matricula_IdCongreso", matricula_idCongreso);           
            SqlDataReader dr;
            List<ClaseAlumno> l = new List<ClaseAlumno>();
            ClaseAlumno ca;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                ca = new ClaseAlumno();
                ca.Matricula = dr.GetString(0);
                ca.Nombre = dr.GetString(1);
                ca.Carrera = dr.GetString(2);
                ca.FolioRecibo = dr.GetString(3);
                ca.Telefono = dr.GetString(4);
                ca.Correo = dr.GetString(5);
                ca.Taller = dr.GetString(6);
                ca.Horario = dr.GetString(7);
                ca.Turno = dr.GetInt32(8);
                ca.Profesor = dr.GetString(9);
                l.Add(ca);
            }
            dr.Close();
            conx.Close();
            return l;
        }
        public string BorrarAlumno()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarAlumno", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Matricula_IdCongreso", Matricula_IdCongreso);
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
    }
}