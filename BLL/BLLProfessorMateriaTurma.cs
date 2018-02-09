using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TCC5._0.BLL
{
    public class BLLProfessorMateriaTurma
    {
        DAO.ProfessorMateriaTurma objProfMateTurma = new DAO.ProfessorMateriaTurma();
        DAO.DAOProfessorMateriaTurma objDAOProfMateTurma = new DAO.DAOProfessorMateriaTurma();

        public void BLLCadastroProfMateTurma(string IDProfMateTurma, string FKIDProfMate, string FKIDTurma, string NomeTurma)
        {
            int cIDProfMateTurma = Convert.ToInt32(IDProfMateTurma);
            int cFKIDProfMate = Convert.ToInt32(FKIDProfMate);
            int cFKIDTurma = Convert.ToInt32(FKIDTurma);

            objProfMateTurma.IDProfMateTurma = cIDProfMateTurma;
            objProfMateTurma.FKIDProfMate = cFKIDProfMate;
            objProfMateTurma.FKIDTurma = cFKIDTurma;
            objProfMateTurma.AtivoInativoProfMateTurma = "A";
            objProfMateTurma.NomeTurma = NomeTurma;

            objDAOProfMateTurma.DAOCadastraProfMateTurma(objProfMateTurma);


        }

        public DataTable BLLConsultaIDProfMateProfMateTurma(string FK)
        {
            int cFK = Convert.ToInt32(FK);
            objProfMateTurma.FKIDProfMate = cFK;
            return objDAOProfMateTurma.DAOConsultaIDProfMateProfMateTurma(objProfMateTurma);
        }

        public void BLLConsultaViewProfMateTurma(DataGridView dgv)
        {
            dgv.DataSource = objDAOProfMateTurma.DAOConsultaViewProfMateTurma();
        }

    }
}
