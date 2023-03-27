using MySql.Data.MySqlClient;

namespace Inmobiliaria.Models;

public class RepositorioInquilinos

{
    string connectionString = "Server=localhost;User=root;Password=;Database=inmobiliaria;SslMode=none";

    public RepositorioInquilinos()
    {

    }

    public int Insertar(Inquilinos inquilino)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = @"INSERT INTO inquilinos (DNI,Apellido,Nombre,Telefono,Email) 
            VALUES (@dni,@apellido,@nombre,@telefono,@email);
            SELECT LAST_INSERT_ID();";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@dni",inquilino.DNI);
                command.Parameters.AddWithValue("@apellido",inquilino.Apellido);
                command.Parameters.AddWithValue("@nombre",inquilino.Nombre);
                command.Parameters.AddWithValue("@telefono",inquilino.Telefono);
                command.Parameters.AddWithValue("@email",inquilino.Email);
                connection.Open();
                res = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }
        }
        return res;
    }

    public int Modificar(Inquilinos inquilino)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = @"UPDATE inquilinos 
            SET DNI=@dni,Apellido=@apellido,Nombre = @nombre,Telefono=@telefono,Email=email 
            WHERE Id_Inquilino= @id;";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id",inquilino.Id_Inquilino);
                command.Parameters.AddWithValue("@dni",inquilino.DNI);
                command.Parameters.AddWithValue("@apellido",inquilino.Apellido);
                command.Parameters.AddWithValue("@nombre",inquilino.Nombre);
                command.Parameters.AddWithValue("@telefono",inquilino.Telefono);
                command.Parameters.AddWithValue("@email",inquilino.Email);
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
            string query = @"DELETE FROM inquilinos WHERE Id_Inquilino = @id;";

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

    public List<Inquilinos> ObtenerInquilinos()
    {
        List<Inquilinos> listaInquilinos = new List<Inquilinos>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"Select Id_Inquilino,DNI,Apellido,Nombre,Telefono,Email
            FROM inquilinos";

            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inquilinos aux = new Inquilinos
                        {
                            Id_Inquilino = reader.GetInt32(nameof(aux.Id_Inquilino)),
                            DNI = reader.GetString(nameof(aux.DNI)),
                            Apellido = reader.GetString(nameof(aux.Apellido)),
                            Nombre = reader.GetString(nameof(aux.Nombre)),
                            Telefono = reader.GetString(nameof(aux.Telefono)),
                            Email = reader.GetString(nameof(aux.Email))

                        };
                        listaInquilinos.Add(aux);
                    }
                }

            }
            connection.Close();
        }
        return listaInquilinos;
    }

    public Inquilinos ObtenerInquilino(int id)
    {
        Inquilinos res = null;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"Select Id_Inquilino,DNI,Apellido,Nombre,Telefono,Email
            FROM inquilinos
            WHERE Id_Inquilino =@Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var tel = reader["Telefono"];
                        res = new Inquilinos
                        {
                            Id_Inquilino = reader.GetInt32(nameof(res.Id_Inquilino)),
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
