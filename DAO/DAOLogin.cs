using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;

namespace TCC5._0.DAO
{
    public class DAOLogin
    {

        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        public string DAOCadastroLogin(Login objLogin)
        {

            string info = "";

            SQL = "INSERT INTO TCC.TBLOGIN(CODIGOLOGIN, USUARIOLOGIN, SENHALOGIN, FKNHLOGIN)" +
                "VALUES(tcc.seqcodigologin.NEXTVAL, '" + objLogin.UsuarioLogin + "','" + objLogin.SenhaLogin + "','" + objLogin.FKNHLogin + "')";

            objConexao.ExecutarComando(SQL);
            info = "Inserido Com Sucesso!";

            return info;

        }


        public DataTable DAOConsultaLogin(string Usuario)
        {

            try
            {

                DataTable dt = new DataTable();
                SQL = "SELECT * FROM tcc.tbLogin WHERE UsuarioLogin = '" + Usuario + "'";
                dt = objConexao.RetornarDataTable(SQL);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void DAOAlteraSenha(string Usuario, string Senha)
        {
            SQL = "UPDATE TCC.TBLOGIN SET SENHALOGIN = '" + Senha + "' WHERE USUARIOLOGIN = '" + Usuario + "'";
            objConexao.ExecutarComando(SQL);
        }



    }
}
