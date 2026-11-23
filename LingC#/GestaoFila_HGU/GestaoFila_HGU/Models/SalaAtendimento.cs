using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFila_HGU.Models
{
   public  class SalaAtendimento
    {

        public string NomeSala { get; set; }
        public ProfissionalSaude Medico { get; set; }
        public ProfissionalSaude Enfermeiro { get; set; }

        public SalaAtendimento(string nomeSala, ProfissionalSaude medico, ProfissionalSaude enfermeiro)
        {
            NomeSala = nomeSala;
            Medico = medico;
            Enfermeiro = enfermeiro;
        }

    }
}
