﻿using System;
using MySqlConnector;

namespace LoginMAUI
{
    public class dbLogin
    {
        string connectionString = "Server=127.0.0.1;Port=3306;Database=loginDB;Uid=root;Pwd=Abc123.;";

        public void InsertarUsuario(string nombre, string telefono, string email, char genero, DateTime fechaNacimiento, string contraseña)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = @"INSERT INTO users (nombre, telefono, email, genero, fecha_nacimiento, contraseña) 
                                 VALUES (@Nombre, @Telefono, @Email, @Genero, @FechaNacimiento, @Contraseña)";

                using (var command = new MySqlCommand(query, connection))
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