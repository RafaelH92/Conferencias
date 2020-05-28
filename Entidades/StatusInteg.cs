using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFERENCIAS.Entidades
{
    public class StatusInteg
    {

        public int BOLETIM { get; set; }
        public string ORIGEM_INTEGRACAO { get; set; }
        public int EQUIPAMENTO { get; set; }
        public  DateTime MOVIMENTO { get; set; }
        public int OS_INDUSTRIA { get; set; }
        public string TP_MOVIMENTO { get; set; }
        public string CODIGO_MATERIAL { get; set; }
        public string MATERIAL { get; set; }
        public double QUANTIDADE { get; set; }
        public string UNIDADE { get; set; }
        public string MENSAGEM_DE_ERRO { get; set; }


    }
}
