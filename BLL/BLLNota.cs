using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.BLL
{
    public class BLLNota
    {
        DAO.Nota objNota = new DAO.Nota();
        DAO.DAONota objDAONota = new DAO.DAONota();

        /* public void BLLCadastraNota1(string FKRM, string FKIDPM, string PAT, string PEM, string Trabalho, string Participacao, string Trimestre)
        {
            int cFKRM = Convert.ToInt32(FKRM);
            int cFKIDPM = Convert.ToInt32(FKIDPM);
            double cPAT = Convert.ToDouble(PAT);
            double cPEM = Convert.ToDouble(PEM);
            double cTrabalho = Convert.ToDouble(Trabalho);
            double cParticipacao = Convert.ToDouble(Participacao);
            double cTrimestre = Convert.ToDouble(Trimestre);

            objNota.FKRMAluno = cFKRM;
            objNota.FKIDProfMate = cFKIDPM;
            objNota.PATNota = cPAT;
            objNota.PEMNota = cPEM;
            objNota.TrabalhoNota = cTrabalho;
            objNota.ParticipacaoNota = cParticipacao;
            objNota.TrimestreNota = cTrimestre;

            objDAONota.DAOCadastraNota1(objNota);
        } */

        public void BLLCadastraNota1(string FKRM, string FKIDPM)
        {
            int cFKRM = Convert.ToInt32(FKRM);
            int cFKIDPM = Convert.ToInt32(FKIDPM);

            objNota.FKRMAluno = cFKRM;
            objNota.FKIDProfMate = cFKIDPM;
            objNota.PATNota = "0";
            objNota.PEMNota = "0";
            objNota.TrabalhoNota = "0";
            objNota.ParticipacaoNota = "0";
            objNota.TrimestreNota = "0";
            objNota.DataNota = Convert.ToString(DateTime.Now);

            objDAONota.DAOCadastraNota1(objNota);
        }

        public void BLLCadastraNota2(string FKRM, string FKIDPM)
        {
            int cFKRM = Convert.ToInt32(FKRM);
            int cFKIDPM = Convert.ToInt32(FKIDPM);

            objNota.FKRMAluno = cFKRM;
            objNota.FKIDProfMate = cFKIDPM;
            objNota.PATNota = "0";
            objNota.PEMNota = "0";
            objNota.TrabalhoNota = "0";
            objNota.ParticipacaoNota = "0";
            objNota.TrimestreNota = "0";
            objNota.DataNota = Convert.ToString(DateTime.Now);

            objDAONota.DAOCadastraNota2(objNota);
        }

        public void BLLCadastraNota3(string FKRM, string FKIDPM)
        {
            int cFKRM = Convert.ToInt32(FKRM);
            int cFKIDPM = Convert.ToInt32(FKIDPM);

            objNota.FKRMAluno = cFKRM;
            objNota.FKIDProfMate = cFKIDPM;
            objNota.PATNota = "0";
            objNota.PEMNota = "0";
            objNota.TrabalhoNota = "0";
            objNota.ParticipacaoNota = "0";
            objNota.TrimestreNota = "0";
            objNota.DataNota = Convert.ToString(DateTime.Now);

            objDAONota.DAOCadastraNota3(objNota);
        }

        public DataTable BLLConsultaValidacaoNota1(string FKRM, string FKIDPM)
        {
            int cFKRM = Convert.ToInt32(FKRM);
            int cFKIDPM = Convert.ToInt32(FKIDPM);
            objNota.FKIDProfMate = cFKIDPM;
            objNota.FKRMAluno = cFKRM;
            return objDAONota.DAOConsultaValidacaoNota1(objNota);
        }

        public DataTable BLLConsultaValidacaoNota2(string FKRM, string FKIDPM)
        {
            int cFKRM = Convert.ToInt32(FKRM);
            int cFKIDPM = Convert.ToInt32(FKIDPM);
            objNota.FKIDProfMate = cFKIDPM;
            objNota.FKRMAluno = cFKRM;
            return objDAONota.DAOConsultaValidacaoNota2(objNota);
        }

        public DataTable BLLConsultaValidacaoNota3(string FKRM, string FKIDPM)
        {
            int cFKRM = Convert.ToInt32(FKRM);
            int cFKIDPM = Convert.ToInt32(FKIDPM);
            objNota.FKIDProfMate = cFKIDPM;
            objNota.FKRMAluno = cFKRM;
            return objDAONota.DAOConsultaValidacaoNota3(objNota);
        }



        public void BLLAlteraNota1(string IDNota, string PAT, string PEM, string Trabalho, string Participacao)
        {
          

            int cIDNota = Convert.ToInt32(IDNota);
            double cPAT = Convert.ToDouble(PAT);
            double cPEM = Convert.ToDouble(PEM);
            double cTrabalho = Convert.ToDouble(Trabalho);
            double cParticipacao = Convert.ToDouble(Participacao);
            string Trimestre = Convert.ToString((cPAT + cPEM + cTrabalho + cParticipacao) / 4);

            objNota.IDNota = cIDNota;
            objNota.PATNota = PAT;
            objNota.PEMNota = PEM;
            objNota.TrabalhoNota = Trabalho;
            objNota.ParticipacaoNota = Participacao;
            objNota.TrimestreNota = Trimestre;
            objNota.DataNota = Convert.ToString(DateTime.Now);

            objDAONota.DAOAlteraNota1(objNota);
        }

        public void BLLAlteraNota2(string IDNota, string PAT, string PEM, string Trabalho, string Participacao)
        {


            int cIDNota = Convert.ToInt32(IDNota);
            double cPAT = Convert.ToDouble(PAT);
            double cPEM = Convert.ToDouble(PEM);
            double cTrabalho = Convert.ToDouble(Trabalho);
            double cParticipacao = Convert.ToDouble(Participacao);
            string Trimestre = Convert.ToString((cPAT + cPEM + cTrabalho + cParticipacao) / 4);

            objNota.IDNota = cIDNota;
            objNota.PATNota = PAT;
            objNota.PEMNota = PEM;
            objNota.TrabalhoNota = Trabalho;
            objNota.ParticipacaoNota = Participacao;
            objNota.TrimestreNota = Trimestre;
            objNota.DataNota = Convert.ToString(DateTime.Now);

            objDAONota.DAOAlteraNota2(objNota);
        }

        public void BLLAlteraNota3(string IDNota, string PAT, string PEM, string Trabalho, string Participacao)
        {


            int cIDNota = Convert.ToInt32(IDNota);
            double cPAT = Convert.ToDouble(PAT);
            double cPEM = Convert.ToDouble(PEM);
            double cTrabalho = Convert.ToDouble(Trabalho);
            double cParticipacao = Convert.ToDouble(Participacao);
            string Trimestre = Convert.ToString((cPAT + cPEM + cTrabalho + cParticipacao) / 4);

            objNota.IDNota = cIDNota;
            objNota.PATNota = PAT;
            objNota.PEMNota = PEM;
            objNota.TrabalhoNota = Trabalho;
            objNota.ParticipacaoNota = Participacao;
            objNota.TrimestreNota = Trimestre;
            objNota.DataNota = Convert.ToString(DateTime.Now);

            objDAONota.DAOAlteraNota3(objNota);
        }

         public DataTable BLLConsultaRMNota(string RM)
        {
            int cFKRM = Convert.ToInt32(RM);
            objNota.FKRMAluno = cFKRM;
            return objDAONota.DAOConsultaRMNota(objNota);
        }
    }
}
