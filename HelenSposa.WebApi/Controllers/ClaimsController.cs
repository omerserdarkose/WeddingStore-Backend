using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelenSposa.Business.Abstract;
using HelenSposa.Entities.Dtos.Claim;


namespace HelenSposa.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private IClaimService _claimManager;

        public ClaimsController(IClaimService claimManager)
        {
            _claimManager = claimManager;
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _claimManager.GetAll();
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _claimManager.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        
        [HttpPost("{claim}")]
        public IActionResult Add(string claim)
        {
            var result = _claimManager.Add(claim);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        
        [HttpPut]
        public IActionResult Update([FromBody] ClaimUpdateDto claimUpdateDto)
        {
            var result = _claimManager.Update(claimUpdateDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _claimManager.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
