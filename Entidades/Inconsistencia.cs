using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class Inconsistncia
    {

        public Int64 BOLETIM { get; set; }
        public DateTime DATA { get; set; }
        public int COD_FUNC { get; set; }
        public string FUNCIONARIO { get; set; }
        public int COD_EQUIPAMENTO { get; set; }
        public string MODELO{ get; set; }
        public Int32 INICIO { get; set; }
        public Int32 FIM { get; set; }

    }
}
