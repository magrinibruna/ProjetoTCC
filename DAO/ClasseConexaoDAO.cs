using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace TCC5._0.DAO
{
    public class ClasseConexaoDAO
    {
        public static OracleConnection connection;
        private static OracleCommand cmd;
        private static OracleDataAdapter da;
        private static OracleDataReader dr;
        private static OracleParameter p;
        private static OracleParameter q;
        private static DataSet ds;
        private static string SQL;
        private static string dado;
        private static DataTable dt;

        private static string connectionCOM = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LOCALHOST)(PORT=1521)))(CONNECT_DATA=(SID=xe)));User ID=SYS;Password=123456; DBA Privilege=SYSDBA;";

        public static string Conexao()
        {
            connection = new OracleConnection(connectionCOM);
            string info = "";
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    info = "Conectado com a versão Oracle" + connection.ServerVersion + "Utilizando a fonte " + connection.DataSource;
                }

            }
            catch (OracleException ex)
            {

                return ex.Message;
            }
            return info + " Estado conexao " + connection.State.ToString() + "Ok";
        }


        public DataTable RetornarDataTable(string sqlComando)
        {
            try
            {
                Conexao();
                DataTable dt = new DataTable();
                cmd = new OracleCommand(sqlComando, connection);
                da = new OracleDataAdapter(cmd);
                da.Fill(dt);
                FinalizarConexao();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void FinalizarConexao()
        {
            connection.Close();
            connection.Dispose();
        }

        public OracleDataReader RetornarDataReader(string sqlComando)
        {

            Conexao();

            cmd = new OracleCommand(sqlComando, connection);
            dr = cmd.ExecuteReader();

            return dr;


        }



        public DataSet RetornarDataSet(string sqlComando)
        {
            try
            {
                Conexao();
                ds = new DataSet();
                cmd = new OracleCommand(sqlComando, connection);
                da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExecutarComando(string sqlComando)
        {
            try
            {
                Conexao();
                OracleCommand cmd = new OracleCommand(sqlComando, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                FinalizarConexao();
            }
        }
    }

}