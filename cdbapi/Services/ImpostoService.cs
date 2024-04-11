using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cdbapi.Models;

namespace cdbapi.Services
{
    public class ImpostoService : IImpostoService
    {
        public double CalcularValorImposto(double ValorFinalBruto)
        {
            double aliquota = 0.225; // 22.5%


            return ValorFinalBruto * aliquota;
        }
        public double CalcularValorImposto(double ValorFinalBruto, int PrazoEmMeses)
        {
            Aliquotas aliquota = new Aliquotas();
            double percentualAliquota = aliquota.ObterAliquota(PrazoEmMeses);
            double valorImposto = ValorFinalBruto * percentualAliquota;
            return valorImposto;
        }
    }
}