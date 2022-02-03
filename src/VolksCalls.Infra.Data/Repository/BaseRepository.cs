using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityDataBase
    {

        public IUnitOfWork unitOfWork { get; }

        public IBaseConsultRepository<TEntity> _repositoryConsult { get; protected set; }

        readonly DbSet<TEntity> DbSet;
        protected BaseRepository(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            DbSet = unitOfWork.GetContext().Set<TEntity>();
            _repositoryConsult = unitOfWork.GetRepository<TEntity>();
        }
        public void Add(TEntity entity) => DbSet.Add(entity);

        public void Dispose() => GC.SuppressFinalize(this);

        public void Remove(TEntity entity) => DbSet.Remove(entity);

        public void Update(TEntity entity) => DbSet.Update(entity);

        public async Task AddAsync(TEntity entidade) => await DbSet.AddAsync(entidade);

        public async Task AddAsync<T>(T entidade) where T : EntityDataBase
          => await unitOfWork.GetContext().Set<T>().AddAsync(entidade);

        public void Update<T>(T entity) where T : EntityDataBase
        => unitOfWork.GetContext().Set<T>().Update(entity);

        public  void UpdateRange<T>(IEnumerable<T> entity) where T : EntityDataBase
        
           => unitOfWork.GetContext().Set<T>().UpdateRange(entity);
        
    }
}
