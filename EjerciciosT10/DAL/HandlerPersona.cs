using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace DAL
{
    public static class HandlerPersona
    {
        public static int deletePersonaDAL(int id)

        {

            int numeroFilasAfectadas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = ("server=107-05\\SQLEXPRESS;database=persona;uid=prueba2;pwd=123;trustServerCertificate=true");

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try

            {

                miConexion.Open();

                miComando.CommandText = "DELETE FROM Personas WHERE ID=@id";

                miComando.Connection = miConexion;

                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return numeroFilasAfectadas;

        }
    }
}

