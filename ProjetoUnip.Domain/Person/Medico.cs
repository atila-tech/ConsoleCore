using System.Collections.Generic;
using ProjetoUnip.Domain.Person.Util;
using ProjetoUnip.Domain.Util;

namespace ProjetoUnip.Domain.Person
{
    public class Medico
    {
        public long Id { get; set; }
        public string Crm { get; set; }
        public long EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
        public long? PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public List<MedicoConsulta> MedicosConsultas { get; set; }
    }
}