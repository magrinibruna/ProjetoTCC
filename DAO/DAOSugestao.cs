using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.DAO
{
    public class DAOSugestao
    {
        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        
        private static string SQL;

        public void DAOCadastroSugestao(Sugestao objSugestao)
        {
            SQL = "INSERT INTO TCC.TBSUGESTAO(IDSUGESTAO, FKSUGESTAO, DATAENVIOSUGESTAO, MENSAGEMSUGESTAO)" +
                "VALUES(tcc.seqidsugestao.NEXTVAL, '" + objSugestao.FKSugestao + "','" + objSugestao.DataEnvioSugestao + "','" + objSugestao.MensagemSugestao + "')";
            objConexao.ExecutarComando(SQL);
        }


        public DataTable DAOConsultaSugestao()
        {
            SQL = "SELECT * FROM TCC.TBSUGESTAO ORDER BY DATAENVIOSUGESTAO DESC";
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);

            return dt;
        }

        public DataTable DAOConsultaIDSugestao(Sugestao objSugestao)
        {
            SQL = "SELECT * FROM TCC.TBSUGESTAO WHERE IDSUGESTAO = " + objSugestao.IDSugestao;
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

    }
}
