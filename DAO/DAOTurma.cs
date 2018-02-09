using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;

namespace TCC5._0.DAO
{
    public class DAOTurma
    {


        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        public string DAOCadastraTurma(Turma objTurma)
        {

               string info = "";

                SQL = "INSERT INTO TCC.TBTURMA(IDTURMA, FKCURSOTURMA, ANOTURMA, NOMETURMA, PERIODOTURMA, CompletoTurma, AITurma)" +
                    "VALUES(TCC.SEQIDTURMA.NEXTVAL, '" + objTurma.FKCursoTurma + "','" + objTurma.AnoTurma + "','" + objTurma.NomeTurma + "','" + objTurma.PeriodoTurma + "','" + objTurma.CompletoTurma + "','" + objTurma.AITurma +"')";

                objConexao.ExecutarComando(SQL);
                info = "Inserido Com Sucesso!";
                return info;



        }


        public DataTable DAOConsultaAtivoTurma()
        {
            try
            {

                DataTable dt = new DataTable();
                SQL = "SELECT IDTurma, FKCursoTurma, AnoTurma, NomeTurma, PeriodoTurma, CompletoTurma FROM TCC.TBTURMA WHERE AITURMA = 'A'";
                dt = objConexao.RetornarDataTable(SQL);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public DataTable DAOConsultaInativoTurma()
        {
            try
            {
                DataTable dt = new DataTable();
                string SQL = "SELECT IDTurma, FKCursoTurma, AnoTurma, NomeTurma, PeriodoTurma, CompletoTurma FROM TCC.TBTURMA WHERE AITURMA = 'I'";
                dt = objConexao.RetornarDataTable(SQL);

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DAODesativaTurma(Turma objTurma)
        {

            SQL = "UPDATE TCC.TBTURMA SET AITURMA = 'I' WHERE IDTURMA = " + objTurma.IDTurma;
            objConexao.ExecutarComando(SQL);

        }

        public void DAOAtivaTurma(Turma objTurma)
        {

            SQL = "UPDATE TCC.TBTURMA SET AITURMA = 'A' WHERE IDTURMA = " + objTurma.IDTurma;
            objConexao.ExecutarComando(SQL);

        }

        public void DAOAtivaDataDeExclusaoTurma(Turma objTurma)
        {

            SQL = "UPDATE TCC.TBTURMA SET AITURMA = 'A' WHERE FKCURSOTURMA = " + objTurma.FKCursoTurma + " AND DATADEEXCLUSAOTURMA = " + objTurma.DataDeExclusao;
            objConexao.ExecutarComando(SQL);

        }

        public void DAOAlteraDataDeExclusaoTurma(Turma objTurma)
        {

            SQL = "UPDATE TCC.TBTURMA SET DataDeExclusaoTurma = '" + objTurma.DataDeExclusao + "' WHERE FKCURSOTURMA = " + objTurma.FKCursoTurma;
            objConexao.ExecutarComando(SQL);

        }

        public void DAODesativaDataDeExclusaoTurma(Turma objTurma)
        {

            SQL = "UPDATE TCC.TBTURMA SET AITURMA = 'I'  WHERE FKCURSOTURMA = " + objTurma.FKCursoTurma;
            objConexao.ExecutarComando(SQL);

        }

        public void DAOExcluiTurma(Turma objTurma)
        {

            SQL = "DELETE FROM TCC.TBTURMA WHERE IDTURMA = " + objTurma.IDTurma;
            objConexao.ExecutarComando(SQL);

        }

        public void DAOExcluiCursoTurma(Turma objTurma)
        {
            SQL = "DELETE FROM TCC.TBTURMA WHERE FKCURSOTURMA = " + objTurma.FKCursoTurma;
            objConexao.ExecutarComando(SQL);
        }

        public DataTable DAOConsultaTurmaCodigo(Turma objTurma)
        {

            DataTable dt = new DataTable();
            SQL = "SELECT * FROM TCC.TBTURMA WHERE IDTURMA = " + objTurma.IDTurma;
            dt = objConexao.RetornarDataTable(SQL);

            return dt;

        }

        public DataTable DAOConsultaCompletoTurmaTurma(string Nome)
        {

            try
            {

                DataTable dt = new DataTable();
                SQL = "SELECT IDTurma, FKCursoTurma, AnoTurma, NomeTurma, PeriodoTurma, CompletoTurma, AITurma FROM TCC.TBTURMA WHERE COMPLETOTURMA = '" + Nome + "'";
                dt = objConexao.RetornarDataTable(SQL);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void DAOAlteraTurma(Turma objTurma)
        {

            SQL = "UPDATE TCC.TBTURMA SET FKCursoTurma = '" + objTurma.FKCursoTurma + "', AnoTurma = '" + objTurma.AnoTurma + "', NomeTurma = '" + objTurma.NomeTurma + "', PeriodoTurma = '" + objTurma.PeriodoTurma + "', CompletoTurma = '" + objTurma.CompletoTurma + "', AITurma = '" + objTurma .AITurma + "' WHERE IDTurma = " + objTurma.IDTurma;
            objConexao.ExecutarComando(SQL);

        }
 




    }
}
