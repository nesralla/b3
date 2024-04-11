using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cdbapi.Models
{
    public class Cdb
    {
        public double ValorInvestido { get; set; }
        public int PrazoEmMeses { get; set; }
        public double ValorBruto { get; set; }
        public double ValorLiquido { get; set; }
        public double Taxa { get; set; }
        public double Aliquota { get; set; }
    }
}