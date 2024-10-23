using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("MTPAISES")] // Cambia esto por el nombre real de la tabla en tu base de datos
public class Pais
{
    [Key]
    [Column("CODIGO")] // Asegúrate de que coincida con el nombre de la columna en la base de datos
    public required string Codigo { get; set; } = ""; // NOT NULL

    [Column("NOMBRE")] // Cambia por el nombre de la columna en la base de datos
    public string? Nombre { get; set; } = null; // NULL

    [Column("STADSINCRO")] // Cambia por el nombre de la columna en la base de datos
    public bool? Stadsincro { get; set; } = null; // NULL

    [Column("DV_ISO4217")] // Cambia por el nombre de la columna en la base de datos
    public string? DvIso4217 { get; set; } = null; // NULL

    [Column("ISO_3166_1")] // Cambia por el nombre de la columna en la base de datos
    public string? Iso3166_1 { get; set; } = null; // NULL
}
