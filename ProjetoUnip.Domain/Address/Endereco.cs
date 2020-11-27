using ProjetoUnip.Domain.Person;

namespace ProjetoUnip.Domain.Address
{
    public class Endereco
    {
        public long Id { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public long PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}