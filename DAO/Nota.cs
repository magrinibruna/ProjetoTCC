using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC5._0.DAO
{
    public class Nota
    {
        public int IDNota { get; set; }
        public int FKRMAluno { get; set; }
        public int FKIDProfMate { get; set; }
        public string PATNota { get; set; }
        public string PEMNota { get; set; }
        public string TrabalhoNota { get; set; }
        public string ParticipacaoNota { get; set; }
        public string TrimestreNota { get; set; }
        public string DataNota { get; set; }

    }
}
