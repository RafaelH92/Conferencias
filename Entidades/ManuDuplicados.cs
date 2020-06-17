using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class ManuDuplicados
    {

        public DateTime DATA { get; set; }
        public int BOLETIM { get; set; }
        public int COD_FUNC { get; set; }
        public  string FUNCIONARIO { get; set; }
        public int CCUSTO { get; set; }
        public int OPERACAO { get; set; }
        public int PARCERIA { get; set; }
        public int TALHAO { get; set; }
        public string INICIO { get; set; }
        public string FIM { get; set; }
        public int LINHAS_DUPLICADAS { get; set; }


    }
}
