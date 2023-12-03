using UD10.Entities;
using Microsoft.Data.SqlClient;

namespace UD10.DAL
{
    public static class ListaPersonas
    {

        /// <summary>
        /// Función que devuelve un listado de personas
        /// Precondición : Ninguna
        /// Postcondición : Ninguna
        /// </summary>
        /// <returns>Lista de personas</returns>
        public static List<clsPersona> listadoCompletoPersonas()
        {
            SqlConnection miConexion = new SqlConnection();

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsPersona oPersona;

            miConexion.ConnectionString = clsConnection.connection();

            try
            {

                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos

                miComando.CommandText = "SELECT * FROM Personas";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        oPersona = new clsPersona();

                        oPersona.Id = (int)miLector["ID"];

                        oPersona.Nombre = (string)miLector["Nombre"];

                        oPersona.Apellido = (string)miLector["Apellidos"];

                        oPersona.IdDepartamento = (int)miLector["IDDepartamento"];

                        if (miLector["FechaNacimiento"] != System.DBNull.Value)

                        { oPersona.FNac = (DateTime)miLector["FechaNacimiento"]; }

                        oPersona.Foto = (string)miLector["Foto"];

                        oPersona.Direccion = (string)miLector["Direccion"];

                        oPersona.Tlf = (string)miLector["Telefono"];

                        listadoPersonas.Add(oPersona);

                    }

                }

                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)

            {
                throw exSql;

            }
            return listadoPersonas;
        }

        /// <summary>
        /// Función que devuelve una persona según su ID
        /// Precondición : Int ID > 0
        /// Postcondición : Ninguna
        /// </summary>
        /// <returns>Persona</returns>
        public static clsPersona getPersonaId(int id)
        {
            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsPersona oPersona = new clsPersona();

            miConexion.ConnectionString = clsConnection.connection();

            try

            {

                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                miComando.CommandText = "SELECT * FROM Personas WHERE ID=@id";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    miLector.Read();

                    oPersona.Id = (int)miLector["ID"];

                    oPersona.Nombre = (string)miLector["Nombre"];

                    oPersona.Apellido = (string)miLector["Apellidos"];

                    oPersona.IdDepartamento = (int)miLector["IDDepartamento"];

                    //Si sospechamos que el campo puede ser Null en la BBDD

                    if (miLector["FechaNacimiento"] != System.DBNull.Value)

                    { oPersona.FNac = (DateTime)miLector["FechaNacimiento"]; }

                    oPersona.Foto = (string)miLector["Foto"];

                    oPersona.Direccion = (string)miLector["Direccion"];

                    oPersona.Tlf = (string)miLector["Telefono"];

                }


                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)

            {
                throw exSql;

            }
            return oPersona;
        }
    }



}


