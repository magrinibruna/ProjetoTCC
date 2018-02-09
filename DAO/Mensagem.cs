using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC5._0.DAO
{
    public class Mensagem
    {
        public int IDMensagem { get; set; }
        public int FKEnviaMensagem { get; set; }
        public int FKRecebeMensagem { get; set; }
        public string DataMensagem { get; set; }
        public string AssuntoMensagem { get; set; }
        public string MensagemMensagem { get; set; }

    }
}
