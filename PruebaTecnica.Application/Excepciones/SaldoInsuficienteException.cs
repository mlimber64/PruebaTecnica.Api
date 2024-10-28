using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Excepciones
{
    public class SaldoInsuficienteException: Exception
    {
        public SaldoInsuficienteException() : base("Saldo no disponible") { }
    }
}
