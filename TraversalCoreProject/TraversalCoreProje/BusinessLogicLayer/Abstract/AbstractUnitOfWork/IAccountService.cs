using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract.AbstractUnitOfWork
{
    public interface IAccountService:IGenericUowService<Account>
    {
    }
}
