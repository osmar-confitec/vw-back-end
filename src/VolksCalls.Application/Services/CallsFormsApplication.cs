using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.CallForm.Dto;
using VolksCalls.Domain.Models.CallForm.Request;
using VolksCalls.Domain.Models.CallForm.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.Data.Extension;

namespace VolksCalls.Application.Services
{
    public class CallsFormsApplication : BaseApplication, ICallsFormsApplication
    {

        readonly IMapper _mapper;
        readonly ICallsFormsServices _callsFormsServices;
        readonly IBaseConsultRepository<CallFormDomain> _callFormConsultRepository;
        public CallsFormsApplication(IMapper mapper,
                                     IUnitOfWork _unitOfWork,
                                     ICallsFormsServices callsFormsServices,
                                     LNotifications _LNotifications)
        : base(_unitOfWork, _LNotifications)
        {
            _mapper = mapper;
            _callsFormsServices = callsFormsServices;
            _callFormConsultRepository = unitOfWork.GetRepository<CallFormDomain>();
        }

        public async Task<CallFormDeleteResponse> CallFormDeleteAsync(Guid id)
        {
            var ret = await _callsFormsServices.CallFormDeleteAsync(id);
            await unitOfWork.CommitAsync();
            return ret;
        }

        public async Task<CallFormInsertResponse> CallFormInsertAsync(CallFormInsertRequest callFormInsertRequest)
        {
            var ret = await _callsFormsServices.CallFormInsertAsync(callFormInsertRequest);
            await unitOfWork.CommitAsync();
            return ret;
        }

        public async Task<CallFormUpdateResponse> CallFormUpdateAsync(CallFormUpdateRequest callFormUpdateRequest)
        {
            var ret = await _callsFormsServices.CallFormUpdateAsync(callFormUpdateRequest);
            await unitOfWork.CommitAsync();
            return ret;
        }

        public async Task<PagedDataResponse<CallFormResponse>> GetCallFormAsync(CallFormListRequest callFormListRequest)
        {
            var query = _callFormConsultRepository.GetQueryable();
            if (!string.IsNullOrEmpty(callFormListRequest.Name))
                query = query.Where(x => x.Name.Contains(callFormListRequest.Name.Trim(), StringComparison.InvariantCultureIgnoreCase));


            query = query.Where(x => x.Active == callFormListRequest.Active);
            query = query.OrderBy(x => x.Name);

            var responseQuery = await query.PaginateAsync(callFormListRequest);
            var responsePaged = _mapper.Map<PagedDataResponse<CallFormResponse>>(responseQuery);

            return responsePaged;
        }

        public async Task<CallFormDetailsResponse> GetCallFormDetailsAsync(Guid id)
        {
            var formDetails = (await _callFormConsultRepository.SearchAsync(x => x.Id == id)).FirstOrDefault();
            var ret = _mapper.Map<CallFormDetailsResponse>(formDetails);
            ret.CallFormQuestionsFormsDtos.AddRange(formDetails.CallFormsQuestions.Where(x=>x.Active).OrderBy(x=>x.Order).Select(x => _mapper.Map<CallFormQuestionsFormsDto>(x)));
            return ret;
        }

        public async Task<CallFormDetailsResponse> GetCallFormDetailsDefaultAsync()
        {
            var formDetails = (await _callFormConsultRepository.SearchAsync(x => x.IsDefault)).FirstOrDefault();
            var ret = _mapper.Map<CallFormDetailsResponse>(formDetails);
            if (ret == null)
                ret = new CallFormDetailsResponse();
            if (formDetails != null)
            ret.CallFormQuestionsFormsDtos.AddRange(formDetails.CallFormsQuestions.Where(x => x.Active).OrderBy(x => x.Order).Select(x => _mapper.Map<CallFormQuestionsFormsDto>(x)));
            return ret;
        }
    }
}
