using System.Threading.Tasks;
using ProjetoUnip.Domain.Person;
using ProjetoUnip.Domain.User;

namespace ProjetoUnip.Repository
{
    public interface IProjetoUnipRepository
    {
        //GERAL
         void add<T>(T entity) where T : class;
         void update<T>(T entity) where T : class;
         void delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

         //USUARIOS
         Task<Usuario[]> GetAllUsuariosAsync();
         Task<Usuario> GetUsuarioAsyncById(int usuarioId);
         Task<Usuario> GetUsuarioAsyncByLogin(string Nome, string senha);

        //MEDICOS
        Task<Medico[]> GetAllMedicosAsync();
        Task<Medico> GetMedicoAsyncById(int medicoId);
        Task<Medico> GetMedicoAsyncByUsuarioId(int usuarioId);
        Task<Medico[]> GetAllMedicosAsyncByName(string nomeMedico);
        Task<Medico[]> GetAllMedicosAsyncByCpf(string cpf);
        //PACIENTES
        Task<Paciente[]> GetAllPacientesAsync();
        Task<Paciente> GetPacienteAsyncById(int pacienteId);
        Task<Paciente> GetPacienteAsyncByUsuarioId(int usuarioId);
        Task<Paciente[]> GetAllPacientesAsyncByName(string nomePaciente);
        Task<Paciente[]> GetAllPacientesAsyncByCpf(string cpf);
        //FUNCIONARIOS
        Task<Funcionario[]> GetAllFuncionariosAsync();
        Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId);
        Task<Funcionario> GetFuncionarioAsyncByUsuarioId(int usuarioId);
        Task<Funcionario[]> GetAllFuncionariosAsyncByName(string nomeFuncionario);
        Task<Funcionario[]> GetAllFuncionariosAsyncByCpf(string cpf);
    }
}