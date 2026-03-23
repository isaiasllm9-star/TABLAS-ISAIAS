using Microsoft.Data.Sqlite;
using FitLife.Models;
using System.Collections.Generic;
using FitLife.Database;

namespace FitLife.Repositories
{
    public class MiembroRepository
    {
        public List<Miembro> GetAll()
        {
            var miembros = new List<Miembro>();
            using var connection = new SqliteConnection(DbInitializer.GetConnectionString());
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT cedula, nombre_completo, telefono FROM Miembros";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                miembros.Add(new Miembro
                {
                    cedula = reader.GetString(0),
                    nombre_completo = reader.GetString(1),
                    telefono = reader.GetString(2)
                });
            }
            return miembros;
        }

        public Miembro? GetByCedula(string cedula)
        {
            using var connection = new SqliteConnection(DbInitializer.GetConnectionString());
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT cedula, nombre_completo, telefono FROM Miembros WHERE cedula = $cedula";
            command.Parameters.AddWithValue("$cedula", cedula);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Miembro
                {
                    cedula = reader.GetString(0),
                    nombre_completo = reader.GetString(1),
                    telefono = reader.GetString(2)
                };
            }
            return null;
        }

        public void Add(Miembro miembro)
        {
            using var connection = new SqliteConnection(DbInitializer.GetConnectionString());
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Miembros (cedula, nombre_completo, telefono) VALUES ($cedula, $nombre, $tel)";
            command.Parameters.AddWithValue("$cedula", miembro.cedula);
            command.Parameters.AddWithValue("$nombre", miembro.nombre_completo);
            command.Parameters.AddWithValue("$tel", miembro.telefono);
            command.ExecuteNonQuery();
        }

        public void UpdatePhone(string cedula, string newPhone)
        {
            using var connection = new SqliteConnection(DbInitializer.GetConnectionString());
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Miembros SET telefono = $tel WHERE cedula = $cedula";
            command.Parameters.AddWithValue("$cedula", cedula);
            command.Parameters.AddWithValue("$tel", newPhone);
            command.ExecuteNonQuery();
        }

        public void Delete(string cedula)
        {
            using var connection = new SqliteConnection(DbInitializer.GetConnectionString());
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Miembros WHERE cedula = $cedula";
            command.Parameters.AddWithValue("$cedula", cedula);
            command.ExecuteNonQuery();
        }
    }
}
