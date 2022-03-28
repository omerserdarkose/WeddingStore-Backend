using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.DataAccess.EntityFramework;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.DataAccess.Context;
using HelenSposa.Entities.Concrete;

namespace HelenSposa.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,HelenSposaDbContext>,IProductDal
    {
    }
}
