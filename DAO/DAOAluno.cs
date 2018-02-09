
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using System.Windows.Forms;

namespace TCC5._0.DAO
{
    public class DAOAluno
    {

        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        public string DAOCadastraAluno(Aluno objAluno)
        {

            try
            {

                string info = "";

                SQL = "INSERT INTO TCC.TBALUNO(RMALUNO, NOMEALUNO, CPFALUNO, EMAILALUNO, AIALUNO, DTALUNO, FKTURMAALUNO)" +
                    "VALUES('" + objAluno.RMAluno + "','" + objAluno.NomeAluno + "','" + objAluno.CPFAluno + "','" + objAluno.EmailAluno + "','" + objAluno.AIAluno + "','" + objAluno.DTAluno + "','" + objAluno.FKTurmaAluno + "')";

                objConexao.ExecutarComando(SQL);
                info = "Inserido Com Sucesso!";
                return info;


            }
            catch (OracleException ex)
            {

                return ex.Message;
            }


        }


        public DataTable DAOConsultaAtivoAluno()
        {
            try
            {
                DataTable dt = new DataTable();
                string SQL = "SELECT RMALUNO, NOMEALUNO, CPFALUNO, EMAILALUNO, DTALUNO, FKTURMAALUNO FROM TCC.TBALUNO WHERE AIALUNO = 'A'";
                dt = objConexao.RetornarDataTable(SQL);

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable DAOConsultaDGVIDAluno(Aluno objAluno)
        {
            DataTable dt = new DataTable();
            SQL = "SELECT RMALUNO, NOMEALUNO, CPFALUNO, EMAILALUNO, DTALUNO, FKTURMAALUNO FROM TCC.TBALUNO WHERE FKTURMAALUNO = " + objAluno.FKTurmaAluno;
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }


        public DataTable DAOConsultaInativoAluno()
        {
            try
            {
                DataTable dt = new DataTable();
                string SQL = "SELECT * FROM TCC.TBALUNO WHERE AIALUNO = 'I'";
                dt = objConexao.RetornarDataTable(SQL);

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DAODesativaAluno(Aluno objAluno)
        {

            SQL = "UPDATE TCC.TBALUNO SET AIALUNO = 'I' WHERE RMALUNO = " + objAluno.RMAluno;
            objConexao.ExecutarComando(SQL);

        }

        public void DAOAtivaAluno(Aluno objAluno)
        {

            SQL = "UPDATE TCC.TBALUNO SET AIALUNO = 'A' WHERE RMALUNO = " + objAluno.RMAluno;
            objConexao.ExecutarComando(SQL);
            
        }


        public void DAOExcluiAluno(Aluno objAluno)
        {

            SQL = "DELETE FROM TCC.TBALUNO WHERE RMALUNO = " + objAluno.RMAluno;
            objConexao.ExecutarComando(SQL);

        }

        public DataTable DAOConsultaRMAluno(Aluno objAluno)
        {

            DataTable dt = new DataTable();
            SQL = "SELECT * FROM TCC.TBALUNO WHERE RMALUNO = " + objAluno.RMAluno;
            dt = objConexao.RetornarDataTable(SQL);

            return dt;

        }

        public DataTable DAOConsultaCPFAluno(string CPF)
        {
            DataTable dt = new DataTable();
            SQL = "SELECT * FROM TCC.TBALUNO WHERE CPFALUNO = '" + CPF + "'";
            dt = objConexao.RetornarDataTable(SQL);

            return dt;
        }

        public void DAOAlteraAluno(Aluno objAluno)
        {

            SQL = "UPDATE TCC.TBALUNO SET NOMEALUNO = '" + objAluno.NomeAluno + "', CPFAluno = '" + objAluno.CPFAluno + "', EMAILALUNO = '" + objAluno.EmailAluno + "', DTAluno = '" + objAluno.DTAluno + "', FKTurmaAluno = '" + objAluno.FKTurmaAluno + "' WHERE RMALUNO = " + objAluno.RMAluno;
            objConexao.ExecutarComando(SQL);

        }

        public void DAOAlteraAlunoAluno(Aluno objAluno)
        {
            SQL = "UPDATE TCC.TBALUNO SET EmailAluno = '" + objAluno.EmailAluno + "' WHERE RMALUNO = " + objAluno.RMAluno;
            objConexao.ExecutarComando(SQL);
        }
 


    }
}
