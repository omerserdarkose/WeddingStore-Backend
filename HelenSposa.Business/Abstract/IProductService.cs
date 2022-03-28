using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<ProductShowDto>> GetAll();
        IResult Add(ProductAddDto productAddDto);
        IResult Delete(int id);
        IResult Update(int id, ProductUpdateDto productUpdateDto);
        bool IsExists(int id);
    }
}
