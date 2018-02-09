using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.DAO
{
    public class DAOFoto
    {
        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        public void DAOCadastraAlunoFoto(Foto objFoto)
        {
            SQL = "INSERT INTO TCC.TBFOTO(FOTO, FKRMALUNO)" +
                "VALUES('" + objFoto.Diretorio + "','" + objFoto.FKRMAluno + "')";
            objConexao.ExecutarComando(SQL);
        }

        public void DAOCadastraHorarioFoto(Foto objFoto)
        {
            SQL = "INSERT INTO TCC.TBFOTO(FOTO, FKIDCurso)" +
                "VALUES('" + objFoto.Diretorio + "','" + objFoto.FKIDCurso + "')";
            objConexao.ExecutarComando(SQL);
        }

        public DataTable DAOConsultaRMFoto(Foto objFoto)
        {
            SQL = "SELECT * FROM TCC.TBFOTO WHERE FKRMALUNO = " + objFoto.FKRMAluno;
            DataTable t = new DataTable();
            t = objConexao.RetornarDataTable(SQL);
            return t;
        }

        public DataTable DAOConsultaHorarioFoto(Foto objFoto)
        {
            SQL = "SELECT * FROM TCC.TBFOTO WHERE FKIDCurso = " + objFoto.FKIDCurso;
            DataTable t = new DataTable();
            t = objConexao.RetornarDataTable(SQL);
            return t;
        }

        public void DAOAlteraHorarioFoto(Foto objFoto)
        {
            SQL = "UPDATE TCC.TBFOTO SET FOTO = '" + objFoto.Diretorio + "' WHERE FKIDCURSO = " + objFoto.FKIDCurso;
            objConexao.ExecutarComando(SQL);
        }


    }
}
