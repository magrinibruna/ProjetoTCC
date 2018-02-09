using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC5._0.DAO
{
    public class Aluno
    {

        public int RMAluno { get; set; }
        public string NomeAluno { get; set; }
        public string CPFAluno { get; set; }
        public string EmailAluno { get; set; }
        public string AIAluno { get; set; }
        public string DTAluno { get; set; }
        public int FKTurmaAluno { get; set; }

        public string RMAlunoConsulta { get; set; }


    }
}
