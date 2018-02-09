using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data;
using System.Windows.Forms;

namespace TCC5._0.BLL
{
    public class BLLProfessorMateria
    {
        DAO.ProfessorMateria objProfMate = new DAO.ProfessorMateria();
        DAO.DAOProfessorMateria objDAOProfMate = new DAO.DAOProfessorMateria();

        public void BLLCadastroProfMate(string IDProfMate, string NomeMateria, string NomeRelacionamento, string FKMateria, string FKFunc)
        {
            int cIDProfMate = Convert.ToInt32(IDProfMate);
            int cFKMateria = Convert.ToInt16(FKMateria);
            int cFKFunc = Convert.ToInt32(FKFunc);

            objProfMate.IDProfMate = cIDProfMate;
            objProfMate.FKIDMateria = cFKMateria;
            objProfMate.NomeMateria = NomeMateria;
            objProfMate.FKIDFunc = cFKFunc;
            objProfMate.NomeRelacionamento = NomeRelacionamento;
            objProfMate.AtivoInativoProfMate = "A";

            objDAOProfMate.DAOCadastroProfMate(objProfMate);

           
        }

        public DataTable BLLConsultaProfMate()
        {
            return objDAOProfMate.DAOConsultaAtivoProfMate();
        }

        public DataTable BLLConsultaNomeRelacionamentoProfMate(string Nome)
        {
            return objDAOProfMate.DAOConsultaNomeRelacionamentoProfMate(Nome);
        }

        public void BLLConsultaDGVProfMate(DataGridView dgv)
        {
            dgv.DataSource = objDAOProfMate.DAOConsultaDGVProfMate();
        }

        public DataTable BLLConsultaNomeRelacionamentoPerfilProf(string ID)
        {
            int cID = Convert.ToInt32(ID);
            objProfMate.FKIDFunc = cID;
            return objDAOProfMate.DAOConsultaNomeRelacionamentoPerfilProf(objProfMate);
        }

        public DataTable BLLConsultaIDProfessor(string ID)
        {
            int cID = Convert.ToInt32(ID);
            objProfMate.FKIDFunc = cID;
            return objDAOProfMate.DAOConsultaIDProfessor(objProfMate);
        }

    }
}
