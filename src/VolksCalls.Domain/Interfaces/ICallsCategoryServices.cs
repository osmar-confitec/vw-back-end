using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Models.CallsCategory.Request;
using VolksCalls.Domain.Models.CallsCategory.Response;

namespace VolksCalls.Domain.Interfaces
{
    public interface ICallsCategoryServices: IBaseService<CallsCategoryDomain>
    {

        Task LoadOfTicketCategoriesAsync();

        Task LoadOfTicketCategoriesNewAsync();

        Task LoadQtdChildrenAsync();

        Task<CallCategoriesResponse> GetCallCategoriesParentsAsync();

        Task<CallCategoriesResponse> GetCallCategoriesFromTextAsync(string text);

        Task<CallCategoriesResponse> GetCallCategoriesExcelAsync();

        Task<CallCategoryDeleteResponse> CallCategoryDeleteAsync(Guid id);

        Task<CallCategoryUpdateResponse> CallCategoryUpdateAsync(CallCategoryUpdateRequest callCategoryUpdateRequest);

        Task<CallCategoryInsertResponse> CallCategoryInsertAsync(CallCategoryInsertRequest callCategoryInsertRequest);

        Task<CallCategoriesResponse> GetCallCategoriesChildrenNodesAsync(IEnumerable<Guid> AllCallCategoriesCheked,
                                                                                      IEnumerable<Guid> AllCallCategories,
                                                                                      Guid CallCategoryChecked);






    }
}
