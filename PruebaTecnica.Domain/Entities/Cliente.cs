using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Domain.Entities
{
    [Table("Cliente", Schema = "dbo")]
    public class Cliente
    {
        [Column("ClienteId")]
        [Required]
        public int ClienteId { get; set; }

        [Column("PersonaId")]
        [Required]
        public int PersonaId { get; set; }

        [Column("Contrasena")]
        [Required]
        public string? Contrasena { get; set; }

        [Column("Estado")]
        [Required]
        public Boolean Estado { get; set; }
    }
}
