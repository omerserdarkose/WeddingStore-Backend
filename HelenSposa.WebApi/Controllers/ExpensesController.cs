using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelenSposa.Business.Abstract;
using HelenSposa.Entities.Dtos.Expense;


namespace HelenSposa.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private IExpenseService _expenseManager;

        public ExpensesController(IExpenseService expenseManager)
        {
            _expenseManager = expenseManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _expenseManager.GetAll();

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpGet("categories/{catId}")]
        public IActionResult GetByCategory(int catId)
        {
            var result = _expenseManager.GetAllByTypeId(catId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public IActionResult Add([FromBody] ExpenseAddDto expenseAddDto)
        {
            var result = _expenseManager.Add(expenseAddDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ExpenseUpdateDto expenseUpdateDto)
        {
            var result = _expenseManager.Update(id, expenseUpdateDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
