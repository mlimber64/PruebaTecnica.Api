using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Domain.Entities
{
    [Table("Cuenta", Schema = "dbo")]
    public class Cuenta
    {
        [Column("CuentaId")]
        [Required]
        public int CuentaId { get; set; }

        [Column("ClienteId")]
        [Required]
        public int ClienteId { get; set; }

        [Column("NroCuenta")]
        [Required]
        public int NroCuenta { get; set; }

        [Column("TipoCuenta")]
        [Required]
        public string? TipoCuenta { get; set; }

        [Column("SaldoInicial")]
        [Required]
        public decimal SaldoInicial { get; set; }

        [Column("Estado")]
        [Required]
        public Boolean Estado { get; set; }
    }
}
