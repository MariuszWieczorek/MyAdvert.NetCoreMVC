using MyAdvert.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core
{
    public interface IUnitOfWork
    {
        IAdvertRepository Advert { get; set; }
        ICategoryRepository Category { get; set; }
        void Complete();
    }
}
