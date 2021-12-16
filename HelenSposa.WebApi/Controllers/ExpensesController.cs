using HelenSposa.Business.Abstract;
using HelenSposa.Entities.Dtos.Expense;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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


        // GET: api/<ExpensesController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _expenseManager.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<ExpensesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExpensesController>
        [HttpPost]
        public IActionResult Post([FromBody] ExpenseAddDto newExpense)
        {
            var result = _expenseManager.Add(newExpense);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<ExpensesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExpenseUpdateDto updExpense)
        {
            var result = _expenseManager.Update(updExpense);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<ExpensesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _expenseManager.Delete(new ExpenseDeleteDto { Id = id });

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
