using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC5._0.DAO
{
    public class Turma
    {

        public int IDTurma { get; set; }
        public string NomeTurma { get; set; }
        public string AnoTurma { get; set; }
        public string PeriodoTurma { get; set; }
        public int FKCursoTurma { get; set; }
        public string CompletoTurma { get; set; }
        public string AITurma { get; set; }
        public string DataDeExclusao { get; set; }



    }
}
