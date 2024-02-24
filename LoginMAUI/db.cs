using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace LoginMAUI
{
    public class db
    {
        private readonly string _connectionString = "Server=127.0.0.1;Database=loginDB;User Id=root;Password=Abc123.;";

        public void InsertarUsuario(String nombre, String telefono, String email, char genero, DateTime fechaNacimiento, String contraseña)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO users (nombre, telefono, email, genero, fecha_nacimiento, contraseña) 
                             VALUES (@Nombre, @Telefono, @Email, @Genero, @FechaNacimiento, @Contraseña)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Genero", genero);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se han insertado {rowsAffected} filas.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar el usuario: " + ex.Message);
                    }
                }
            }
        }
    }
}
