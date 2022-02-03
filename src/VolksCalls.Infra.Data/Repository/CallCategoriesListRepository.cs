using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallCategoriesList;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Infra.Data.Repository
{
    public class CallCategoriesListRepository : BaseRepository<CallCategoriesListDomain>, ICallCategoriesListRepository
    {
        public CallCategoriesListRepository(IUnitOfWork _unitOfWork) 
            : base(_unitOfWork)
        {



        }
    }
}
