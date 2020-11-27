using Microsoft.EntityFrameworkCore;
using ProjetoUnip.Domain.Address;
using ProjetoUnip.Domain.Person;
using ProjetoUnip.Domain.Person.Util;
using ProjetoUnip.Domain.User;
using ProjetoUnip.Domain.Util;

namespace ProjetoUnip.Repository
{
    public class ProjetoUnipContext : DbContext
    {
        public ProjetoUnipContext(DbContextOptions<ProjetoUnipContext> options) : base (options){}
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<MedicoConsulta> MedicosConsultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicoConsulta>()
            .HasKey(PE => new {PE.MedicoId, PE.ConsultaId});
        }
    }
}