using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.CI;
using VolksCalls.Domain.Models.CI.Request;
using VolksCalls.Domain.Models.CI.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.Data.Extension;

namespace VolksCalls.Application.Services
{
    public class CIApplication : BaseApplication, ICIApplication
    {
        readonly ICIServices _cIServices;
        readonly IBaseConsultRepository<CIDomain> _ciConsultRepository;
        readonly IMapper _mapper;
        public CIApplication(ICIServices cIServices, IMapper mapper, IUnitOfWork _unitOfWork, LNotifications _LNotifications)
                : base(_unitOfWork, _LNotifications)
        {
            _cIServices = cIServices;
            _mapper = mapper;
            _ciConsultRepository = unitOfWork.GetRepository<CIDomain>();
        }

        public async Task<CIDeleteResponse> CIDeleteAsync(Guid id)
        {
            var ret = await _cIServices.CIDeleteAsync(id);
            await unitOfWork.CommitAsync();
            return ret;
        }

        public async Task<CIGetDetailsResponse> CIGetDetailsAsync(Guid id)

            => _mapper.Map<CIGetDetailsResponse>((await _ciConsultRepository.SearchAsync(x => x.Id == id)).FirstOrDefault());

        public async Task<CIInsertResponse> CIInsertAsync(CIInsertRequest PlanInsertRequest)
        {
            var ret = await _cIServices.CIInsertAsync(PlanInsertRequest);
            await unitOfWork.CommitAsync();
            return ret;
        }

        public async Task<CIUpdateResponse> CIUpdateAsync(CIUpdateRequest PlanUpdateRequest)
        {
            var ret = await _cIServices.CIUpdateAsync(PlanUpdateRequest);
            await unitOfWork.CommitAsync();
            return ret;
        }

        public async Task<PagedDataResponse<CIGetResponse>> GetCIChoiceAsync(CIGetRequest cIGetRequest)
        {
            var query = _ciConsultRepository.GetQueryable();
            if (!string.IsNullOrEmpty(cIGetRequest.CIId))
                query = query.Where(x => x.CIId.Contains(cIGetRequest.CIId.Trim(), StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrEmpty(cIGetRequest.CIName))
                query = query.Where(x => x.CIName.Contains(cIGetRequest.CIName.Trim(), StringComparison.InvariantCultureIgnoreCase));

            query = query.Where(x => x.Active == cIGetRequest.Active);
            query = query.OrderBy(x => x.CIName).ThenBy(x => x.CIId);

            var responseQuery = await query.PaginateAsync(cIGetRequest);
            var responsePaged = _mapper.Map<PagedDataResponse<CIGetResponse>>(responseQuery);

            return responsePaged;
        }

        public async Task LoadCIAsync()
        {
            await _cIServices.LoadCIAsync();
            await unitOfWork.CommitAsync();
        }

        public async Task LoadGeneralSupportGroupAsync()
        {
            await _cIServices.LoadGeneralSupportGroupAsync();
            await unitOfWork.CommitAsync();
        }


    }
}
