using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Calls;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Infra.Data.Repository
{
    public class CallRepository : BaseRepository<CallsDomain>, ICallRepository
    {
        public CallRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {


        }
    }
}
