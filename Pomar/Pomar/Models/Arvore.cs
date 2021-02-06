using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Pomar.Models
{
    public class Arvore
    {
        public Arvore(int codigo, string descricao, DateTime dataPlantio, int especieId, int grupoArvoreId)
        {
            Codigo = codigo;
            Descricao = descricao;
            DataPlantio = dataPlantio;
            Idade = calculaMeses(DateTime.Now, dataPlantio);
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
        [JsonIgnore]
        public int EspecieId { get; private set; }
        public virtual Especie Especie { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Espécie inválida")]
        [JsonIgnore]
        public int GrupoArvoreId { get; private set; }

        public virtual int Idade { get; private set; }
        public virtual GrupoArvore GrupoArvore { get; private set; }
        // [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<ColheitaArvore> ColheitasArvore { get; private set; }

        int calculaMeses(DateTime dataAtual, DateTime dataOriginal)
        {
            int numeroMeses = 0;
            if ((dataAtual.Month > dataOriginal.Month))
            {
                numeroMeses = dataAtual.Month - dataOriginal.Month;
            }
            else if ((dataAtual.Month < dataOriginal.Month))
            {
                if (dataAtual.Day > dataOriginal.Day)
                {
                    numeroMeses = (12 - dataOriginal.Month) + (dataAtual.Month);
                }
                else if (dataAtual.Day < dataOriginal.Day)
                {
                    numeroMeses = (12 - dataOriginal.Month) + (dataAtual.Month - 1);
                }
            }
            return numeroMeses;
        }
    }
}