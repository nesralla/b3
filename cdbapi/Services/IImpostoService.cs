using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cdbapi.Services
{
    public interface IImpostoService
    {

        double CalcularValorImposto(double ValorFinalBruto);
        double CalcularValorImposto(double ValorFinalBruto, int PrazoEmMeses);
    }
}