using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class ManuSfPosterior
    {
        public int BOLETIM { get; set; }
        public DateTime DATA { get; set; }
        public int COD_FUNC { get; set; }
        public  string FUNCIONARIO { get; set; }
        public int SAFRA { get; set; }
        public int CCUSTO { get; set; }
        public int COD_PARCERIA { get; set; }
        public string PARCERIA { get; set; }
        public int TALHAO { get; set; }
        public int COD_OPERACAO { get; set; }
        public string OPERACAO { get; set; }

    }
}
