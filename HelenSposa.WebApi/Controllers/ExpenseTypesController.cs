using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelenSposa.Business.Abstract;
using HelenSposa.Entities.Dtos.ExpenseType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelenSposa.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpenseTypesController : ControllerBase
    {
        private IExpenseTypeService _expenseTypeManager ;

        public ExpenseTypesController(IExpenseTypeService expenseTypeManager)
        {
            _expenseTypeManager = expenseTypeManager;
        }

        // GET: <ExpenseTypesController>
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
        
        // POST <ExpenseTypesController>
        [HttpPost]
        public IActionResult AddExpenseType([FromBody] ExpenseTypeAddDto newExpenseType)
        {
            var result = _expenseTypeManager.Add(newExpenseType);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<ExpenseTypesController>/5
        [HttpPut("update")]
        public IActionResult UpdateExpenseType([FromBody] ExpenseTypeUpdateDto updExpenseType)
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
        public IActionResult DeleteExpenseType(int id)
        {
            var result = _expenseTypeManager.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
