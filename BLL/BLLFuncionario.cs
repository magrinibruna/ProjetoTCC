using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TCC5._0.BLL
{
    public class BLLFuncionario
    {
        DAO.Funcionario objFunc = new DAO.Funcionario();
        DAO.DAOFuncionario objDAOFunc = new DAO.DAOFuncionario();

        public void BLLCadastraProfessor(string Codigo, string Nome, string CPF, string AI)
        {
            int cCodigo = Convert.ToInt32(Codigo);

            objFunc.IDFunc = cCodigo;
            objFunc.NomeFunc = Nome;
            objFunc.CPFFunc = CPF;
            objFunc.AIFunc = AI;

            objDAOFunc.DAOCadastraProfessor(objFunc);

        }

        public void BLLConsultaAtivoProfessor(DataGridView dgv)
        {
            dgv.DataSource = objDAOFunc.DAOConsultaAtivoProfessor();
        }

        public void BLLConsultaInativoProfessor(DataGridView dgv)
        {
            dgv.DataSource = objDAOFunc.DAOConsultaInativoProfessor();
        }

        public DataTable BLLConsultaCodigoProfessor(string ID)
        {
            int cID = Convert.ToInt32(ID);
            objFunc.IDFunc = cID;

            return objDAOFunc.DAOConsultaCodigoProfessor(objFunc);
        }

        public DataTable BLLConsultaComboBoxProfessor()
        {
            return objDAOFunc.DAOConsultaAtivoProfessor();

        }

        public DataTable BLLConsultaNomeProfessor(string Nome)
        {
            return objDAOFunc.DAOConsultaNomeProfessor(Nome);
        }

        public void BLLAtivaProfessor(string ID)
        {
            int cID = Convert.ToInt32(ID);
            objFunc.IDFunc = cID;

            objDAOFunc.DAOAtivaProfessor(objFunc);
        }

        public void BLLDesativaProfessor(string ID)
        {
            int cID = Convert.ToInt32(ID);
            objFunc.IDFunc = cID;

            objDAOFunc.DAODesativaProfessor(objFunc);
        }

        public void BLLAlteraProfessor(string ID, string Nome, string CPF)
        {
            int cID = Convert.ToInt32(ID);

            objFunc.IDFunc = cID;
            objFunc.NomeFunc = Nome;
            objFunc.CPFFunc = CPF;

            objDAOFunc.DAOAlteraProfessor(objFunc);

        }

        public void DAOExcluiProfessor(string ID)
        {
            int cID = Convert.ToInt32(ID);
            objFunc.IDFunc = cID;

            objDAOFunc.DAOExcluiProfessor(objFunc);
        }

    }
}
