using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC5._0.DAO
{
    public class ProfessorMateriaTurma
    {

        public int IDProfMateTurma { get; set; }
        public int FKIDProfMate { get; set; }
        public int FKIDTurma { get; set; }
        public string NomeTurma { get; set; }
        public string AtivoInativoProfMateTurma { get; set; }



    }
}
