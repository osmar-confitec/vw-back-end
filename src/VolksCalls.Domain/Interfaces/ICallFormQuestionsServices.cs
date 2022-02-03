using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.CallForm.Dto;
using VolksCalls.Domain.Models.CallForm.Response;

namespace VolksCalls.Domain.Interfaces
{
   public interface ICallFormQuestionsServices : IBaseService<CallFormQuestionsDomain>
    {
        Task<CallFormQuestionsInsertResponse> CallFormQuestionsInsertAsync(CallFormQuestionsDto callFormQuestionsDto, CallFormDomain callFormDomain);

        Task<CallFormQuestionsUpdateResponse> CallFormQuestionsUpdateAsync(CallFormQuestionsUpdateDto callFormQuestionsUpdateDto);

        Task<CallFormQuestionsDeleteResponse> CallFormQuestionsDeleteAsync(Guid id);


    }
}
