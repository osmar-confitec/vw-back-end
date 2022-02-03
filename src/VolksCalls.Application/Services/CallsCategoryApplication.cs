using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Models.CallsCategory.Dto;
using VolksCalls.Domain.Models.CallsCategory.Request;
using VolksCalls.Domain.Models.CallsCategory.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.Data.Extension;

namespace VolksCalls.Application.Services
{
    public class CallsCategoryApplication : BaseApplication, ICallsCategoryApplication
    {

        readonly ICallsCategoryServices _callsCategoryService;
        readonly IBaseConsultRepository<CallsCategoryDomain> _callsCategoryConsultRepository;
        readonly IMapper _mapper;
        public CallsCategoryApplication(IUnitOfWork _unitOfWork,
                        ICallsCategoryServices callsCategoryService,
                        IMapper mapper,
                        LNotifications _LNotifications) : base(_unitOfWork, _LNotifications)
        {

            _callsCategoryService = callsCategoryService;
            _mapper = mapper;
            _callsCategoryConsultRepository = unitOfWork.GetRepository<CallsCategoryDomain>();
        }

        public async Task<CallCategoriesResponse> GetCallCategoriesChildrenNodesAsync(CallCategoriesChildrenNodesRequest callCategoriesChildrenNodesRequest)
         => await
            _callsCategoryService.GetCallCategoriesChildrenNodesAsync(callCategoriesChildrenNodesRequest.AllCallCategoriesCheked, callCategoriesChildrenNodesRequest.AllCallCategories, callCategoriesChildrenNodesRequest.CallCategoryChecked);

        public async Task<CallCategoriesResponse> GetCallCategoriesExcelAsync()
                 => await _callsCategoryService.GetCallCategoriesExcelAsync();

        public async Task<CallCategoriesResponse> GetCallCategoriesFromTextAsync(string text)
                 => await _callsCategoryService.GetCallCategoriesFromTextAsync(text);

        public async Task<CallCategoriesResponse> GetCallCategoriesParentsAsync() =>
                        await _callsCategoryService.GetCallCategoriesParentsAsync();


        async Task<List<CallsCategoryDomain>> GetChildren(CallsCategoryDomain callsCategoryDomain, IEnumerable<Guid> IdsNot)
        {

            if (IdsNot == null)
                IdsNot = new List<Guid>();

            return (await _callsCategoryConsultRepository.SearchAsync(x =>
                                          x.CallsCategoryParentId == callsCategoryDomain.Id
                                          && !IdsNot.Contains(x.Id)
                                          )).ToList();

        }

        async Task<CallsCategoryDomain> GetParent(CallsCategoryDomain callsCategoryDomain, IEnumerable<Guid> IdsNot)
        {

            if (IdsNot == null)
                IdsNot = new List<Guid>();

            return (await _callsCategoryConsultRepository
                                          .SearchAsync(x => x.Id == callsCategoryDomain.CallsCategoryParentId
                                           && !IdsNot.Contains(x.Id)))
                                          .FirstOrDefault();

        }


        public async Task<List<CallCategoriesListResponse>>
            GetCallsCategoryAsync(CallsCategoryGetRequest callsCategoryGetRequest)
        {

            var responsePaged = new PagedDataResponse<CallCategoriesListResponse>();
            var listItens = new List<CallCategoriesListResponse>();
            var levelsConsult = new List<int> { 2, 3 };

            var query = _callsCategoryConsultRepository.GetQueryable();

            if (!string.IsNullOrEmpty(callsCategoryGetRequest.Description))
                query = query.Where(x => x.Description.Contains(callsCategoryGetRequest.Description));

            query = query.Where(x => levelsConsult.Contains(x.Level));

            var listConsult = await query
                .ToListAsync();

            var lstNot = listConsult.Select(x => x.Id);
            var listMerge = new List<CallsCategoryDomain>();

            foreach (var item in listConsult)
            {

                if (item.Level == 3)
                {
                    var parentTwoLevels = await GetParent(item, lstNot);
                    if (parentTwoLevels != null)
                    {
                        listMerge.Add(parentTwoLevels);
                        var parentFirst = await GetParent(parentTwoLevels, lstNot);
                        listMerge.Add(parentFirst);
                    }


                    var listFourLevels = await GetChildren(item, lstNot);
                    listMerge.AddRange(listFourLevels);
                    foreach (var itemFour in listFourLevels)
                    {
                        listMerge.AddRange(await GetChildren(itemFour, lstNot));
                    }
                }
                else
                {
                    /*level 2*/
                    var parentFirstLevels = await GetParent(item, lstNot);
                    if (parentFirstLevels != null)
                        listMerge.Add(parentFirstLevels);

                    var listThirdLevels = await GetChildren(item, lstNot);
                    listMerge.AddRange(listThirdLevels);
                    foreach (var itemThird in listThirdLevels)
                    {
                        var listFourLevels = await GetChildren(itemThird, lstNot);
                        listMerge.AddRange(listFourLevels);
                        foreach (var itemFour in listFourLevels)
                        {
                            listMerge.AddRange(await GetChildren(itemFour, lstNot));
                        }
                    }

                }

            }
            listConsult.AddRange(listMerge);

            var levelsFour = listConsult.Where(x => x.Level == 4);

            foreach (var item in levelsFour)
            {
                var ci = listConsult.FirstOrDefault(x => x.CallsCategoryParentId == item.Id).CI;
                var Thirdlevel = (listConsult.FirstOrDefault(x => x.Id == item.CallsCategoryParentId));
                var secondlevel = (listConsult.FirstOrDefault(x => x.Id == Thirdlevel.CallsCategoryParentId));
                var firstlevel = (listConsult.FirstOrDefault(x => x.Id == secondlevel.CallsCategoryParentId));

                listItens.Add(new CallCategoriesListResponse
                {
                    CallGroup = ci == null ? "" : ci.CallGroup,
                    CIId = ci == null ? "" : ci.CIId,
                    CIName = ci == null ? "" : ci.CIName,
                    DescriptionFirst = firstlevel.Description,
                    IdFirst = firstlevel.Id,
                    DescriptionSecond = secondlevel.Description,
                    IdSecond = secondlevel.Id,
                    DescriptionFour = item.Description,
                    IdFour = item.Id,
                    DescriptionThird = Thirdlevel.Description,
                    IdThird = Thirdlevel.Id
                });
            }
            return listItens.OrderBy(x => x.DescriptionSecond).ThenBy(x => x.DescriptionThird).ThenBy(x => x.DescriptionFour).ToList();
        }

        public async Task LoadOfTicketCategoriesAsync()
        {
            await _callsCategoryService.LoadOfTicketCategoriesAsync();
            await unitOfWork.CommitAsync();

        }

        public async Task LoadOfTicketCategoriesNewAsync()
        {
            await _callsCategoryService.LoadOfTicketCategoriesNewAsync();
            await unitOfWork.CommitAsync();
        }

        public async Task<PagedDataResponse<CallsCategoryGetResponse>> GetCallCategoriesAsync(CallsCategoryGetRequest callsCategoryGetRequest)
        {
            
            var query = _callsCategoryConsultRepository.GetQueryable();
            if (!string.IsNullOrEmpty(callsCategoryGetRequest.Path))
            {
                if (!callsCategoryGetRequest.SearchExactWord)
                     query = query.Where(x => x.Patch.Contains(callsCategoryGetRequest.Path.Trim(), StringComparison.InvariantCultureIgnoreCase));
                else
                    query = query.Where(x => x.Patch  == callsCategoryGetRequest.Path);
            }
             

            if (callsCategoryGetRequest.Active.HasValue)
                query = query.Where(x => x.Active == callsCategoryGetRequest.Active.Value);

            query = query.OrderBy(x => x.CallsCategoryParentId).ThenBy(x => x.Patch.Length);

            var responseQuery = await query.PaginateAsync(callsCategoryGetRequest);
            var responsePaged = _mapper.Map<PagedDataResponse<CallsCategoryGetResponse>>(responseQuery);

            return responsePaged;
        }

        public async Task<CallsCategoryManageResponse> GetCallsCategoryManageAsync(Guid Id)
        {
            var callsCategoryManageResponse = new CallsCategoryManageResponse();
            var position = 10001;
            var callsCategory = (await _callsCategoryConsultRepository.SearchAsync(x =>  x.Id == Id)).FirstOrDefault();
            if (callsCategory != null)
            {
                callsCategoryManageResponse.Patch = callsCategory.Patch;
                var callsCategoryManageDto = _mapper.Map<CallsCategoryManageDto>(callsCategory);
                callsCategoryManageDto.Position = position;
                callsCategoryManageResponse.callsCategoryManageDtos.Add(callsCategoryManageDto);
                var callsCategoryParent = callsCategory.CallsCategoryParent;
                while (callsCategoryParent != null)
                {
                    var callsCategoryManageDtoLoop = _mapper.Map<CallsCategoryManageDto>(callsCategoryParent);
                    position++;
                    callsCategoryManageDtoLoop.Position = position;
                    callsCategoryManageResponse.callsCategoryManageDtos.Add(callsCategoryManageDtoLoop);
                    callsCategoryParent = callsCategoryParent.CallsCategoryParent;
                }
                callsCategoryManageResponse.callsCategoryManageDtos = callsCategoryManageResponse.callsCategoryManageDtos.OrderByDescending(x => x.Position).ToList();
            }
            else
                LNotifications.Add(new Notification { Message = " Atenção consulta não retornou resultados. " });

            return callsCategoryManageResponse;
        }

        public async Task<CallCategoryDeleteResponse> CallCategoryDeleteAsync(Guid id) {

            var ret =  await _callsCategoryService.CallCategoryDeleteAsync(id);
            await unitOfWork.CommitAsync();
            return ret;
        }

        public async Task<CallCategoryInsertResponse> CallCategoryInsertAsync(CallCategoryInsertRequest callCategoryInsertRequest)
        {
            var ret = await _callsCategoryService.CallCategoryInsertAsync(callCategoryInsertRequest);
            await unitOfWork.CommitAsync();
            return ret;
        }

        public async Task<CallCategoryUpdateResponse> CallCategoryUpdateAsync(CallCategoryUpdateRequest callCategoryUpdateRequest)
        {
            var ret = await _callsCategoryService.CallCategoryUpdateAsync(callCategoryUpdateRequest);
            await unitOfWork.CommitAsync();
            return ret;
        }

        public async Task LoadQtdChildrenAsync()
        {
            await _callsCategoryService.LoadQtdChildrenAsync();
            await unitOfWork.CommitAsync();
            
        }
    }
}
