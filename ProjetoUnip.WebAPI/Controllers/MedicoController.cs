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
    public class MedicoController : ControllerBase
    {
        public readonly IProjetoUnipRepository _med;
        public MedicoController(IProjetoUnipRepository med)
        {
            _med = med;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _med.GetAllMedicosAsync();
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("{medicoId}")]
        public async Task<IActionResult> Get(int medicoId)
        {
            try
            {
                var results = await _med.GetMedicoAsyncById(medicoId);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("GetMedicoByUserId/{usuarioId}")]
        public async Task<IActionResult> GetMedicoByUserId(int usuarioId)
        {
            try
            {
                var results = await _med.GetMedicoAsyncByUsuarioId(usuarioId);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("getByName/{nomeMedico}")]
        public async Task<IActionResult> Get(string nomeMedico)
        {
            try
            {
                var results = await _med.GetAllMedicosAsyncByName(nomeMedico);
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
                var results = await _med.GetAllMedicosAsyncByCpf(cpf);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(Medico model)
        {
            try
            {
                _med.add(model);
                _med.add(model.Pessoa.Usuario);

                if (await _med.SaveChangesAsync())
                {
                    return Created($"/api/medico/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        // PUT api/values
        [HttpPut("{medicoId}")]
        public async Task<IActionResult> Put(int medicoId, Medico model)
        {
            try
            {
                var medico = await _med.GetMedicoAsyncById(medicoId);
                if (medico == null) return NotFound();

                _med.update(model);
                //_fun.update(model.Pessoa.Usuario);

                if (await _med.SaveChangesAsync())
                {
                    return Created($"/api/medico/{model.Id}", model);
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
        public async Task<IActionResult> Delete(int medicoId)
        {
            try
            {
                var medico = await _med.GetMedicoAsyncById(medicoId);
                if (medico == null) return NotFound();

                _med.delete(medico);

                if (await _med.SaveChangesAsync())
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
