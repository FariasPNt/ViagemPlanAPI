using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemPlanLibrary.Domain.Entities
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public DateTime DataInicialReserva { get; set; }
        public DateTime DataFimReserva { get; set; }
        public int TotalPessoas { get; set; }
        public decimal PrecoDiaria { get; set; }


        public int CalcularDiarias()
        {
            var totalDias = (DataFimReserva - DataInicialReserva).Days;
            return totalDias > 0 ? totalDias : 0;
        }

        public decimal CalcularCustoReserva()
        {
            return CalcularDiarias() * PrecoDiaria;
        }
    }
}
