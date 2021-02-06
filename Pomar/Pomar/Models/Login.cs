namespace Pomar.Models
{
    public class Login
    {
        public Login(string usuario, string token)
        {
            Usuario = usuario;
            Token = token;
        }

        public string Usuario { get; private set; }
        public string Token { get; private set; }

    }
}