using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Domain.Entities
{
    [Table("Persona", Schema = "dbo")]
    public class Persona
    {
        [Column("PersonaId")]
        [Required]
        public int PersonaId { get; set; }

        [Column("Nombre")]
        [Required]
        public string? Nombre { get; set; }

        [Column("Genero")]
        [Required]
        public int Genero { get; set; }

        [Column("Edad")]
        [Required]
        public int Edad { get; set; }

        [Column("Identificacion")]
        [Required]
        public string? Identificacion { get; set; }

        [Column("Direccion")]
        [Required]
        public string? Direccion { get; set; }

        [Column("Telefono")]
        [Required]
        public int Telefono { get; set; }
    }
}
