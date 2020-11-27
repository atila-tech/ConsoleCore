using System.Collections.Generic;
using ProjetoUnip.Domain.Person;
using ProjetoUnip.Domain.Util;

namespace ProjetoUnip.Domain.User
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public long PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}