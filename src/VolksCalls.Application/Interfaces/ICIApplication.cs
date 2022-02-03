using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.CI.Request;
using VolksCalls.Domain.Models.CI.Response;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Application.Interfaces
{
   public interface ICIApplication: IBaseApplication
    {
        Task LoadCIAsync();

        Task LoadGeneralSupportGroupAsync();

        
        Task<CIInsertResponse> CIInsertAsync(CIInsertRequest PlanInsertRequest);
        Task<PagedDataResponse<CIGetResponse>> GetCIChoiceAsync(CIGetRequest cIGetRequest );

        Task<CIUpdateResponse> CIUpdateAsync(CIUpdateRequest PlanUpdateRequest);
        Task<CIDeleteResponse> CIDeleteAsync(Guid id);
        Task<CIGetDetailsResponse> CIGetDetailsAsync(Guid id);


    }
}
