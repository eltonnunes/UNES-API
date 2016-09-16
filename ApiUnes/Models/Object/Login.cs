using System.Collections.Generic;

namespace ApiUnes.Models.Object
{
    public class Login
    {
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
    }
}