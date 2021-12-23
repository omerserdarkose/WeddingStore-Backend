using HelenSposa.Business.Abstract;
using HelenSposa.Entities;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Customer;
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
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerManager;

        public CustomersController(ICustomerService customerManager)
        {
            _customerManager = customerManager;
        }

        //tum musterileri getiren GET methodu
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _customerManager.GetAll();

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        //id'ye gore tek bir musteriyi getiren GET methodu
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var result = _customerManager.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        
        //yeni musteri kaydi yapan POST methodu
        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerAddDto newCustomer)
        {
            var result = _customerManager.Add(newCustomer);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
         }

        //musteriyi guncelleyen PUT methodu
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerUpdateDto updCustomer)
        {
            var result=_customerManager.Update(updCustomer);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //musteriyi silen DELETE methodu
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
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
