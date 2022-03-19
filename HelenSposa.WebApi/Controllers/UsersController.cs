using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelenSposa.Business.Abstract;
using HelenSposa.Entities.Dtos.User;


namespace HelenSposa.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userManager;

        public UsersController(IUserService userService)
        {
            _userManager = userService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userManager.GetAll();
            return Ok(result.Data);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _userManager.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserAddDto userAddDto)
        {
            var userNotExists = _userManager.UserNotExists(userAddDto.Email);

            if (!userNotExists.Success)
            {
                return BadRequest(userNotExists.Message);
            }

            var newUser = _userManager.Add(userAddDto);

            return Ok(newUser.Message);
        }

        [HttpPost("{id}/claims/{claimId}")]
        public IActionResult AddClaim(int id, int claimId)
        {
            var result = _userManager.AddUserClaim(id, claimId);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPost("pw-reset")]
        public IActionResult PasswordReset([FromBody] UserEmailDto userEmailDto)
        {
            var result = _userManager.PasswordReset(userEmailDto.Email);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            var result = _userManager.Update(id, userUpdateDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userManager.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpDelete("{id}/claims/{claimId}")]
        public IActionResult DeleteClaim(int id,int claimId)
        {
            var result = _userManager.DeleteUserClaim(id,claimId);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


    }
}
