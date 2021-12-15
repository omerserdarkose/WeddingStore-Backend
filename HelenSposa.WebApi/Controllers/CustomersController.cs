using HelenSposa.Business.Abstract;
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
            return Ok(result);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _customerManager.GetById(id);
            return Ok(result);
        }

        [HttpGet("{pCode}")]
        public IActionResult Get(string pCode)
        {
            var result = _customerManager.GetAllByPhoneCode(pCode);
            return Ok(result);
        }

        // POST <CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerAddDto newCustomer)
        {
            var customer = _customerManager.FindPhone(newCustomer.PhoneNumber);

            if (customer != null)
            {
                return BadRequest();
            }
            _customerManager.Add(newCustomer);
            return Ok(newCustomer);
        }

        // PUT <CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerUpdateDto updCustomer)
        {
            var customer = _customerManager.GetById(id);

            if (customer == null)
            {
                return BadRequest();
            }
            _customerManager.Update(updCustomer);
            return Ok(updCustomer);
        }

        // DELETE <CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _customerManager.GetById(id);

            if (customer == null)
            {
                return BadRequest();
            }
            _customerManager.Delete(customer);
            return Ok();
        }
    }
}
