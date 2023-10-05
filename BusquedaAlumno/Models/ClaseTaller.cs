using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusquedaAlumno.Models
{
    public class ClaseTaller
    {
        public int IdTaller { get; set; }
        public string NombreTaller { get; set; }
        public string ProfesorNombre { get; set; }
        public int TotalInscritos { get; set; }
        public int Turno { get; set; }
        public string Horario { get; set; }
        public string TurnoEscrito { get; set; }

        public int IdCongreso { get; set; }
        public string IdTaller_IdCongreso { get; set; }

        //--Propiedades para alumno--//
        public string Matricula { get; set; }
        public string NombreAlumno { get; set; }
        public string Carrera { get; set; }

        //--Propiedades para profesor--//
        public string NombreProfesor { get; set; }
        static public List<ClaseTaller> ListaTurnos()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spListaTurnos", conx);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            ClaseTaller c;
            List<ClaseTaller> lista = new List<ClaseTaller>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new ClaseTaller();
                c.Turno = dr.GetInt32(0);
                if (c.Turno == 0)
                {
                    c.TurnoEscrito = "Matutino";
                }
                else
                {
                    c.TurnoEscrito = "Vespertino";
                }
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;

        }
        static public List<ClaseTaller> ListaTalleres(string textoBuscar, int idTurno,int idCongreso)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spListaTalleres", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TextoBuscar", textoBuscar);
            command.Parameters.AddWithValue("@IdTurno", idTurno);
            command.Parameters.AddWithValue("@IdCongreso", idCongreso);
            SqlDataReader dr;
            ClaseTaller c;
            List<ClaseTaller> lista = new List<ClaseTaller>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new ClaseTaller();
                c.IdTaller = dr.GetInt32(0);
                c.NombreTaller = dr.GetString(1);
                c.ProfesorNombre = dr.GetString(2);
                c.TotalInscritos = dr.GetInt32(3);
                c.Turno = dr.GetInt32(4);
                c.Horario = dr.GetString(5);
                c.IdCongreso = dr.GetInt32(6);
                c.IdTaller_IdCongreso = (dr.GetInt32(0).ToString() + dr.GetInt32(6).ToString());
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        static public List<ClaseTaller>ImprimirListaTalleres(string idTaller_idCongreso)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spImprimirListaTalleres", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdTaller_IdCongreso", idTaller_idCongreso);
            SqlDataReader dr;
            ClaseTaller c;
            List<ClaseTaller> lista = new List<ClaseTaller>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new ClaseTaller();
                c.Matricula = dr.GetString(0);
                c.NombreAlumno = dr.GetString(1);
                c.Carrera = dr.GetString(2);
                c.IdTaller = dr.GetInt32(3);
                c.NombreTaller = dr.GetString(4);
                c.Turno = dr.GetInt32(5);
                if (c.Turno == 0)
                {
                    c.TurnoEscrito = "Matutino";
                }
                else
                {
                    c.TurnoEscrito = "Vespertino";
                }
                c.Horario = dr.GetString(6);
                c.TotalInscritos = dr.GetInt32(7);
                c.ProfesorNombre = dr.GetString(8);
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
    }
}