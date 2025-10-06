using System.Data;
using System.Data.SqlClient;

namespace WorkAroundSite.Models
{
    public class VacantesService
    {
        private readonly string _connectionString;

        public VacantesService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Vacante> GetVacantes()
        {
            var vacantes = new List<Vacante>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        v.Id, v.EmpresaId, v.Titulo, v.Descripcion,
                        v.Ubicacion, v.TipoTrabajo, v.SalarioMin, v.SalarioMax,
                        e.NombreEmpresa, e.Logo
                    FROM Vacantes v
                    INNER JOIN Empresas e ON v.EmpresaId = e.Id
                    WHERE v.Activa = 1
                    ORDER BY v.FechaPublicacion DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vacantes.Add(new Vacante
                        {
                            Id = reader.GetInt32(0),
                            EmpresaId = reader.GetInt32(1),
                            Titulo = reader.GetString(2),
                            Descripcion = reader.GetString(3),
                            Ubicacion = reader.GetString(4),
                            TipoTrabajo = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            SalarioMin = reader.IsDBNull(6) ? null : reader.GetDecimal(6),
                            SalarioMax = reader.IsDBNull(7) ? null : reader.GetDecimal(7),
                            NombreEmpresa = reader.GetString(8),
                            Logo = reader.IsDBNull(9) ? null : reader.GetString(9),
                            Habilidades = new List<string>()
                        });
                    }
                }
            }

            return vacantes;
        }
    }
}