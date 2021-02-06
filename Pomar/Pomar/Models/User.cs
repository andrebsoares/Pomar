using System.ComponentModel.DataAnnotations;

namespace Pomar.Models
{
    public class User
    {
        public User(string usuario, string senha, string cargo)
        {
            Usuario = usuario;
            Senha = senha;
            Cargo = cargo;
        }

        public int Codigo { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Usuario { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Senha { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cargo { get; private set; }
    }
}