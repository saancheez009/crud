﻿using Microsoft.Data.SqlClient;
using UD10.Entities;

namespace UD10.DAL
{
    public static class HandlerPersona
    {
        public static int deletePersonaDAL(int id)

        {
            int numeroFilasAfectadas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = clsConnection.connection();

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

        public static string nombreDepartamentoId(int id)
        {
            List<clsDepartamento> listadoDepartamentos = ListaDepartamentos.listadoCompletoDepartamentos();

            // Buscar el departamento con el ID proporcionado
            clsDepartamento departamento = listadoDepartamentos.FirstOrDefault(d => d.idDepartamento == id);

            // Verificar si se encontró el departamento
            if (departamento != null)
            {
                return departamento.nombreDepartamento;
            }
            else
            {
                // Manejar el caso en el que no se encuentre el departamento
                return "Departamento no encontrado";
            }
        }
        public static int editPersonaDAL(clsPersona persona)
        {
            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            SqlConnection miConexion = new SqlConnection();

            miConexion.ConnectionString = clsConnection.connection();

            try

            {
                miConexion.Open();

                miComando.CommandText = "UPDATE Personas " +
                    "SET Nombre = @Nombre, apellidos = @Apellido, Telefono = @Telefono, Direccion = @Direccion, Foto = @Foto, FechaNacimiento = @FechaNacimiento, IDDepartamento = @IdDepartamento " +
                    "WHERE ID=@id";
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
                miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                miComando.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
                miComando.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FNac;
                miComando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                miComando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.Tlf;
                miComando.Parameters.Add("@Foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
                miComando.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;

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
