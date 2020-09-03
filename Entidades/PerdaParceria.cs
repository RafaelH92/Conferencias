using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class PerdaParceria
    {
        public string FORNECEDOR { get; set; }
        public Int64 COD_PARCERIA { get; set; }
        public string PARCERIA { get; set; }
        public double TOCO { get; set; }
        public double CANA_INTEIRA { get; set; }
        public double CANA_PONTA { get; set; }
        public double TOLETE { get; set; }
        public double LASCA { get; set; }
        public double PEDAÇO { get; set; }
        public double TOTAL_PERDAS { get; set; }
        public double PORCENTAGEM_PERDAS { get; set; }
        public double TCH { get; set; }
        public double ÁREA_PONDERADA { get; set; }
        public double TON_PERDIDAS { get; set; }

    }
}
