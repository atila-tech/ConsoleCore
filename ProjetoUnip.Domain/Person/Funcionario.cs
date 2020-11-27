using ProjetoUnip.Domain.Person.Util;
using ProjetoUnip.Domain.User;

namespace ProjetoUnip.Domain.Person
{
    public class Funcionario
    {
        public long Id { get; set; }
        public decimal Salario { get; set; }
        public bool Terceirizado { get; set; }
        public long CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public long? PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}