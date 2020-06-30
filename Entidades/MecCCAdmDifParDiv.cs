using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class MecCCAdmDifParDiv
    {
        public DateTime DATA { get; set; }
        public Int64 BOLETIM { get; set; }
        public int COD_EQUIPAMENTO { get; set; }
        public int SAFRA { get; set; }
        public Int64 COD_FUNC { get; set; }
        public string FUNCIONARIO { get; set; }
        public int COD_CCUSTO { get; set; }
        public string CCUSTO { get; set; }
        public int COD_OPERACAO { get; set; }
        public string OPERACAO { get; set; }
        public int COD_PARCERIA { get; set; }
        public string PARCERIA { get; set; }
        public string USUARIO { get; set; }

    }
}
