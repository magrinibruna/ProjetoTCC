using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TCC5._0.BLL
{
    public class BLLCurso
    {

        DAO.Curso objCurso = new DAO.Curso();
        DAO.DAOCurso objDAOCurso = new DAO.DAOCurso();

        public void BLLCadastraCurso(string NomeCurso, string AbreviaturaCurso, string AI)
        {

            objCurso.NomeCurso = NomeCurso;
            objCurso.AbreviaturaCurso = AbreviaturaCurso;
            objCurso.AICurso = AI;

            objDAOCurso.DAOCadastraCurso(objCurso);

        }

        public void BLLConsultaAtivoCurso(DataGridView dgv)
        {

            dgv.DataSource = objDAOCurso.DAOConsultaAtivoCurso();

        }

        public void BLLConsultaInativoCurso(DataGridView dgv)
        {

            dgv.DataSource = objDAOCurso.DAOConsultaInativoCurso();

        }

        public DataTable BLLConsultaAtivoComboBoxCurso()
        {

            return objDAOCurso.DAOConsultaAtivoCurso();

        }

        public DataTable BLLConsultaNomeCurso(string Nome)
        {

            return objDAOCurso.DAOConsultaNomeCurso(Nome);

        }

        public DataTable BLLConsultaIDCurso(string ID)
        {

            int cID = Convert.ToInt16(ID);
            objCurso.IDCurso = cID;

            return objDAOCurso.DAOConsultaIDCurso(objCurso);

        }

        public DataTable BLLConsultaIDCompletoCurso(string ID)
        {

            int cID = Convert.ToInt16(ID);
            objCurso.IDCurso = cID;

            return objDAOCurso.DAOConsultaIDCompletoCurso(objCurso);

        }

        public void BLLAtivaCurso(string ID)
        {
            int cID = Convert.ToInt16(ID);
            objCurso.IDCurso = cID;
            objDAOCurso.DAOAtivaCurso(objCurso);
        }

        public void BLLDesativaCurso(string ID)
        {
            int cID = Convert.ToInt16(ID);
            objCurso.IDCurso = cID;
            objDAOCurso.DAODesativaCurso(objCurso);
        }

        public void BLLAlteraDataDeExclusaoCurso(string ID, string Data)
        {
            int cID = Convert.ToInt16(ID);
            objCurso.IDCurso = cID;
            objCurso.DataDeExclusao = Data;
            objDAOCurso.DAOAlteraDataDeExclusaoCurso(objCurso);
        }

        public void BLLDesativaDataDeExclusaoCurso(string ID)
        {
            int cID = Convert.ToInt16(ID);
            objCurso.IDCurso = cID;
            objDAOCurso.DAODesativaDataDeExclusaoCurso(objCurso);
        }

        public void BLLAlteraCurso(string ID, string Nome, string Abreviatura)
        {
            int cID = Convert.ToInt16(ID);

            objCurso.IDCurso = cID;
            objCurso.NomeCurso = Nome;
            objCurso.AbreviaturaCurso = Abreviatura;

            objDAOCurso.DAOAlteraCurso(objCurso);

        }

        public void DAOExcluiCurso(string ID)
        {
            int cID = Convert.ToInt16(ID);

            objCurso.IDCurso = cID;

            objDAOCurso.DAOExcluiCurso(objCurso);
        }

    }
}
