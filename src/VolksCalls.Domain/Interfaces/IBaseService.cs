using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Domain.Interfaces
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : EntityDataBase
    {
        public IBaseRepository<TEntity> _iBaseRepository { get; }

        
        public LNotifications _lNotifications { get; }

        void Add(TEntity entidade);

        Task AddAsync(TEntity entidade);

        void UpdateRange<T>(IEnumerable<T> entity) where T : EntityDataBase;

        Task AddAsync<T>(T entidade) where T : EntityDataBase;

        void Update<T>(T entity) where T : EntityDataBase;

        void Update(TEntity customer);

        void Remove(TEntity customer);


    }
}
