using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.BLL
{
    public class BLLMensagem
    {
        DAO.Mensagem objMensagem = new DAO.Mensagem();
        DAO.DAOMensagem objDAOMensagem = new DAO.DAOMensagem();

        public void DAOCadastraMensagem(string FKEnvia, string FKRecebe, string Data, string Assunto, string Mensagem)
        {
            int cFKEnvia = Convert.ToInt32(FKEnvia);
            int cFKRecebe = Convert.ToInt32(FKRecebe);

            objMensagem.FKEnviaMensagem = cFKEnvia;
            objMensagem.FKRecebeMensagem = cFKRecebe;
            objMensagem.DataMensagem = Data;
            objMensagem.AssuntoMensagem = Assunto;
            objMensagem.MensagemMensagem = Mensagem;

            objDAOMensagem.DAOCadastraMensagem(objMensagem);
        }


        public DataTable BLLConsultaMensagem(string RM)
        {
            int cRM = Convert.ToInt32(RM);
            
            objMensagem.FKRecebeMensagem = cRM;
            return objDAOMensagem.DAOConsultaMensagem(objMensagem);
        }

        public DataTable BLLConsultaIDMensagem(string ID)
        {
            int cID = Convert.ToInt32(ID);
            objMensagem.IDMensagem = cID;
            return objDAOMensagem.DAOConsultaIDMensagem(objMensagem);
        }

        public void BLLDeletaMensagem(string ID)
        {
            int cID = Convert.ToInt32(ID);
            objMensagem.IDMensagem = cID;
            objDAOMensagem.DAOExcluiMensagem(objMensagem);
        }

    }
}
