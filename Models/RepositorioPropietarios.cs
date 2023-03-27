using MySql.Data.MySqlClient;

namespace Inmobiliaria.Models;

public class RepositorioPropietarios

{
    string connectionString = "Server=localhost;User=root;Password=;Database=inmobiliaria;SslMode=none";

    public RepositorioPropietarios()
    {

    }

    public int Insertar(Propietarios propietario)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = @"INSERT INTO propietarios (DNI,Apellido,Nombre,Telefono,Email) 
            VALUES (@dni,@apellido,@nombre,@telefono,@email);
            SELECT LAST_INSERT_ID();";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@dni",propietario.DNI);
                command.Parameters.AddWithValue("@apellido",propietario.Apellido);
                command.Parameters.AddWithValue("@nombre",propietario.Nombre);
                command.Parameters.AddWithValue("@telefono",propietario.Telefono);
                command.Parameters.AddWithValue("@email",propietario.Email);
                connection.Open();
                res = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }
        }
        return res;
    }

    public int Modificar(Propietarios propietario)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = @"UPDATE Propietarios 
            SET DNI=@dni,Apellido=@apellido,Nombre = @nombre,Telefono=@telefono,Email=email 
            WHERE Id_Propietario= @id;";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@dni",propietario.DNI);
                command.Parameters.AddWithValue("@id",propietario.Id_Propietario);
                command.Parameters.AddWithValue("@apellido",propietario.Apellido);
                command.Parameters.AddWithValue("@nombre",propietario.Nombre);
                command.Parameters.AddWithValue("@telefono",propietario.Telefono);
                command.Parameters.AddWithValue("@email",propietario.Email);
                connection.Open();
                res = command.ExecuteNonQuery();
                connection.Close();
            }
        }
        return res;
    }

    public int Eliminar(int id)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = @"DELETE FROM propietario WHERE Id_Propietario = @id;";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id",id);
                connection.Open();
                res = command.ExecuteNonQuery();
                connection.Close();
            }
        }
        return res;
    }

    public List<Propietarios> ObtenerPropietarios()
    {
        List<Propietarios> listaPropietarios = new List<Propietarios>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"Select Id_Propietario,DNI,Apellido,Nombre,Telefono,Email
            FROM propietarios";

            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Propietarios aux = new Propietarios
                        {
                            Id_Propietario = reader.GetInt32(nameof(aux.Id_Propietario)),
                            DNI = reader.GetString(nameof(aux.DNI)),
                            Apellido = reader.GetString(nameof(aux.Apellido)),
                            Nombre = reader.GetString(nameof(aux.Nombre)),
                            Telefono = reader.GetString(nameof(aux.Telefono)),
                            Email = reader.GetString(nameof(aux.Email))

                        };
                        listaPropietarios.Add(aux);
                    }
                }

            }
            connection.Close();
        }
        return listaPropietarios;
    }

    public Propietarios ObtenerPropietario(int id)
    {
        Propietarios res = null;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"Select Id_Propietario,DNI,Apellido,Nombre,Telefono,Email
            FROM propietarios
            WHERE Id_Propietario =@Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var tel = reader["Telefono"];
                        res = new Propietarios
                        {
                            Id_Propietario = reader.GetInt32(nameof(res.Id_Propietario)),
                            DNI = reader.GetString(nameof(res.DNI)),
                            Apellido = reader.GetString(nameof(res.Apellido)),
                            Nombre = reader.GetString(nameof(res.Nombre)),
                            Telefono = reader.GetString(nameof(res.Telefono)),
                            Email = reader.GetString(nameof(res.Email))
                        };
                    
                    }
                }

            }
            connection.Close();
        }
        return res;
    }


}
