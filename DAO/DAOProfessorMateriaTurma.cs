using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.DAO
{
    public class DAOProfessorMateriaTurma
    {
        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        public void DAOCadastraProfMateTurma(ProfessorMateriaTurma objProfMateTurma)
        {

            SQL = "INSERT INTO TCC.TBPROFMATETURMA(IDPROFMATETURMA, FKIDPROFMATE, FKIDTURMA, AtivoInativoProfMateTurma, NOMETURMA)" +
            "VALUES('" + objProfMateTurma.IDProfMateTurma + "','" + objProfMateTurma.FKIDProfMate + "','" + objProfMateTurma.FKIDTurma + "','" + objProfMateTurma.AtivoInativoProfMateTurma + "','" + objProfMateTurma.NomeTurma + "')";
            objConexao.ExecutarComando(SQL);

        }

        public DataTable DAOConsultaAtivoProfMateTurma()
        {
            DataTable dt = new DataTable();
            SQL = "SELECT * FROM TCC.TBPROFMATETURMA WHERE AtivoInativoProfMateTurma = 'A'";
            dt = objConexao.RetornarDataTable(SQL);

            return dt;
        }

        public DataTable DAOConsultaIDProfMateProfMateTurma(ProfessorMateriaTurma objProfMateTurma)
        {
            DataTable dt = new DataTable();
            SQL = "SELECT * FROM TCC.TBPROFMATETURMA WHERE FKIDProfMate = " + objProfMateTurma.FKIDProfMate;
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

        public DataTable DAOConsultaViewProfMateTurma()
        {
            DataTable dt = new DataTable();
            SQL = "SELECT * FROM tcc.vw_profmateturma";
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

    }
}
