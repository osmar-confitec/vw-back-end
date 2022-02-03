using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.Data.Repository;

namespace VolksCalls.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly Data.Context.AplicationContext _appContext;
        public UnitOfWork(Data.Context.AplicationContext appContext)
        {
            _appContext = appContext;
        }

        public bool Commit()
        =>  _appContext.SaveChanges() > 0;

        public async Task<bool> CommitAsync() => await _appContext.SaveChangesAsync() > 0;

        public void Dispose() => GC.SuppressFinalize(this);

        public DbContext GetContext() => _appContext;

        public IBaseConsultRepository<T> GetRepository<T>() where T : EntityDataBase => new RepositoryConsult<T>(GetContext());
    }
}
