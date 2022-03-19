﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.DataAccess.EntityFramework;
using HelenSposa.Core.Entities.Concrete;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.DataAccess.Context;

namespace HelenSposa.DataAccess.Concrete.EntityFramework
{
    public class EfClaimDal:EfEntityRepositoryBase<Claim,HelenSposaDbContext>,IClaimDal
    {
    }
}
