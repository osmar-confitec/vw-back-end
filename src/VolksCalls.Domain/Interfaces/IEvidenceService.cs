using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.Evidences;
using VolksCalls.Domain.Models.Evidences.Request;
using VolksCalls.Domain.Models.Evidences.Response;

namespace VolksCalls.Domain.Interfaces
{
   public interface IEvidenceService:IDisposable
    {
        Task<SendEvidencesResponse> SendEvidencesAsync(SendEvidencesRequest sendEvidencesRequest, List<IFormFile> files);

    }
}
