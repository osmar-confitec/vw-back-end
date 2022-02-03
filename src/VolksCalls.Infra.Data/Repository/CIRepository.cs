using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CI;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Infra.Data.Repository
{
    public class CIRepository : BaseRepository<CIDomain>, ICIRepository
    {
        public CIRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
