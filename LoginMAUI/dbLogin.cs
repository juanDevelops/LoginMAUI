using MySqlConnector;

namespace LoginMAUI
{
    public class dbLogin
    {
        string connectionString = "Server=192.168.94.205;Port=3306;Database=loginDB;Uid=juan;Pwd=Abc123.;SSL Mode=None";
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
    }
}
