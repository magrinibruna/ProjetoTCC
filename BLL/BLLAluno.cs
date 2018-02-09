using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TCC5._0.BLL
{
    public class BLLAluno

    {
        DAO.Aluno objAluno = new DAO.Aluno();
        DAO.DAOAluno objDAOAluno = new DAO.DAOAluno();

        public void BLLCadastraAluno(string RM, string Nome, string CPF, string Email, string AIAluno, string DT, string FKTurma)
        {
            int cRM = Convert.ToInt32(RM);
            int cFKTurma = Convert.ToInt16(FKTurma);

            objAluno.RMAluno = cRM;
            objAluno.NomeAluno = Nome;
            objAluno.CPFAluno = CPF;
            objAluno.EmailAluno = Email;
            objAluno.AIAluno = AIAluno;
            objAluno.DTAluno = DT;
            objAluno.FKTurmaAluno = cFKTurma;

            objDAOAluno.DAOCadastraAluno(objAluno);

        }

        public void BLLConsultaAtivoAluno(DataGridView dgv)
        {

            dgv.DataSource = objDAOAluno.DAOConsultaAtivoAluno();
        }

        public DataTable BLLConsultaDGVIDAluno(string FK)
        {
            int cFK = Convert.ToInt32(FK);
            objAluno.FKTurmaAluno = cFK;
            return objDAOAluno.DAOConsultaDGVIDAluno(objAluno);
        }

        public void BLLConsultaInativoAluno(DataGridView dgv)
        {

            dgv.DataSource = objDAOAluno.DAOConsultaInativoAluno();
        }

        public void BLLDesativaAluno(string RMAluno, string AI)
        {

            int cRMAluno = Convert.ToInt32(RMAluno);

            objAluno.RMAluno = cRMAluno;
            objAluno.AIAluno = AI;

            objDAOAluno.DAODesativaAluno(objAluno);
        }

        public void BLLAtivaAluno(string RMAluno, string AI)
        {

            int cRMAluno = Convert.ToInt16(RMAluno);

            objAluno.RMAluno = cRMAluno;
            objAluno.AIAluno = AI;

            objDAOAluno.DAOAtivaAluno(objAluno);
        }

        public void BLLExcluiAluno(string RMAluno)
        {

            int cRMAluno = Convert.ToInt16(RMAluno);

            objAluno.RMAluno = cRMAluno;

            objDAOAluno.DAOExcluiAluno(objAluno);
        }


        public DataTable BLLConsultaRMAluno(string RMAluno)
        {

            int cRMAluno = Convert.ToInt32(RMAluno);

            objAluno.RMAluno = cRMAluno;


            return objDAOAluno.DAOConsultaRMAluno(objAluno);
            
        }

        public DataTable BLLConsultaCPFAluno(string CPF)
        {

            return objDAOAluno.DAOConsultaCPFAluno(CPF);

        }

        public void BLLAlteraAluno(string RM, string Nome, string CPF, string Email, string DT, string Turma)
        {

            int cRM = Convert.ToInt32(RM);
            int cTurma = Convert.ToInt16(Turma);

            objAluno.RMAluno = cRM;
            objAluno.NomeAluno = Nome;
            objAluno.CPFAluno = CPF;
            objAluno.EmailAluno = Email;
            objAluno.DTAluno = DT;
            objAluno.FKTurmaAluno = cTurma;

            objDAOAluno.DAOAlteraAluno(objAluno);


        }

        public void BLLAlteraAlunoAluno(string RM, string Email)
        {
            int cRM = Convert.ToInt32(RM);

            objAluno.RMAluno = cRM;
            objAluno.EmailAluno = Email;

            objDAOAluno.DAOAlteraAlunoAluno(objAluno);
        }


    }
}
