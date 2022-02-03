using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models;

namespace VolksCalls.Domain.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : EntityDataBase
    {

        void Add(TEntity entidade);

        Task AddAsync(TEntity entidade);

        Task AddAsync<T>(T entidade) where T:EntityDataBase ;

        void Update(TEntity customer);

        void Update<T>(T entity) where T : EntityDataBase;

        void UpdateRange<T>(IEnumerable<T> entity) where T : EntityDataBase;

        void Remove(TEntity customer);

        IUnitOfWork unitOfWork { get; }

        IBaseConsultRepository<TEntity> _repositoryConsult { get; }

    }
}
