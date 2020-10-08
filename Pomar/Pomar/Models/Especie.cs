using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pomar.Models
{
    public class Especie
    {
        public Especie(string descricao)
        {
            Descricao = descricao;
            Arvores = new List<Arvore>();
        }
        
        public int Codigo { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Descricao { get; private set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Arvore> Arvores { get; private set; }
    }
}