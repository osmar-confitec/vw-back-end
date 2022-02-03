using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.Evidences.Request;
using VolksCalls.Domain.Models.Evidences.Response;

namespace VolksCalls.Application.Interfaces
{
   public interface IEvidenceApplication : IBaseApplication
    {
        Task<SendEvidencesResponse> SendEvidencesAsync(string sendEvidencesRequest, List<IFormFile> files);

        Task SendEmailAsync();

    }
}
