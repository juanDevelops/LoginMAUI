using MySqlConnector;
using System.Net;

namespace LoginMAUI
{
    public class dbLogin
    {
        /*public static string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();*/ // Get dynamic IP
        string connectionString = $"Server=192.168.62.205;Port=3306;Database=loginDB;Uid=juan;Pwd=Abc123.;SSL Mode=None;AllowPublicKeyRetrieval=true";
        public string errorMessage = "";

        public bool InsertarUsuario(string nombre, string telefono, string email, char genero, DateTime fechaNacimiento, string contraseña)
        {
            bool success = false;
            errorMessage = "";

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
                        success = rowsAffected > 0;
                    }
                    catch (MySqlException ex)
                    {

                        errorMessage = ex.Message;
                        // Manejo de excepciones específicas de MySQL
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        // Manejo de otras excepciones
                    }
                }
            }

            return success;
        }

        public bool ConsultarUsuario(string nombre, string contraseña)
        {
            bool success = false;
            errorMessage = "";

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*) FROM users WHERE nombre = @Nombre AND contraseña = @Contraseña;";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        success = count > 0;
                    }
                    catch (MySqlException ex)
                    {
                        errorMessage = ex.Message;
                        // Manejo de excepciones específicas de MySQL
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        // Manejo de otras excepciones
                    }
                }
            }

            return success;
        }

        public bool ActualizarContraseña(string nombre, string email, string contraseña)
        {
            bool success = false;
            errorMessage = "";

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = @"UPDATE users SET contraseña = @Contraseña WHERE nombre = @Nombre and email = @Email";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                    catch (MySqlException ex)
                    {

                        errorMessage = ex.Message;
                        // Manejo de excepciones específicas de MySQL
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        // Manejo de otras excepciones
                    }
                }
            }

            return success;
        }

    }
}
