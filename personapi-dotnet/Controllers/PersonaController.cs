using Microsoft.AspNetCore.Mvc;

namespace personapi_dotnet.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using personapi_dotnet.Models.Entities.Repository;
    using personapi_dotnet.Models.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetPersonasAsync))]
        public IEnumerable<Persona> GetPersonasAsync()
        {
            return _personaRepository.GetPersonas();
        }

        [HttpGet("{cc}")]
        [ActionName(nameof(GetPersonaByCc))]
        public ActionResult<Persona> GetPersonaByCc(long cc)
        {
            var persona = _personaRepository.GetPersonaByCc(cc);
            if (persona == null)
            {
                return NotFound();
            }
            return persona;
        }

        [HttpPost]
        [ActionName(nameof(CreatePersonaAsync))]
        public async Task<ActionResult<Persona>> CreatePersonaAsync(Persona persona)
        {
            await _personaRepository.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersonaByCc), new { cc = persona.Cc }, persona);
        }

        [HttpPut("{cc}")]
        [ActionName(nameof(UpdatePersona))]
        public async Task<ActionResult> UpdatePersona(long cc, Persona persona)
        {
            if (cc != persona.Cc)
            {
                return BadRequest();
            }

            await _personaRepository.UpdatePersonaAsync(persona);
            return NoContent();
        }

        [HttpDelete("{cc}")]
        [ActionName(nameof(DeletePersona))]
        public async Task<IActionResult> DeletePersona(long cc)
        {
            var persona = _personaRepository.GetPersonaByCc(cc);
            if (persona == null)
            {
                return NotFound();
            }

            await _personaRepository.DeletePersonaAsync(cc);
            return NoContent();
        }
    }

}
