using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.CallsCategory.Request;
using VolksCalls.Domain.Models.CallsCategory.Response;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Application.Interfaces
{
    public interface ICallsCategoryApplication : IBaseApplication
    {
        Task LoadOfTicketCategoriesAsync();

        Task<CallCategoriesResponse> GetCallCategoriesParentsAsync();

        Task LoadQtdChildrenAsync();

        Task<CallCategoriesResponse> GetCallCategoriesFromTextAsync(string text);

        Task LoadOfTicketCategoriesNewAsync();

        Task<CallCategoriesResponse> GetCallCategoriesExcelAsync();

        Task<CallCategoryDeleteResponse> CallCategoryDeleteAsync(Guid id);

        Task<PagedDataResponse<CallsCategoryGetResponse>> GetCallCategoriesAsync(CallsCategoryGetRequest callsCategoryGetRequest);
        

        Task<List<CallCategoriesListResponse>> GetCallsCategoryAsync(CallsCategoryGetRequest callsCategoryGetRequest );

        Task<CallsCategoryManageResponse> GetCallsCategoryManageAsync(Guid Id);

        Task<CallCategoryInsertResponse> CallCategoryInsertAsync(CallCategoryInsertRequest callCategoryInsertRequest);
        Task<CallCategoryUpdateResponse> CallCategoryUpdateAsync(CallCategoryUpdateRequest  callCategoryUpdateRequest);

        Task<CallCategoriesResponse> GetCallCategoriesChildrenNodesAsync(CallCategoriesChildrenNodesRequest callCategoriesChildrenNodesRequest);

    }
}
