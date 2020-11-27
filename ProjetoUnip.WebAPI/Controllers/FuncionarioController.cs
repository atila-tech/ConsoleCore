using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUnip.Domain.Person;
using ProjetoUnip.Repository;

namespace ProjetoUnip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        public readonly IProjetoUnipRepository _fun;
        public FuncionarioController(IProjetoUnipRepository med)
        {
            _fun = med;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _fun.GetAllFuncionariosAsync();
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("{funcionarioId}")]
        public async Task<IActionResult> Get(int funcionarioId)
        {
            try
            {
                var results = await _fun.GetFuncionarioAsyncById(funcionarioId);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("GetFuncionarioByUserId/{usuarioId}")]
        public async Task<IActionResult> GetFuncionarioByUserId(int usuarioId)
        {
            try
            {
                var results = await _fun.GetFuncionarioAsyncByUsuarioId(usuarioId);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("getByName/{nomeFuncionario}")]
        public async Task<IActionResult> Get(string nomeFuncionario)
        {
            try
            {
                var results = await _fun.GetAllFuncionariosAsyncByName(nomeFuncionario);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("getByCpf/{cpf}")]
        public async Task<IActionResult> GetCpf(string cpf)
        {
            try
            {
                var results = await _fun.GetAllFuncionariosAsyncByCpf(cpf);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(Funcionario model)
        {
            try
            {
                _fun.add(model);
                _fun.add(model.Pessoa.Usuario);

                if (await _fun.SaveChangesAsync())
                {
                    return Created($"/api/funcionario/{model.Id}", model);
                }
                
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
            
            return BadRequest();
        }

        // PUT api/values
        [HttpPut("{funcionarioId}")]
        public async Task<IActionResult> Put(int funcionarioId, Funcionario model)
        {
            try
            {
                var funcionario = await _fun.GetFuncionarioAsyncById(funcionarioId);
                if (funcionario == null) return NotFound();

                _fun.update(model);
                //_fun.update(model.Pessoa.Usuario);

                if (await _fun.SaveChangesAsync())
                {
                    return Created($"/api/funcionario/{model.Id}", model);
                }
                
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
            
            return BadRequest();
        }

        // DELETE api/values
        [HttpDelete]
        public async Task<IActionResult> Delete(int funcionarioId)
        {
            try
            {
                var funcionario = await _fun.GetFuncionarioAsyncById(funcionarioId);
                if (funcionario == null) return NotFound();

                _fun.delete(funcionario);

                if (await _fun.SaveChangesAsync())
                {
                    return Ok();
                }
                
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
            
            return BadRequest();
        }

    }
}