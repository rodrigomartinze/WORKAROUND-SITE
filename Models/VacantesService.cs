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
                        v.Id,
                        v.EmpresaId,
                        v.Titulo,
                        v.Descripcion,
                        v.Requisitos,
                        v.Responsabilidades,
                        v.SalarioMin,
                        v.SalarioMax,
                        v.Ubicacion,
                        v.TipoTrabajo,
                        v.TipoContrato,
                        v.Experiencia,
                        v.FechaPublicacion,
                        v.FechaCierre,
                        v.Activa,
                        v.Vistas,
                        e.NombreEmpresa,
                        e.Logo,
                        (SELECT COUNT(*) FROM Aplicaciones WHERE VacanteId = v.Id) AS NumeroAplicaciones,
                        (SELECT STRING_AGG(h.Nombre, ', ') 
                         FROM VacantesHabilidades vh 
                         INNER JOIN Habilidades h ON vh.HabilidadId = h.Id 
                         WHERE vh.VacanteId = v.Id) AS HabilidadesStr
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
                        var vacante = new Vacante
                        {
                            Id = reader.GetInt32(0),
                            EmpresaId = reader.GetInt32(1),
                            Titulo = reader.GetString(2),
                            Descripcion = reader.GetString(3),
                            Requisitos = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Responsabilidades = reader.IsDBNull(5) ? null : reader.GetString(5),
                            SalarioMin = reader.IsDBNull(6) ? null : reader.GetDecimal(6),
                            SalarioMax = reader.IsDBNull(7) ? null : reader.GetDecimal(7),
                            Ubicacion = reader.GetString(8),
                            TipoTrabajo = reader.IsDBNull(9) ? null : reader.GetString(9),
                            TipoContrato = reader.IsDBNull(10) ? null : reader.GetString(10),
                            Experiencia = reader.IsDBNull(11) ? null : reader.GetString(11),
                            FechaPublicacion = reader.GetDateTime(12),
                            FechaCierre = reader.IsDBNull(13) ? null : reader.GetDateTime(13),
                            Activa = reader.GetBoolean(14),
                            Vistas = reader.GetInt32(15),
                            NombreEmpresa = reader.GetString(16),
                            Logo = reader.IsDBNull(17) ? null : reader.GetString(17),
                            NumeroAplicaciones = reader.GetInt32(18),
                            Habilidades = new List<string>()
                        };

                        // Procesar habilidades
                        if (!reader.IsDBNull(19))
                        {
                            string habilidadesStr = reader.GetString(19);
                            vacante.Habilidades = habilidadesStr.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        }

                        vacantes.Add(vacante);
                    }
                }
            }

            return vacantes;
        }

        public Vacante GetVacanteById(int id)
        {
            Vacante vacante = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        v.Id,
                        v.EmpresaId,
                        v.Titulo,
                        v.Descripcion,
                        v.Requisitos,
                        v.Responsabilidades,
                        v.SalarioMin,
                        v.SalarioMax,
                        v.Ubicacion,
                        v.TipoTrabajo,
                        v.TipoContrato,
                        v.Experiencia,
                        v.FechaPublicacion,
                        v.FechaCierre,
                        v.Activa,
                        v.Vistas,
                        e.NombreEmpresa,
                        e.Logo,
                        (SELECT COUNT(*) FROM Aplicaciones WHERE VacanteId = v.Id) AS NumeroAplicaciones
                    FROM Vacantes v
                    INNER JOIN Empresas e ON v.EmpresaId = e.Id
                    WHERE v.Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        vacante = new Vacante
                        {
                            Id = reader.GetInt32(0),
                            EmpresaId = reader.GetInt32(1),
                            Titulo = reader.GetString(2),
                            Descripcion = reader.GetString(3),
                            Requisitos = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Responsabilidades = reader.IsDBNull(5) ? null : reader.GetString(5),
                            SalarioMin = reader.IsDBNull(6) ? null : reader.GetDecimal(6),
                            SalarioMax = reader.IsDBNull(7) ? null : reader.GetDecimal(7),
                            Ubicacion = reader.GetString(8),
                            TipoTrabajo = reader.IsDBNull(9) ? null : reader.GetString(9),
                            TipoContrato = reader.IsDBNull(10) ? null : reader.GetString(10),
                            Experiencia = reader.IsDBNull(11) ? null : reader.GetString(11),
                            FechaPublicacion = reader.GetDateTime(12),
                            FechaCierre = reader.IsDBNull(13) ? null : reader.GetDateTime(13),
                            Activa = reader.GetBoolean(14),
                            Vistas = reader.GetInt32(15),
                            NombreEmpresa = reader.GetString(16),
                            Logo = reader.IsDBNull(17) ? null : reader.GetString(17),
                            NumeroAplicaciones = reader.GetInt32(18),
                            Habilidades = new List<string>()
                        };
                    }
                }

                // Obtener habilidades por separado
                if (vacante != null)
                {
                    string habilidadesQuery = @"
                        SELECT h.Nombre 
                        FROM VacantesHabilidades vh 
                        INNER JOIN Habilidades h ON vh.HabilidadId = h.Id 
                        WHERE vh.VacanteId = @VacanteId";

                    SqlCommand habilidadesCmd = new SqlCommand(habilidadesQuery, conn);
                    habilidadesCmd.Parameters.AddWithValue("@VacanteId", id);

                    using (SqlDataReader habilidadesReader = habilidadesCmd.ExecuteReader())
                    {
                        while (habilidadesReader.Read())
                        {
                            vacante.Habilidades.Add(habilidadesReader.GetString(0));
                        }
                    }
                }
            }

            return vacante;
        }
    }
}