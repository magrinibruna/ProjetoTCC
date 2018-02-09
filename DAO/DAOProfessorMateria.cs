using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.DAO
{
    public class DAOProfessorMateria
    {
        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        public void DAOCadastroProfMate(ProfessorMateria objProfMate)
        {
            SQL = "INSERT INTO TCC.TBPROFMATE(IDPROFMATE, FKIDMATERIA,  NomeMateria, FKIDFUNC, NOMERELACIONAMENTO, AtivoInativoProfMate)" +
                "VALUES('" + objProfMate.IDProfMate + "','" + objProfMate.FKIDMateria + "','" + objProfMate.NomeMateria + "','" + objProfMate.FKIDFunc + "','" + objProfMate.NomeRelacionamento +  "','" + objProfMate.AtivoInativoProfMate + "')";
            objConexao.ExecutarComando(SQL);
        }

        public DataTable DAOConsultaAtivoProfMate()
        {
            SQL = "SELECT * FROM TCC.TBPROFMATE  WHERE AtivoInativoProfMate = 'A'";
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

        public DataTable DAOConsultaDGVProfMate()
        {
            SQL = "SELECT IDPROFMATE, NOMERELACIONAMENTO FROM TCC.TBPROFMATE  WHERE AtivoInativoProfMate = 'A'";
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

        public DataTable DAOConsultaNomeRelacionamentoProfMate(string Nome)
        {
            SQL = "SELECT * FROM TCC.TBPROFMATE WHERE NOMERELACIONAMENTO = '" + Nome + "'";
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

        public DataTable DAOConsultaNomeRelacionamentoPerfilProf(ProfessorMateria objProfMate)
        {
            SQL = "SELECT NOMERELACIONAMENTO FROM TCC.TBPROFMATE WHERE FKIDFUNC = " + objProfMate.FKIDFunc;
            DataTable t = new DataTable();
            t = objConexao.RetornarDataTable(SQL);
            return t;
        }

        public DataTable DAOConsultaIDProfessor(ProfessorMateria objProfMate)
        {
            SQL = "SELECT * FROM TCC.TBPROFMATE WHERE FKIDFUNC = " + objProfMate.FKIDFunc;
            DataTable t = new DataTable();
            t = objConexao.RetornarDataTable(SQL);
            return t;
        }

    }
}
