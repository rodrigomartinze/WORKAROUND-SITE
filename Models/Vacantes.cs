using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkAroundSite.Models
{
    public class Vacante
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }

        public string Requisitos { get; set; }
        public string Responsabilidades { get; set; }
        public decimal? SalarioMin { get; set; }
        public decimal? SalarioMax { get; set; }

        [Required(ErrorMessage = "La ubicación es requerida")]
        public string Ubicacion { get; set; }

        public string TipoTrabajo { get; set; } // "Remoto", "Presencial", "Hibrido"
        public string TipoContrato { get; set; } // "Tiempo Completo", "Medio Tiempo", etc.
        public string Experiencia { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime? FechaCierre { get; set; }
        public bool Activa { get; set; }
        public int Vistas { get; set; }

        // Propiedades de navegación (no están en la BD directamente)
        public string NombreEmpresa { get; set; }
        public string Logo { get; set; }
        public List<string> Habilidades { get; set; }
        public int NumeroAplicaciones { get; set; }
    }