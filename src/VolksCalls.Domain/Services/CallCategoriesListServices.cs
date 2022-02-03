using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Models.CallCategoriesList;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Domain.Services
{
    public class CallCategoriesListServices : BaseServiceEntity<CallCategoriesListDomain>, ICallCategoriesListServices
    {

        readonly IBaseConsultRepository<CallsCategoryDomain> _callsCategoryConsultRepository;
        readonly IMapper _mapper;
        public CallCategoriesListServices(ICallCategoriesListRepository iBaseRepository,
            IMapper mapper, IUser user,
            LNotifications lNotifications) : base(iBaseRepository,  user, lNotifications)
        {
            _mapper = mapper;
            _callsCategoryConsultRepository = _iBaseRepository.unitOfWork.GetRepository<CallsCategoryDomain>();
        }

        public async Task LoadCallCategoriesListAsync()
        {
            var query = _callsCategoryConsultRepository.GetQueryable();
            query = query.Where(x => x.Active);
            var list = await query.ToListAsync();
            var levelsFour = list.Where(x => x.Level == 4);
            foreach (var item in levelsFour)
            {
                var ci = list.FirstOrDefault(x => x.CallsCategoryParentId == item.Id).CI;
                var thirdlevel = (list.FirstOrDefault(x => x.Id == item.CallsCategoryParentId));
                var secondlevel = (list.FirstOrDefault(x => x.Id == thirdlevel.CallsCategoryParentId));
                var firstlevel = (list.FirstOrDefault(x => x.Id == secondlevel.CallsCategoryParentId));
                var callCategoriesListDomain = new
                CallCategoriesListDomain
                {
                    CICode = ci == null ? null : (ci.Id as Guid?),
                    CallGroup = ci == null ?  null:ci.CallGroup,
                    CIId = ci == null ? null : ci.CIId,
                    CIName = ci == null ? null : ci.CIName,
                    DescriptionFirst = firstlevel.Description,
                    IdFirst = firstlevel.Id,
                    DescriptionSecond = secondlevel.Description,
                    IdSecond = secondlevel.Id,
                    DescriptionThird = thirdlevel.Description,
                    IdThird = thirdlevel.Id,
                    DescriptionFour = item.Description,
                    IdFour = item.Id
                };

                SetInsertEntity(callCategoriesListDomain);
                Add(callCategoriesListDomain);

            }

        }
    }
}
