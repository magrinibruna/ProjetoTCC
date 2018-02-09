using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC5._0.DAO
{
    public class ProfessorMateria
    {
        public int IDProfMate { get; set; }
        public int FKIDMateria { get; set; }
        public string NomeMateria { get; set; }
        public int FKIDFunc { get; set; }
        public string NomeRelacionamento { get; set; }
        public string AtivoInativoProfMate { get; set; }


    }
}
