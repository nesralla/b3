using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cdbapi.Services
{
    public interface ICdbService
    {
        double CalcularValorBruto(double ValorInvestido);
        double CalcularValorBruto(double ValorInvestido, int PrazoEmMeses);
        double CalcularValorLiquido(double ValorBruto, double ValorImposto);
    }
}