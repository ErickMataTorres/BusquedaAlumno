using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusquedaAlumno.Models
{
    public class Conexion
    {
        public static SqlConnection Conectar()
        {
            var conx = "SERVER = 198.38.83.200; DATABASE = raym7109_webinar; USER ID = raym7109_sa; PWD = uadeo123;";
            //var conx = "DATA SOURCE=A; INITIAL CATALOG=raym7109_webinar; INTEGRATED SECURITY=YES;";
            var s = new SqlConnection(conx);
            return s;
        }
    }
}