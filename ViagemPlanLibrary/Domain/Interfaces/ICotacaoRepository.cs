using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemPlanLibrary.Domain.Interfaces;

public interface ICotacaoRepository
{
    Task<decimal> ObterCotacaoPara(string moeda);
}
