using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelenSposa.Business.Abstract;
using HelenSposa.Entities.Dtos.Product;


namespace HelenSposa.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productManager ;

        public ProductsController(IProductService productManager)
        {
            _productManager = productManager;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _productManager.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductAddDto newProduct)
        {
            var result = _productManager.Add(newProduct);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromBody] ProductUpdateDto updProduct, int id)
        {
            var result = _productManager.Update(id,updProduct);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productManager.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
