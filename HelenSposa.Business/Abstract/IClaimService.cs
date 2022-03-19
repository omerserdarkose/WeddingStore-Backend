using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Dtos.Claim;

namespace HelenSposa.Business.Abstract
{
    public interface IClaimService
    {
        IDataResult<List<ClaimShowDto>> GetAll();

        IDataResult<ClaimShowDto> GetById(int id);
        bool CheckClaimById(int id);

        IResult Add(string claimName);

        IResult Delete(int id);
        IResult Update(ClaimUpdateDto claimUpdateDto);
    }
}
