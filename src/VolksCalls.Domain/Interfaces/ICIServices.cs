using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.CI;
using VolksCalls.Domain.Models.CI.Request;
using VolksCalls.Domain.Models.CI.Response;

namespace VolksCalls.Domain.Interfaces
{
   public interface ICIServices : IBaseService<CIDomain>
    {
        Task LoadCIAsync();

        Task LoadGeneralSupportGroupAsync();
        Task<CIInsertResponse> CIInsertAsync(CIInsertRequest PlanInsertRequest);
        Task<CIUpdateResponse> CIUpdateAsync(CIUpdateRequest PlanUpdateRequest);
        Task<CIDeleteResponse> CIDeleteAsync(Guid id);

    }
}
