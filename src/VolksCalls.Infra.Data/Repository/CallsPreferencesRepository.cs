using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallsPreferences;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Infra.Data.Repository
{
    public class CallsPreferencesRepository : BaseRepository<CallCategoryDomain>, ICallsPreferencesRepository
    {
        public CallsPreferencesRepository(IUnitOfWork _unitOfWork) 
            : base(_unitOfWork)
        {

        }
    }
}
