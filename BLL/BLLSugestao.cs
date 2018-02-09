using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TCC5._0.BLL
{
    public class BLLSugestao
    {
        DAO.Sugestao objSugestao = new DAO.Sugestao();
        DAO.DAOSugestao objDAOSugestao = new DAO.DAOSugestao();

        public void BLLCadastroSugestao(string FK, string DataEnvio, string Mensagem)
        {
            int cFK = Convert.ToInt32(FK);

            objSugestao.FKSugestao = cFK;
            objSugestao.DataEnvioSugestao = DataEnvio;
            objSugestao.MensagemSugestao = Mensagem;

            objDAOSugestao.DAOCadastroSugestao(objSugestao);

        }

        public void BLLConsultaSugestao(DataGridView dgv)
        {
            dgv.DataSource = objDAOSugestao.DAOConsultaSugestao();
        }

        public DataTable BLLConsultaIDSugestao(string ID)
        {
            int cID = Convert.ToInt16(ID);

            objSugestao.IDSugestao = cID;

            return objDAOSugestao.DAOConsultaIDSugestao(objSugestao);

        }

    }
}
