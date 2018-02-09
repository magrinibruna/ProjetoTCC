using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;

namespace TCC5._0.BLL
{
    public class BLLTurma
    {

        DAO.Turma objTurma = new DAO.Turma();
        DAO.DAOTurma objDAOTurma = new DAO.DAOTurma();

        public void BLLCadastroTurma(string FKCursoTurma, string AnoTurma, string NomeTurma, string PeriodoTurma, string CompletoTurma, string AITurma)
        {

            int cFKCursoTurma = Convert.ToInt16(FKCursoTurma);

            objTurma.FKCursoTurma = cFKCursoTurma;
            objTurma.AnoTurma = AnoTurma;
            objTurma.NomeTurma = NomeTurma;
            objTurma.PeriodoTurma = PeriodoTurma;
            objTurma.CompletoTurma = CompletoTurma;
            objTurma.AITurma = AITurma;

            objDAOTurma.DAOCadastraTurma(objTurma);

        }

        public DataTable BLLBuscaTurma()
        {

            DAO.DAOTurma objDAOTurma = new DAO.DAOTurma();
            return objDAOTurma.DAOConsultaAtivoTurma();

        }

        public void BLLConsultaAtivoTurma(DataGridView dgv)
        {

            dgv.DataSource = objDAOTurma.DAOConsultaAtivoTurma();

        }

        public void BLLConsultaInativoTurma(DataGridView dgv)
        {

            dgv.DataSource = objDAOTurma.DAOConsultaInativoTurma();
        }

        public void BLLDesativaTurma(string IDTurma, string AI)
        {

            int cIDTurma = Convert.ToInt16(IDTurma);

            objTurma.IDTurma = cIDTurma;
            objTurma.AITurma = AI;

            objDAOTurma.DAODesativaTurma(objTurma);
        }

        public void BLLAtivaTurma(string IDTurma, string AI)
        {

            int cIDTurma = Convert.ToInt16(IDTurma);

            objTurma.IDTurma = cIDTurma;
            objTurma.AITurma = AI;

            objDAOTurma.DAOAtivaTurma(objTurma);
        }

        public void BLLAtivaDataDeExclusaoTurma(string FKCurso, string Data)
        {

            int cFKCurso = Convert.ToInt16(FKCurso);

            objTurma.FKCursoTurma = cFKCurso;
            objTurma.DataDeExclusao = Data;

            objDAOTurma.DAOAtivaDataDeExclusaoTurma(objTurma);
        }

        public void BLLAlteraDataDeExclusaoTurma(string IDCurso, string Data)
        {

            int cIDCurso = Convert.ToInt16(IDCurso);

            objTurma.FKCursoTurma = cIDCurso;
            objTurma.DataDeExclusao = Data;

            objDAOTurma.DAOAlteraDataDeExclusaoTurma(objTurma);
        }

        public void BLLDesativaDataDeExclusaoTurma(string IDCurso)
        {

            int cIDCurso = Convert.ToInt16(IDCurso);

            objTurma.FKCursoTurma = cIDCurso;

            objDAOTurma.DAODesativaDataDeExclusaoTurma(objTurma);
        }

        public void BLLExcluiTurma(string IDTurma)
        {

            int cIDTurma = Convert.ToInt16(IDTurma);
       
            objTurma.IDTurma = cIDTurma;

            objDAOTurma.DAOExcluiTurma(objTurma);
        }

        public void BLLExcluiCursoTurma(string FKCurso)
        {
            int cFK = Convert.ToInt16(FKCurso);
            objTurma.FKCursoTurma = cFK;
            objDAOTurma.DAOExcluiCursoTurma(objTurma);
        }

        public DataTable BLLConsultaTurmaCodigo(string Codigo)
        {

            int cCodigo = Convert.ToInt16(Codigo);

            objTurma.IDTurma = cCodigo;


            return objDAOTurma.DAOConsultaTurmaCodigo(objTurma);

        }

        public DataTable BLLConsultaCompletoTurmaCurso(string Nome)
        {

            return objDAOTurma.DAOConsultaCompletoTurmaTurma(Nome);

        }

        public void BLLAlteraTurma(string IDTurma, string FKCursoTurma, string AnoTurma, string NomeTurma, string PeriodoTurma, string CompletoTurma, string AITurma)
        {

            int cIDTurma = Convert.ToInt16(IDTurma);
            int cFKCursoTurma = Convert.ToInt16(FKCursoTurma);

            objTurma.IDTurma = cIDTurma;
            objTurma.FKCursoTurma = cFKCursoTurma;
            objTurma.AnoTurma = AnoTurma;
            objTurma.NomeTurma = NomeTurma;
            objTurma.PeriodoTurma = PeriodoTurma;
            objTurma.CompletoTurma = CompletoTurma;
            objTurma.AITurma = AITurma;

            objDAOTurma.DAOAlteraTurma(objTurma);



        }

    }
}
