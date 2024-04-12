using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cdbapi.Services
{
    public class CdbService : ICdbService
    {
        public double CalcularValorBruto(double ValorInvestido)
        {
            double cdi = 0.009; // CDI mensal (0.9%)
            double tb = 1.08;   // Taxa do Banco (108%)


            return ValorInvestido * (1 + (cdi * tb));
        }
        public double CalcularValorBruto(double ValorInvestido, int PrazoEmMeses)
        {
            double cdi = 0.009; // CDI mensal (0.9%)
            double tb = 1.08;   // Taxa do Banco (108%)
            List<double> lstValorFinalMensal = new List<double>();
            for (int i = 0; i < PrazoEmMeses; i++)
            {
                if (i == 0)
                {
                    lstValorFinalMensal.Add(ValorInvestido * (1 + (cdi * tb)));
                }
                else
                {
                    lstValorFinalMensal.Add(lstValorFinalMensal[i - 1] * (1 + (cdi * tb)));
                }

            }
            double valorFinalBruto = lstValorFinalMensal.Sum();
            return valorFinalBruto;
        }
    }
}