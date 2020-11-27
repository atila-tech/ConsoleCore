using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUnip.Domain.User;
using ProjetoUnip.Repository;

namespace ProjetoUnip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IProjetoUnipRepository _user;
        public UsuarioController(IProjetoUnipRepository user)
        {
            _user = user;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _user.GetAllUsuariosAsync();
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
            
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> Get(int usuarioId)
        {
            try
            {
                var results = await _user.GetUsuarioAsyncById(usuarioId);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
            
        }

        [HttpGet("{login}/{senha}")]
        public async Task<IActionResult> GetLogin(string login, string senha)
        {
            try
            {
                var results = await _user.GetUsuarioAsyncByLogin(login, senha);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

    }
}