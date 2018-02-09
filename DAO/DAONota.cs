using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.DAO
{
    public class DAONota
    {
        ClasseConexaoDAO objConexao = new ClasseConexaoDAO();
        private static string SQL;

        public void DAOCadastraNota1(Nota objNota)
        {
            SQL = "INSERT INTO tcc.tbNota1(IDNota, FKRMAluno, FKIDPMNota, PATNota, PEMNota, TrabalhoNota, TrimestreNota, Participacao, DataNota)" +
                "VALUES(tcc.seqcodigonota1.NEXTVAL, '" + objNota.FKRMAluno + "','" + objNota.FKIDProfMate + "','" + objNota.PATNota + "','" + objNota.PEMNota + "','" + objNota.TrabalhoNota + "','" + objNota.TrimestreNota + "','" + objNota.ParticipacaoNota + "','" + objNota.DataNota + "')";
            objConexao.ExecutarComando(SQL);
        }

        public void DAOCadastraNota2(Nota objNota)
        {
            SQL = "INSERT INTO tcc.tbNota2(IDNota, FKRMAluno, FKIDPMNota, PATNota, PEMNota, TrabalhoNota, TrimestreNota, Participacao, DataNota)" +
                "VALUES(tcc.seqcodigonota2.NEXTVAL, '" + objNota.FKRMAluno + "','" + objNota.FKIDProfMate + "','" + objNota.PATNota + "','" + objNota.PEMNota + "','" + objNota.TrabalhoNota + "','" + objNota.TrimestreNota + "','" + objNota.ParticipacaoNota + "','" + objNota.DataNota + "')";
            objConexao.ExecutarComando(SQL);
        }

        public void DAOCadastraNota3(Nota objNota)
        {
            SQL = "INSERT INTO tcc.tbNota3(IDNota, FKRMAluno, FKIDPMNota, PATNota, PEMNota, TrabalhoNota, TrimestreNota, Participacao, DataNota)" +
                "VALUES(tcc.seqcodigonota3.NEXTVAL, '" + objNota.FKRMAluno + "','" + objNota.FKIDProfMate + "','" + objNota.PATNota + "','" + objNota.PEMNota + "','" + objNota.TrabalhoNota + "','" + objNota.TrimestreNota + "','" + objNota.ParticipacaoNota + "','" +  objNota.DataNota + "')";
            objConexao.ExecutarComando(SQL);
        }

        public DataTable DAOConsultaValidacaoNota1(Nota objNota)
        {
            SQL = "SELECT * FROM TCC.TBNOTA1 WHERE FKIDPMNota = " + objNota.FKIDProfMate + " AND FKRMALUNO = " + objNota.FKRMAluno;
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

        public DataTable DAOConsultaValidacaoNota2(Nota objNota)
        {
            SQL = "SELECT * FROM TCC.TBNOTA2 WHERE FKIDPMNota = " + objNota.FKIDProfMate + " AND FKRMALUNO = " + objNota.FKRMAluno;
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

        public DataTable DAOConsultaValidacaoNota3(Nota objNota)
        {
            SQL = "SELECT * FROM TCC.TBNOTA3 WHERE FKIDPMNota = " + objNota.FKIDProfMate + " AND FKRMALUNO = " + objNota.FKRMAluno;
            DataTable dt = new DataTable();
            dt = objConexao.RetornarDataTable(SQL);
            return dt;
        }

        public void DAOAlteraNota1(Nota objNota)
        {
            SQL = "UPDATE TCC.TBNOTA1 SET PATNOTA = '" + objNota.PATNota + "', PEMNOTA = '" + objNota.PEMNota + "', TrabalhoNota = '" + objNota.TrabalhoNota + "', TrimestreNota = '" + objNota.TrimestreNota + "', Participacao = '" + objNota.ParticipacaoNota + "', DataNota = '" + objNota.DataNota + "' WHERE IDNota = " + objNota.IDNota;
            objConexao.ExecutarComando(SQL);
        }

        public void DAOAlteraNota2(Nota objNota)
        {
            SQL = "UPDATE TCC.TBNOTA2 SET PATNOTA = '" + objNota.PATNota + "', PEMNOTA = '" + objNota.PEMNota + "', TrabalhoNota = '" + objNota.TrabalhoNota + "', TrimestreNota = '" + objNota.TrimestreNota + "', Participacao = '" + objNota.ParticipacaoNota + "', DataNota = '" + objNota.DataNota +  "' WHERE IDNota = " + objNota.IDNota;
            objConexao.ExecutarComando(SQL);
        }

        public void DAOAlteraNota3(Nota objNota)
        {
            SQL = "UPDATE TCC.TBNOTA3 SET PATNOTA = '" + objNota.PATNota + "', PEMNOTA = '" + objNota.PEMNota + "', TrabalhoNota = '" + objNota.TrabalhoNota + "', TrimestreNota = '" + objNota.TrimestreNota + "', Participacao = '" + objNota.ParticipacaoNota + "', DataNota = '" + objNota.DataNota +  "' WHERE IDNota = " + objNota.IDNota;
            objConexao.ExecutarComando(SQL);
        }

        public DataTable DAOConsultaRMNota(Nota objNota)
        {
            SQL = "SELECT * FROM tcc.vw_nota WHERE RM = " + objNota.FKRMAluno;
            DataTable t = new DataTable();
            t = objConexao.RetornarDataTable(SQL);
            return t;
        }

    }
}
