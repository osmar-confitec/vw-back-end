using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.CallForm.Request;
using VolksCalls.Domain.Models.CallForm.Response;

namespace VolksCalls.Domain.Interfaces
{
   public interface ICallsFormsServices : IBaseService<CallFormDomain>
    {
        Task<CallFormInsertResponse> CallFormInsertAsync(CallFormInsertRequest callFormInsertRequest);
        Task<CallFormDeleteResponse> CallFormDeleteAsync(Guid id);
        Task<CallFormUpdateResponse> CallFormUpdateAsync(CallFormUpdateRequest callFormUpdateRequest);
    }
}
