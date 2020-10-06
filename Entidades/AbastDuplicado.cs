using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class AbastDuplicado
    {

        public Int64 BOLETIM_A { get; set; }
        public Int64 BOLETIM_B { get; set; }
        public DateTime DATA { get; set; }
        public Int64 EQUIPAMENTO { get; set; }
        public Int64 COMBUSTIVEL { get; set; }
        public double HORIMETRO { get; set; }
        public double QUANTIDADE { get; set; }

    }
}
