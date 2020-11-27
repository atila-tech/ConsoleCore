using System;
using System.Collections.Generic;
using ProjetoUnip.Domain.Person;

namespace ProjetoUnip.Domain.Util
{
    public class Consulta
    {
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public string DescricaoInfermidade { get; set; }
        public bool Retorno { get; set; }
        public DateTime DataRetorno { get; set; }
        public long PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public List<MedicoConsulta> MedicosConsultas { get; set; }
    }
}