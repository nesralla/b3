using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cdbapi.Models
{
    public class Aliquotas
    {
        // Define as faixas de prazo em meses e suas respectivas alíquotas
        private readonly Dictionary<int, double> Faixas = new Dictionary<int, double>
        {
            { 6, 0.225 },
            { 12, 0.20 },
            { 24, 0.175 }
        };

        // Alíquota padrão para prazos maiores que o máximo definido nas faixas
        private readonly double AliquotaPadrao = 0.15;

        // Método para obter a alíquota com base no prazo em meses do investimento
        public double ObterAliquota(int prazoEmMeses)
        {
            foreach (var faixa in Faixas)
            {
                if (prazoEmMeses <= faixa.Key)
                {
                    return faixa.Value;
                }
            }
            return AliquotaPadrao;
        }

    }
}