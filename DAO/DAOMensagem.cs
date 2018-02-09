using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.DAO
{
    public class DAOMensagem
    {
        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        public void DAOCadastraMensagem(Mensagem objMensagem)
        {
            SQL = "INSERT INTO TCC.TBMENSAGEM(IDMENSAGEM, FKEnviaMensagem, FKRecebeMensagem, DataMensagem, AssuntoMensagem, MensagemMensagem)" +
                "VALUES(tcc.seqidmensagem.nextval, '" + objMensagem.FKEnviaMensagem + "','"  + objMensagem.FKRecebeMensagem + "','" + objMensagem.DataMensagem + "','" + objMensagem.AssuntoMensagem + "','" + objMensagem.MensagemMensagem + "')";
            objConexao.ExecutarComando(SQL);
        }


        public DataTable DAOConsultaMensagem(Mensagem objMensagem)
        {
            SQL = "SELECT IDMENSAGEM, FKEnviaMensagem, DataMensagem, AssuntoMensagem, MensagemMensagem FROM TCC.TBMENSAGEM WHERE FKRecebeMensagem = " + objMensagem.FKRecebeMensagem+ "ORDER BY DATAMENSAGEM DESC";
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);

            return dt;
        }


        public DataTable DAOConsultaIDMensagem(Mensagem objMensagem)
        {
            SQL = "SELECT IDMENSAGEM, FKEnviaMensagem, DataMensagem, AssuntoMensagem, MensagemMensagem FROM TCC.TBMENSAGEM WHERE IDMENSAGEM = " + objMensagem.IDMensagem;
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

        public void DAOExcluiMensagem(Mensagem objMensagem)
        {

            SQL = "DELETE FROM TCC.TBMENSAGEM WHERE IDMENSAGEM = " + objMensagem.IDMensagem;
            objConexao.ExecutarComando(SQL);

        }

    }
}
