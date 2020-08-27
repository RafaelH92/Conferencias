using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class BrocaParceria
    {
        public string FORNECEDOR { get; set; }
        public Int64 COD_PARCERIA  { get; set; }
        public string PARCERIA { get; set; }
        public Int64 QT_ENTRENOS_BROCADOS  { get; set; }
        public Int64 QT_ENTRENOS_TOTAL { get; set; }
        public double ÁREA { get; set; }
        public double PORCENTAGEM_ENTRENOS_BROCADOS { get; set; }

    }
}
