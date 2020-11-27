using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoUnip.Domain.Person;
using ProjetoUnip.Domain.User;

namespace ProjetoUnip.Repository
{
    public class ProjetoUnipRepository : IProjetoUnipRepository
    {
        private readonly ProjetoUnipContext _context;
        public ProjetoUnipRepository(ProjetoUnipContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        //GERAIS
        public void add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //USUARIOS

        public async Task<Usuario> GetUsuarioAsyncByLogin(string Login, string senha)
        {
            IQueryable<Usuario> query = _context.Usuarios
              .Include(p => p.Perfil);
            //.Include(pe => pe.Pessoa);
            //.Include(p => p.Perfil)
            //.Include(m => m.Pessoa.Medico)
            //.Include(m => m.Pessoa.Medico.Especialidade)
            //.Include(pa => pa.Pessoa.Paciente)
            //.Include(f => f.Pessoa.Funcionario)
            //.Include(f => f.Pessoa.Funcionario.Cargo);

            query = query.Where(a => a.Login.Equals(Login) && a.Senha.Equals(senha));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario[]> GetAllUsuariosAsync()
        {
            IQueryable<Usuario> query = _context.Usuarios;
                //.Include(pe => pe.Pessoa);
                //.Include(p => p.Perfil)
                //.Include(m => m.Pessoa.Medico)
                //.Include(m => m.Pessoa.Medico.Especialidade)
                //.Include(pa => pa.Pessoa.Paciente)
                //.Include(f => f.Pessoa.Funcionario)
                //.Include(f => f.Pessoa.Funcionario.Cargo);

            //query = query.Where(a => a.Ativo == ativo);

            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetUsuarioAsyncById(int usuarioId)
        {
            IQueryable<Usuario> query = _context.Usuarios;
                //.Include(pe => pe.Pessoa);
                //.Include(p => p.Perfil)
                //.Include(m => m.Pessoa.Medico)
                //.Include(m => m.Pessoa.Medico.Especialidade)
                //.Include(pa => pa.Pessoa.Paciente)
                //.Include(f => f.Pessoa.Funcionario)
                //.Include(f => f.Pessoa.Funcionario.Cargo);

            query = query.Where(a => a.Id == usuarioId);

                return await query.FirstOrDefaultAsync();
        }

        
        //MEDICOS
        public async Task<Medico[]> GetAllMedicosAsyncByName(string nomeMedico)
        {
            IQueryable<Medico> query = _context.Medicos
                .Include(e => e.Especialidade)
                .Include(p => p.Pessoa)
                .Include(p => p.Pessoa.Usuario);

                query = query.Where(a => a.Pessoa.Nome.Contains(nomeMedico));

                return await query.ToArrayAsync();
        }

        public async Task<Medico[]> GetAllMedicosAsync()
        {
            IQueryable<Medico> query = _context.Medicos
                .Include(c => c.Especialidade)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            //query = query.Where(a => a.Pessoa.Nome.Contains(nomeFuncionario));

            return await query.ToArrayAsync();
        }

        public async Task<Medico> GetMedicoAsyncById(int medicoId)
        {
            IQueryable<Medico> query = _context.Medicos
                .Include(c => c.Especialidade)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            query = query.Where(a => a.Id == medicoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Medico> GetMedicoAsyncByUsuarioId(int usuarioId)
        {
            IQueryable<Medico> query = _context.Medicos
                .Include(c => c.Especialidade)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            query = query.Where(a => a.Pessoa.Usuario.Id == usuarioId && a.Pessoa.Usuario.Perfil.Id == 1);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Medico[]> GetAllMedicosAsyncByCpf(string cpf)
        {
            IQueryable<Medico> query = _context.Medicos
                .Include(c => c.Especialidade)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            query = query.Where(a => a.Pessoa.Cpf.ToLower().Contains(cpf.ToLower()));

            return await query.ToArrayAsync();
        }

        //PACIENTES
        public async Task<Paciente[]> GetAllPacientesAsyncByName(string nomePaciente)
        {
            IQueryable<Paciente> query = _context.Pacientes
                //.Include(e => e.Especialidade)
                .Include(p => p.Pessoa)
                .Include(p => p.Pessoa.Usuario);

                query = query.Where(a => a.Pessoa.Nome.Contains(nomePaciente));

                return await query.ToArrayAsync();
        }

        public async Task<Paciente[]> GetAllPacientesAsync()
        {
            IQueryable<Paciente> query = _context.Pacientes
                //.Include(c => c.Especialidade)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            //query = query.Where(a => a.Pessoa.Nome.Contains(nomeFuncionario));

            return await query.ToArrayAsync();
        }

        public async Task<Paciente> GetPacienteAsyncById(int pacienteId)
        {
            IQueryable<Paciente> query = _context.Pacientes
                //.Include(c => c.Especialidade)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            query = query.Where(a => a.Id == pacienteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Paciente> GetPacienteAsyncByUsuarioId(int usuarioId)
        {
            IQueryable<Paciente> query = _context.Pacientes
                //.Include(c => c.Especialidade)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            query = query.Where(a => a.Pessoa.Usuario.Id == usuarioId && a.Pessoa.Usuario.Perfil.Id == 2);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Paciente[]> GetAllPacientesAsyncByCpf(string cpf)
        {
            IQueryable<Paciente> query = _context.Pacientes
                //.Include(c => c.Especialidade)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            query = query.Where(a => a.Pessoa.Cpf.ToLower().Contains(cpf.ToLower()));

            return await query.ToArrayAsync();
        }

        //FUNCIONARIOS

        public async Task<Funcionario[]> GetAllFuncionariosAsync()
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                .Include(c => c.Cargo)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            //query = query.Where(a => a.Pessoa.Nome.Contains(nomeFuncionario));

            return await query.ToArrayAsync();
        }

        public async Task<Funcionario[]> GetAllFuncionariosAsyncByName(string nomeFuncionario)
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                .Include(c => c.Cargo)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            query = query.Where(a => a.Pessoa.Nome.ToLower().Contains(nomeFuncionario.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                .Include(c => c.Cargo)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            query = query.Where(a => a.Id == funcionarioId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Funcionario> GetFuncionarioAsyncByUsuarioId(int usuarioId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                .Include(c => c.Cargo)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            query = query.Where(a => a.Pessoa.Usuario.Id == usuarioId && a.Pessoa.Usuario.Perfil.Id == 3);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Funcionario[]> GetAllFuncionariosAsyncByCpf(string cpf)
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                .Include(c => c.Cargo)
                .Include(p => p.Pessoa)
                .Include(u => u.Pessoa.Usuario);

            query = query.Where(a => a.Pessoa.Cpf.ToLower().Contains(cpf.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}