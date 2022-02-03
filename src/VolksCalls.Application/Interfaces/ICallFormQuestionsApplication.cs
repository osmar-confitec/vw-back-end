using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.CallForm.Response;

namespace VolksCalls.Application.Interfaces
{
   public interface ICallFormQuestionsApplication : IBaseApplication
    {
        Task<CallFormQuestionsDeleteResponse> CallFormQuestionsDeleteAsync(Guid id);
    }
}
