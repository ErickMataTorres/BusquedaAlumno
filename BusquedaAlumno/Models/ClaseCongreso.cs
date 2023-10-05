using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusquedaAlumno.Models
{
    public class ClaseCongreso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public string Matricula { get; set; }
        public string NombreAlumno { get; set; }
        public string Carrera { get; set; }
        public int TotalInscritos { get; set; }
        public string Id_Nombre { get; set; }
        public string Fecha { get; set; }


        


        public static List<ClaseCongreso> LlenarComboBox()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spLlenarComboBoxCongresos", conx);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            ClaseCongreso cc;
            List<ClaseCongreso> lista = new List<ClaseCongreso>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                cc = new ClaseCongreso();
                cc.Id = dr.GetInt32(0);
                cc.Nombre = dr.GetString(1);
                cc.Estado = dr.GetInt32(2);
                lista.Add(cc);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public static List<ClaseCongreso> ListaCongresos(string textoBuscar, int opcion)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("raym7109_sa.spListaCongresos", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TextoBuscar", textoBuscar);
            command.Parameters.AddWithValue("@Opcion", opcion);
            SqlDataReader dr;
            ClaseCongreso cc;
            List<ClaseCongreso> lista = new List<ClaseCongreso>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                cc = new ClaseCongreso();
                cc.Id = dr.GetInt32(0);
                cc.Nombre = dr.GetString(1);
                cc.Id_Nombre = dr.GetString(2);
                cc.TotalInscritos = dr.GetInt32(3);
                lista.Add(cc);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public static List<ClaseCongreso> ImprimirListaCongresos(int idCongreso)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("raym7109_sa.spImprimirListaCongresos", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCongreso", idCongreso);
            SqlDataReader dr;
            ClaseCongreso cc;
            List<ClaseCongreso> lista = new List<ClaseCongreso>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                cc = new ClaseCongreso();
                cc.Matricula = dr.GetString(0);
                cc.NombreAlumno = dr.GetString(1);
                cc.Carrera = dr.GetString(2);
                cc.Id = dr.GetInt32(3);
                cc.Nombre = dr.GetString(4);
                cc.Fecha = dr.GetString(5);
                lista.Add(cc);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
    }
}