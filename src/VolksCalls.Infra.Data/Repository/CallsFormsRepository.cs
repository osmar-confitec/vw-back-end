using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Infra.Data.Repository
{
    public class CallsFormsRepository : BaseRepository<CallFormDomain>, ICallsFormsRepository
    {
        public CallsFormsRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
