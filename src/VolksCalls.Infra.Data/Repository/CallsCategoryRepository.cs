using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Infra.Data.Repository
{
    public class CallsCategoryRepository : BaseRepository<CallsCategoryDomain>, ICallsCategoryRepository
    {
        public CallsCategoryRepository(IUnitOfWork _unitOfWork) 
            : base(_unitOfWork)
        {



        }
    }
}
