using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.CallCategoriesList;

namespace VolksCalls.Domain.Interfaces
{
   public interface ICallCategoriesListServices: IBaseService<CallCategoriesListDomain>
    {
        Task LoadCallCategoriesListAsync();
    }
}
