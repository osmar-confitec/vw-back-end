using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models;

namespace VolksCalls.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();

        bool Commit();

        DbContext GetContext();
        IBaseConsultRepository<T> GetRepository<T>() where T : EntityDataBase;
    }
}
