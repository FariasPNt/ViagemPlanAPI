using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemPlanLibrary.Domain.Entities;

public class Destino
{
    public int IdDestino { get; set; }
    public string Cidade { get; set; }
    public string Pais { get; set; }
    public Participantes? Participantes { get; set; }
    public Reserva? Reserva { get; set; }
    public PacoteAtividades? PacoteAtividades { get; set; }
}
