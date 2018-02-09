using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC5._0.DAO
{
    public class Materia
    {

        public int IDMateria { get; set; }
        public string NomeMateria { get; set; }
        public int QuantidadeDeAula { get; set; }
        public int FKCursoMateria { get; set; }
        public string AIMateria { get; set; }


    }
}
