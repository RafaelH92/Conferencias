using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class Consecutivo
    {
        public Int64 LIBERACAO { get; set; }
        public Int64 CONSECUTIVO { get; set; }
        public Int64 SEQUENCIA { get; set; }
        public Int64 COD_PARCERIA { get; set; }
        public string PARCERIA { get; set; }
        public DateTime DATA_DE_ENTRADA { get; set; }
        public Int64 CAMINHAO { get; set; }
        public string MODELO { get; set; }

    }
}
