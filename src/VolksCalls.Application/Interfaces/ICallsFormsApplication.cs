using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.CallForm.Request;
using VolksCalls.Domain.Models.CallForm.Response;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Application.Interfaces
{
  public  interface ICallsFormsApplication: IBaseApplication
    {

        Task<CallFormInsertResponse> CallFormInsertAsync(CallFormInsertRequest callFormInsertRequest);

        Task<CallFormUpdateResponse> CallFormUpdateAsync(CallFormUpdateRequest callFormUpdateRequest);

        Task<CallFormDeleteResponse> CallFormDeleteAsync(Guid id);

        Task<CallFormDetailsResponse> GetCallFormDetailsAsync(Guid id);
        Task<CallFormDetailsResponse> GetCallFormDetailsDefaultAsync();

        Task<PagedDataResponse<CallFormResponse>> GetCallFormAsync(CallFormListRequest callFormListRequest);

    }
}
