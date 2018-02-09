using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;


namespace TCC5._0.DAO
{
    public class DAOMateria
    {
        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        /* public string DAOCadastraMateria(Materia objMateria)
        {
            string info = "";
            SQL = "INSERT INTO TCC.TBMATERIA(IDMATERIA, NOMEMATERIA, QTDAULA, FKCURSOMATERIA, AIMATERIA)" +
                "VALUES(TCC.SEQIDMATERIA.NETXVAL, '" + objMateria.NomeMateria + "','" + objMateria.QuantidadeDeAula + "','" + objMateria.FKCursoMateria + "','" + objMateria.AIMateria + "')";
            objConexao.ExecutarComando(SQL);

            return info;

        } */

        public void DAOCadastraMateria(Materia objMateria)
        {
            SQL = "INSERT INTO TCC.TBMATERIA(IDMATERIA, NOMEMATERIA, QTDAULA, FKCURSOMATERIA, AIMATERIA)" +
                "VALUES(tcc.SEQIDMATERIA.NEXTVAL, '" + objMateria.NomeMateria + "','" + objMateria.QuantidadeDeAula + "','" + objMateria.FKCursoMateria + "','" + objMateria.AIMateria + "')";
            objConexao.ExecutarComando(SQL);
        }

        public DataTable DAOConsultaAtivoMateria()
        {
            DataTable dt = new DataTable();
            SQL = "SELECT IDMATERIA, NOMEMATERIA, QTDAULA, FKCURSOMATERIA FROM TCC.TBMATERIA WHERE AIMATERIA = 'A'";
            dt = objConexao.RetornarDataTable(SQL);

            return dt;

        }

        public DataTable DAOConsultaInativoMateria()
        {
            DataTable dt = new DataTable();
            SQL = "SELECT IDMATERIA, NOMEMATERIA, QTDAULA, FKCURSOMATERIA FROM TCC.TBMATERIA WHERE AIMATERIA = 'I'";
            dt = objConexao.RetornarDataTable(SQL);

            return dt;
        }

        public DataTable DAOConsultaCodigoMateria(Materia objMateria)
        {
            DataTable dt = new DataTable();
            SQL = "SELECT * FROM TCC.TBMATERIA WHERE IDMATERIA = " + objMateria.IDMateria;
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

        public DataTable DAOConsultaNomeMateria(string Nome)
        {
            SQL = "SELECT * FROM TCC.TBMATERIA WHERE NOMEMATERIA = '" + Nome + "'";
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);

            return dt;
        }

        public void DAODesativaMateria(Materia objMateria)
        {
            SQL = "UPDATE TCC.TBMATERIA SET AIMATERIA = 'I' WHERE IDMATERIA = " + objMateria.IDMateria;
            objConexao.ExecutarComando(SQL);
        }

        public void DAOAtivaMateria(Materia objMateria)
        {
            SQL = "UPDATE TCC.TBMATERIA SET AIMATERIA = 'A' WHERE IDMATERIA = " + objMateria.IDMateria;
            objConexao.ExecutarComando(SQL);
        }

        public void DAOExcluiMateria(Materia objMateria)
        {
            SQL = "DELETE FROM TCC.TBMATERIA WHERE IDMATERIA = " + objMateria.IDMateria;
            objConexao.ExecutarComando(SQL);
        }

        public void DAOAlteraMateria(Materia objMateria)
        {
            SQL = "UPDATE TCC.TBMATERIA SET NOMEMATERIA = '" + objMateria.NomeMateria + "', QTDAULA = '" + objMateria.QuantidadeDeAula + "', FKCursoMateria = '" + objMateria.FKCursoMateria + "', AIMATERIA = '" + objMateria.AIMateria + "' WHERE IDMATERIA = " + objMateria.IDMateria;
            objConexao.ExecutarComando(SQL);
        }


    }
}
