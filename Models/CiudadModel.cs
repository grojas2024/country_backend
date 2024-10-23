using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfimaWebApi.Models
{
    [Table("CIUDAD")] // Cambia esto por el nombre real de la tabla en tu base de datos
    public class Ciudad
    {
        [Key]
        public required string  CodCiudad { get; set; } = ""; // NOT NULL 
        public string?          Nombre { get; set; } = null; // NULL Nombre
        public bool?            Stadsincro { get; set; } = null; // NULL
    }

}
