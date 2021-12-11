using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Business
{
    public interface IServiceRepository<T> where T:class,IEntity,new ()
    {
        List<T> GetAll();

        void Add(T addedT);

        void Update(T updatedT);

        void Delete(T deletedT);
    }
}
