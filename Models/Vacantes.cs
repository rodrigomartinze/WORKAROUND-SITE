using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace WorkAroundSite.Models
{
    public class Vacantes
    {
        private readonly string _connectionString;

        public Vacantes(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Vacantes> GetVacantes()
        {
            List<Vacantes> lista = new List<Vacantes>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Titulo, Descripcion, Empresa, Ubicacion FROM Vacantes";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Vacantes
                    {
                        Id = (int)reader["Id"],
                        Titulo = reader["Titulo"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Empresa = reader["Empresa"].ToString(),
                        Ubicacion = reader["Ubicacion"].ToString()
                    });
                }
            }

            return lista;
        }
    }

    public class Vacantes
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Empresa { get; set; }
        public string Ubicacion { get; set; }
    }
}
