using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelenSposa.Business.Abstract;
using HelenSposa.Entities.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelenSposa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypesController : ControllerBase
    {
        private IExpenseTypeService _expenseTypeManager ;

        public ExpenseTypesController(IExpenseTypeService expenseTypeManager)
        {
            _expenseTypeManager = expenseTypeManager;
        }

        // GET: api/<ExpenseTypesController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _expenseTypeManager.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        
        // POST api/<ExpenseTypesController>
        [HttpPost]
        public IActionResult Post([FromBody] ExpenseTypeGeneralDto newExpenseType)
        {
            var result = _expenseTypeManager.Add(newExpenseType);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<ExpenseTypesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExpenseTypeGeneralDto updExpenseType)
        {
            var result = _expenseTypeManager.Update(updExpenseType);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<ExpenseTypesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _expenseTypeManager.Delete(new ExpenseTypeGeneralDto { Id = id });

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
