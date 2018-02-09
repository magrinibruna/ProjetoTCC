using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TCC5._0.BLL
{
    public class BLLFoto
    {
        DAO.Foto objFoto = new DAO.Foto();
        DAO.DAOFoto objDAOFoto = new DAO.DAOFoto();

        public void BLLCadastraAlunoFoto(string Foto, string FKRM)
        {
            int cFKRM = Convert.ToInt32(FKRM);

            objFoto.Diretorio = Foto;
            objFoto.FKRMAluno = cFKRM;

            objDAOFoto.DAOCadastraAlunoFoto(objFoto);
        }

        public void BLLCadastraHorarioFoto(string Foto, string FKCurso)
        {
            int cFKCurso = Convert.ToInt32(FKCurso);

            objFoto.Diretorio = Foto;
            objFoto.FKIDCurso = cFKCurso;

            objDAOFoto.DAOCadastraHorarioFoto(objFoto);
        }

        public DataTable BLLConsultaRMFoto(string FK)
        {
            int cFKRM = Convert.ToInt32(FK);
            objFoto.FKRMAluno = cFKRM;
            return objDAOFoto.DAOConsultaRMFoto(objFoto);
        }

        public DataTable BLLConsultaHorarioFoto(string FK)
        {
            int cFKID = Convert.ToInt32(FK);
            objFoto.FKIDCurso = cFKID;
            return objDAOFoto.DAOConsultaHorarioFoto(objFoto);
        }

        public void BLLAlteraHorarioFoto(string Foto, string FK)
        {
            int cFKID = Convert.ToInt32(FK);
            objFoto.FKIDCurso = cFKID;
            objFoto.Diretorio = Foto;
            objDAOFoto.DAOAlteraHorarioFoto(objFoto);

        }
    }
}
