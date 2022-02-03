using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.CallForm.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Application.Services
{
    public class CallFormQuestionsApplication : BaseApplication, ICallFormQuestionsApplication
    {
        readonly ICallFormQuestionsServices _callFormQuestionsServices;
        public CallFormQuestionsApplication(ICallFormQuestionsServices callFormQuestionsServices, IUnitOfWork _unitOfWork, LNotifications _LNotifications)
            : base(_unitOfWork, _LNotifications)
        {

            _callFormQuestionsServices = callFormQuestionsServices;
        }

        public async Task<CallFormQuestionsDeleteResponse> CallFormQuestionsDeleteAsync(Guid id)
        {
            var ret = await _callFormQuestionsServices.CallFormQuestionsDeleteAsync(id);
            await unitOfWork.CommitAsync();
            return ret;
        }
    }
}
