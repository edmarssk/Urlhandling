using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UrlHandling.Business.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
