using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.DAO
{
    public class DAOCurso
    {

        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        public string DAOCadastraCurso(Curso objCurso)
        {

            string info = "";

            SQL = "INSERT INTO TCC.TBCURSO(IDCURSO, NOMECURSO, ABREVIATURACURSO, AICURSO)" +
                "VALUES(tcc.SEQIDCurso.NEXTVAL, '" + objCurso.NomeCurso + "','" + objCurso.AbreviaturaCurso + "','" + objCurso.AICurso + "')";

            objConexao.ExecutarComando(SQL);
            info = "Inserido Com Sucesso!";

            return info;

        }

        public DataTable DAOConsultaAtivoCurso()
        {
            try
            {

                DataTable dt = new DataTable();
                SQL = "SELECT IDCurso, NomeCurso, AbreviaturaCurso FROM TCC.TBCURSO WHERE AICURSO = 'A'";
                dt = objConexao.RetornarDataTable(SQL);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable DAOConsultaInativoCurso()
        {
            try
            {

                DataTable dt = new DataTable();
                SQL = "SELECT IDCurso, NomeCurso, AbreviaturaCurso FROM TCC.TBCURSO WHERE AICURSO = 'I'";
                dt = objConexao.RetornarDataTable(SQL);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable DAOConsultaNomeCurso(string Nome)
        {

            try
            {

                DataTable dt = new DataTable();
                SQL = "SELECT IDCurso, NomeCurso, AbreviaturaCurso FROM TCC.TBCURSO WHERE NOMECURSO = '" + Nome + "'";
                dt = objConexao.RetornarDataTable(SQL);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public DataTable DAOConsultaIDCurso(Curso objCurso)
        {

            DataTable dt = new DataTable();
            SQL = "SELECT IDCurso, NomeCurso, AbreviaturaCurso FROM TCC.TBCURSO WHERE IDCURSO = " + objCurso.IDCurso;
            dt = objConexao.RetornarDataTable(SQL);

            return dt;

        }

        public DataTable DAOConsultaIDCompletoCurso(Curso objCurso)
        {

            DataTable dt = new DataTable();
            SQL = "SELECT * FROM TCC.TBCURSO WHERE IDCURSO = " + objCurso.IDCurso;
            dt = objConexao.RetornarDataTable(SQL);

            return dt;

        }

        public void DAOAtivaCurso(Curso objCurso)
        {
            SQL = "UPDATE TCC.TBCURSO SET AICURSO = 'A' WHERE IDCURSO = " + objCurso.IDCurso;
            objConexao.ExecutarComando(SQL);
        }

        public void DAODesativaCurso(Curso objCurso)
        {
            SQL = "UPDATE TCC.TBCURSO SET AICURSO = 'I' WHERE IDCURSO = " + objCurso.IDCurso;
            objConexao.ExecutarComando(SQL);
        }

        public void DAOAlteraDataDeExclusaoCurso(Curso objCurso)
        {
            SQL = "UPDATE TCC.TBCURSO SET  DATADEEXCLUSAOCurso = '" + objCurso.DataDeExclusao + "' WHERE IDCURSO = " + objCurso.IDCurso;
            objConexao.ExecutarComando(SQL);
        }

        public void DAODesativaDataDeExclusaoCurso(Curso objCurso)
        {
            SQL = "UPDATE TCC.TBCURSO SET AICURSO = 'I' WHERE IDCURSO = " + objCurso.IDCurso;
            objConexao.ExecutarComando(SQL);
        }



        public void DAOAlteraCurso(Curso objCurso)
        {
            SQL = "UPDATE TCC.TBCURSO SET NOMECURSO = '" + objCurso.NomeCurso + "', ABREVIATURACURSO = '" + objCurso.AbreviaturaCurso + "' WHERE IDCURSO = " + objCurso.IDCurso;
            objConexao.ExecutarComando(SQL);
        }

        public void DAOExcluiCurso(Curso objCurso)
        {
            SQL = "DELETE FROM TCC.TBCURSO WHERE IDCURSO = " + objCurso.IDCurso;
            objConexao.ExecutarComando(SQL); 
        }

    }
}
