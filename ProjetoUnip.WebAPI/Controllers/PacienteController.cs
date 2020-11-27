using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUnip.Domain.Person;
using ProjetoUnip.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoUnip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        public readonly IProjetoUnipRepository _pac;
        public PacienteController(IProjetoUnipRepository med)
        {
            _pac = med;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _pac.GetAllPacientesAsync();
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("{pacienteId}")]
        public async Task<IActionResult> Get(int medicoId)
        {
            try
            {
                var results = await _pac.GetPacienteAsyncById(medicoId);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("GetPacienteByUserId/{usuarioId}")]
        public async Task<IActionResult> GetPacienteByUserId(int usuarioId)
        {
            try
            {
                var results = await _pac.GetPacienteAsyncByUsuarioId(usuarioId);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("getByName/{nomePaciente}")]
        public async Task<IActionResult> Get(string nomePaciente)
        {
            try
            {
                var results = await _pac.GetAllPacientesAsyncByName(nomePaciente);
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
                var results = await _pac.GetAllPacientesAsyncByCpf(cpf);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(Paciente model)
        {
            try
            {
                _pac.add(model);
                _pac.add(model.Pessoa.Usuario);

                if (await _pac.SaveChangesAsync())
                {
                    return Created($"/api/paciente/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        // PUT api/values
        [HttpPut("{pacienteId}")]
        public async Task<IActionResult> Put(int pacienteId, Paciente model)
        {
            try
            {
                var paciente = await _pac.GetPacienteAsyncById(pacienteId);
                if (paciente == null) return NotFound();

                _pac.update(model);
                //_fun.update(model.Pessoa.Usuario);

                if (await _pac.SaveChangesAsync())
                {
                    return Created($"/api/paciente/{model.Id}", model);
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
        public async Task<IActionResult> Delete(int pacienteId)
        {
            try
            {
                var paciente = await _pac.GetPacienteAsyncById(pacienteId);
                if (paciente == null) return NotFound();

                _pac.delete(paciente);

                if (await _pac.SaveChangesAsync())
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
