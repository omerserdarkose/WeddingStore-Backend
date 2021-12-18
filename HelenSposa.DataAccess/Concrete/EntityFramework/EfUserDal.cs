using HelenSposa.Core.DataAccess.EntityFramework;
using HelenSposa.Core.Entities.Concrete;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Dtos.OperationClaim;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, HelenSposaDbContext>, IUserDal
    {
        public List<OperationClaimShowDto> GetClaims(User user)
        {
            using (var context = new HelenSposaDbContext())
            {
                var result = from uoc in context.UserOperationClaims
                             join oc in context.OperationClaims
                             on uoc.OperationClaimId equals oc.Id
                             where uoc.UserId==user.Id
                             select new OperationClaimShowDto
                             { 
                                 Id=oc.Id,
                                 ClaimName=oc.Name
                             };

                //asagidaki sorgu where kosulu genellestirilip, UserOperationClaimsDal icine yazilip orada implemente edilebilir. sonuc olarak aslinda o entitye ait bir join, bu islem sonrasinda UserManager icerisinde bu islem gerekirse IUserDal DI gibi yine user business classinda IUserOperationClaim DI yapilarak alinmali bagimlilik azaltilarak orada kullanilmali diye dusunuyorum ama emin degilim:)

                /*public List<UserOperationClaim> GetUserClaims(User user)
               {
                   using (var context = new HelenSposaDbContext())
                   {
                       return context.Set<UserOperationClaim>().Include(uoc => uoc.OperationClaim).Where(x=>x.UserId==user.Id).ToList();
                   }
               }*/

                return result.ToList();
            }
        }
    }
}
