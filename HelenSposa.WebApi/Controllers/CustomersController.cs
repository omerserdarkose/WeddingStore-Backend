using HelenSposa.Business.Abstract;
using HelenSposa.Entities;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelenSposa.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerManager;

        public CustomersController(ICustomerService customerManager)
        {
            _customerManager = customerManager;
        }

        // GET: <CustomersController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _customerManager.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _customerManager.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        
        // POST <CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerAddDto newCustomer)
        {
            var result = _customerManager.Add(newCustomer);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT <CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerUpdateDto updCustomer)
        {
            var result=_customerManager.Update(updCustomer);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE <CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var result= _customerManager.Delete(new CustomerDeleteDto { Id=id});

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
