using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities.Repository;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudioController : ControllerBase
    {
        private readonly IEstudioRepository _estudioRepository;

        public EstudioController(IEstudioRepository estudioRepository)
        {
            _estudioRepository = estudioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudio>>> GetEstudiosAsync()
        {
            var estudios = await _estudioRepository.GetEstudiosAsync();
            return Ok(estudios);
        }

        [HttpGet("{idProf}/{ccPer}")]
        public async Task<ActionResult<Estudio>> GetEstudioAsync(int idProf, long ccPer)
        {
            var estudio = await _estudioRepository.GetEstudioAsync(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }
            return Ok(estudio);
        }

        [HttpPost]
        public async Task<ActionResult<Estudio>> CreateEstudioAsync(Estudio estudio)
        {
            await _estudioRepository.CreateEstudioAsync(estudio);
            return CreatedAtAction(nameof(GetEstudioAsync), new { idProf = estudio.IdProf, ccPer = estudio.CcPer }, estudio);
        }

        [HttpPut("{idProf}/{ccPer}")]
        public async Task<IActionResult> UpdateEstudioAsync(int idProf, long ccPer, Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer)
            {
                return BadRequest();
            }

            await _estudioRepository.UpdateEstudioAsync(estudio);
            return NoContent();
        }

        [HttpDelete("{idProf}/{ccPer}")]
        public async Task<IActionResult> DeleteEstudioAsync(int idProf, long ccPer)
        {
            var estudio = await _estudioRepository.GetEstudioAsync(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }

            await _estudioRepository.DeleteEstudioAsync(idProf, ccPer);
            return NoContent();
        }
    }

}