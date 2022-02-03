using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Application.Interfaces
{
    public interface IBaseApplication : IDisposable
    {
        public IUnitOfWork unitOfWork { get; }
        public LNotifications LNotifications { get; }

    }
}
