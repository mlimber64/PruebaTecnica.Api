namespace PruebaTecnica.Domain.Dtos
{
    public class ReporteEstadoCuentaDto
    {
        public int ClienteId { get; set; }
        public string? NombreCliente { get; set; }
        public List<CuentaReporteDto> Cuentas { get; set; } = new List<CuentaReporteDto>();
    }

    public class MovimientoDto
    {
        public DateTime Fecha { get; set; }
        public string? TipoMovimiento { get; set; }
        public string? Valor { get; set; }
        public decimal Saldo { get; set; }
    }

    public class CuentaReporteDto
    {
        public int NroCuenta { get; set; }
        public string? TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public List<MovimientoDto> Movimientos { get; set; } = new List<MovimientoDto>();
    }
}
