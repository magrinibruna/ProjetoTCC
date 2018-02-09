using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.DAO
{
    public class DAOFuncionario
    {
        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        public string DAOCadastraProfessor(Funcionario objFunc)
        {

            string info = "";

            SQL = "INSERT INTO tcc.tbFunc(IDFUNC, NOMEFUNC, CPFFUNC, AIFUNC)" +
                "VALUES('" + objFunc.IDFunc + "','" + objFunc.NomeFunc + "','" + objFunc.CPFFunc + "','" + objFunc.AIFunc + "')";

            objConexao.ExecutarComando(SQL);
            info = "Inserido Com Sucesso!";

            return info;

        }

        public DataTable DAOConsultaAtivoProfessor()
        {
            SQL = "SELECT IDFUNC, NOMEFUNC, CPFFUNC FROM TCC.TBFUNC WHERE AIFUNC = 'A'";
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);

            return dt;

        }

        public DataTable DAOConsultaInativoProfessor()
        {
            SQL = "SELECT IDFUNC, NOMEFUNC, CPFFUNC FROM TCC.TBFUNC WHERE AIFUNC = 'I'";
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);

            return dt;

        }

        public DataTable DAOConsultaCodigoProfessor(Funcionario objFunc)
        {
            SQL = "SELECT * FROM TCC.TBFUNC WHERE IDFUNC = " + objFunc.IDFunc;
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);

            return dt;
        }

        public DataTable DAOConsultaNomeProfessor(string Nome)
        {
            SQL = "SELECT * FROM TCC.TBFUNC WHERE NOMEFUNC = '" + Nome + "'";
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);

            return dt;
        }

        public void DAOAtivaProfessor(Funcionario objFunc)
        {
            SQL = "UPDATE TCC.TBFUNC SET AIFUNC = 'A' WHERE IDFUNC = " + objFunc.IDFunc;
            objConexao.ExecutarComando(SQL);
        }

        public void DAODesativaProfessor(Funcionario objFunc)
        {
            SQL = "UPDATE TCC.TBFUNC SET AIFUNC = 'I' WHERE IDFUNC = " + objFunc.IDFunc;
            objConexao.ExecutarComando(SQL);
       }

        public void DAOAlteraProfessor(Funcionario objFunc)
        {
            SQL = "UPDATE TCC.TBFUNC SET NOMEFUNC = '" + objFunc.NomeFunc + "', CPFFUNC = '" + objFunc.CPFFunc + "' WHERE IDFUNC = " + objFunc.IDFunc;
            objConexao.ExecutarComando(SQL);
        }

        public void DAOExcluiProfessor(Funcionario objFunc)
        {
            SQL = "DELETE FROM TCC.TBFUNC WHERE IDFUNC = " + objFunc.IDFunc;
            objConexao.ExecutarComando(SQL);
        }
    }
}
