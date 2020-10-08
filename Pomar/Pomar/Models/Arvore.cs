using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pomar.Models
{
    public class Arvore
    {        
        public Arvore(string descricao, DateTime dataPlantio, int especieId, int grupoArvoreId)
        {
            Descricao = descricao;
            DataPlantio = dataPlantio;            
            EspecieId = especieId;
            GrupoArvoreId = grupoArvoreId;
            ColheitasArvore = new List<ColheitaArvore>();            
        }
        
        public int Codigo { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Descricao { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataPlantio { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Espécie inválida")]
        public int EspecieId { get; private set; }
        public virtual Especie Especie { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Espécie inválida")]
        public int GrupoArvoreId { get; private set; }

        public virtual int Idade { get; private set; }
        public virtual GrupoArvore GrupoArvore { get; private set; }
        // [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<ColheitaArvore> ColheitasArvore { get; private set; }       
    }
}