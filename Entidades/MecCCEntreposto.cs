using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class MecCCEntreposto
    {
        public DateTime DATA { get; set; }
        public Int64 BOLETIM { get; set; }
        public int COD_EQUIPAMENTO { get; set; }
        public string MODELO { get; set; }
        public Int64 COD_FUNC { get; set; }
        public string FUNCIONARIO { get; set; }
        public string CARGO { get; set; }
        public int COD_CCUSTO { get; set; }
        public string CCUSTO { get; set; }
        public string USUARIO { get; set; }

    }
}
