using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TCC5._0.BLL
{
    public class BLLLogin
    {
        DAO.Login objLogin = new DAO.Login();
        DAO.DAOLogin objDAOLogin = new DAO.DAOLogin();

        public void BLLCadastroLogin(string Usuario, string Senha, string FK)
        {

            int cFK = Convert.ToInt16(FK);

            objLogin.UsuarioLogin = Usuario;
            objLogin.SenhaLogin = Senha;
            objLogin.FKNHLogin = cFK;

            objDAOLogin.DAOCadastroLogin(objLogin);

        }

        public DataTable BLLConsultaLogin(string Usuario)
        {

            //objLogin.UsuarioLogin = Usuario;
            return objDAOLogin.DAOConsultaLogin(Usuario);

        }

        public void BLLAlteraSenha(string Usuario, string Senha)
        {

            objDAOLogin.DAOAlteraSenha(Usuario, Senha);

        }


    }
}
