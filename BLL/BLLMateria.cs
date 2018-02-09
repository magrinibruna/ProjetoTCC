using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TCC5._0.BLL
{
    public class BLLMateria
    {
        DAO.Materia objMateria = new DAO.Materia();
        DAO.DAOMateria objDAOMateria = new DAO.DAOMateria();

        public void BLLCadastraMateria(string Nome, string Quantidade, string FK, string AI)
        {
            int cQuantidade = Convert.ToInt16(Quantidade);
            int cFK = Convert.ToInt16(FK);

            objMateria.NomeMateria = Nome;
            objMateria.QuantidadeDeAula = cQuantidade;
            objMateria.FKCursoMateria = cFK;
            objMateria.AIMateria = AI;

            objDAOMateria.DAOCadastraMateria(objMateria);
        }

        public void BLLConsultaAtivoMateria(DataGridView dgv)
        {
            dgv.DataSource = objDAOMateria.DAOConsultaAtivoMateria();
        }

        public void BLLConsultaInativoMateria(DataGridView dgv)
        {
            dgv.DataSource = objDAOMateria.DAOConsultaInativoMateria();
        }

        public DataTable BLLConsultaCodigoMateria(string ID)
        {
            int cID = Convert.ToInt16(ID);
            objMateria.IDMateria = cID;
            return objDAOMateria.DAOConsultaCodigoMateria(objMateria);

        }

        public DataTable BLLConsultaComboBoxMateria()
        {
            return objDAOMateria.DAOConsultaAtivoMateria();

        }

        public DataTable BLLConsultaNomeMateria(string Nome)
        {
            return objDAOMateria.DAOConsultaNomeMateria(Nome);
        }

        public void BLLDesativaMateria(string ID)
        {
            int cID = Convert.ToInt16(ID);
            objMateria.IDMateria = cID;
            objDAOMateria.DAODesativaMateria(objMateria);
        }

        public void BLLAtivaMateria(string ID)
        {
            int cID = Convert.ToInt16(ID);
            objMateria.IDMateria = cID;
            objDAOMateria.DAOAtivaMateria(objMateria);

        }

        public void BLLExcluiMateria(string ID)
        {
            int cID = Convert.ToInt16(ID);
            objMateria.IDMateria = cID;
            objDAOMateria.DAOExcluiMateria(objMateria);
        }

        public void BLLAlteraMateria(string ID, string Nome, string Quantidade, string FKCurso, string AI)
        {
            int cID = Convert.ToInt16(ID);
            int cQuantidade = Convert.ToInt16(Quantidade);
            int cFKCurso = Convert.ToInt16(FKCurso);

            objMateria.IDMateria = cID;
            objMateria.NomeMateria = Nome;
            objMateria.QuantidadeDeAula = cQuantidade;
            objMateria.FKCursoMateria = cFKCurso;
            objMateria.AIMateria = AI;

            objDAOMateria.DAOAlteraMateria(objMateria);

        }


    }
}
