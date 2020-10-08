using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pomar.Models
{
    public class Colheita
    {
        private IList<ColheitaArvore> _colheitaArvores;

        public Colheita(string informacoes, DateTime dataColheita, decimal pesoBruto)
        {
            Informacoes = informacoes;
            DataColheita = dataColheita;
            PesoBruto = pesoBruto;
            _colheitaArvores = new List<ColheitaArvore>();
        }
        
        public int Codigo { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Informacoes { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataColheita { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal PesoBruto { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public virtual ICollection<ColheitaArvore> ColheitaArvores { get { return _colheitaArvores; } }

        public void AddColheitaArvore(ColheitaArvore colheitaArvore)
        {
            _colheitaArvores.Add(colheitaArvore);
        }
    }
}