using System;
using System.Data.SqlClient;

namespace SPV.DataAccess
{
    public class Conexion
    {
        private static Conexion Con = null;

        public SqlConnection CreateConnection()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Data Source=SANTIAGO;Initial Catalog=BD_PUNTOVENTA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
            catch (Exception ex)
            {
                Cadena = null;
                string msg = ex.Message;
            }
            return Cadena;
        }

        public static Conexion GetInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
