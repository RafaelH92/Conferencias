using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class BrocaFornecedor
    {
        public string FORNECEDOR { get; set; }
        public Int64 ENTR_BROCADOS { get; set; }
        public Int64 ENTR_TOTAL { get; set; }
        public double ÁREA { get; set; }
        public double PERCENTUAL { get; set; }

    }
}
