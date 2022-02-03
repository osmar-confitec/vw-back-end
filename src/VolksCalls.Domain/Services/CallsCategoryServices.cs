using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.CallsCategory.Dto;
using VolksCalls.Domain.Models.CallsCategory.Request;
using VolksCalls.Domain.Models.CallsCategory.Response;
using VolksCalls.Domain.Models.CI;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.Documents;

namespace VolksCalls.Domain.Services
{
    public class CallsCategoryServices : BaseServiceEntity<CallsCategoryDomain>, ICallsCategoryServices
    {
        readonly IConfiguration _configuration;
        readonly IHostEnvironment _hostEnvironment;
        readonly IMapper _mapper;
        const string textRoot = "Menu";
        readonly IBaseConsultRepository<CIDomain> _cIConsultRepository;
        readonly IBaseConsultRepository<CallFormDomain> _callFormRepository;
        public CallsCategoryServices(ICallsCategoryRepository _callsCategoryRepository,
                                     IConfiguration configuration,
                                     IHostEnvironment hostEnvironment,
                                     IMapper mapper,
                                     IUser user,
                                     LNotifications lNotifications)
                                    : base(_callsCategoryRepository, user, lNotifications)
        {
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _cIConsultRepository = _iBaseRepository.unitOfWork.GetRepository<CIDomain>();
            _callFormRepository = _iBaseRepository.unitOfWork.GetRepository<CallFormDomain>();
        }


        #region " GetCallCategoriesExcelAsync "

        CallCategoryDto GetCallCategories(CallCategoryDto callCategoryDto, string textSearch)
        {

            var callCategorySearchDto = default(CallCategoryDto);
            if (!string.IsNullOrEmpty(textSearch))
            {
                if (!callCategoryDto.Children.Any(x => x.Text == textSearch))
                {
                    callCategorySearchDto = new CallCategoryDto { Text = textSearch };
                    callCategoryDto.Children.Add(callCategorySearchDto);
                }
                else
                {
                    callCategorySearchDto = callCategoryDto.Children.FirstOrDefault(x => x.Text == textSearch);
                }
            }
            return callCategorySearchDto;
        }

        void FindCallCategories(CallCategoryDto callCategoriesResponse, IEnumerable<string> columns)
        {
            foreach (var column in columns)
            {
                var responseCat = GetCallCategories(callCategoriesResponse, column);
                if (responseCat == null)
                    break;
                callCategoriesResponse = responseCat;
            }
        }

        public async Task<CallCategoriesResponse> GetCallCategoriesExcelAsync()
        {

            return await Task.Run(() =>
            {

                var folderCategoriesCallsExcel = _configuration.GetSection("CategoriesCallsExcel")?.Value;
                string patchCategoriesCallsExcel = Path.Combine(_hostEnvironment.ContentRootPath, folderCategoriesCallsExcel);
                var response = new CallCategoriesResponse { Root = new CallCategoryDto { Text = "Root", Value = "Root" } };
                var sheetDocument = "Sheet1";

                var excelDocument = new ExcelDocument(_lNotifications, patchCategoriesCallsExcel);

                if (excelDocument.notifications.Any())
                    return null;

                var dataSetExcelDocument = excelDocument.ReadExcelFileInLine();
                if (
                    dataSetExcelDocument.Tables.Count <= 0
                    || !dataSetExcelDocument.Tables.Contains(sheetDocument)
                    || dataSetExcelDocument.Tables[sheetDocument].Columns.Count != 5
                    )
                {
                    _lNotifications.Add(new Notification { Message = " Atenção! não foi possível ler as informações do excel verifique o arquivo. " });
                    return null;
                }
                var tableRows = dataSetExcelDocument.Tables[sheetDocument].AsEnumerable();
                var tableColumns = dataSetExcelDocument.Tables[sheetDocument].Columns;

                foreach (var row in tableRows)
                {
                    var lstColumns = new List<string>();
                    foreach (DataColumn column in tableColumns)
                    {
                        lstColumns.Add(row.Field<string>(column.ColumnName));
                    }
                    FindCallCategories(response.Root, lstColumns);
                }
                return response;

            });


        }
        #endregion

        CallCategoryDto GetRootCategory() => new CallCategoryDto
        {
            ParentId = string.Empty,
            Text = textRoot,
            Value = Guid.NewGuid().ToString()
        };


        public void LoadCallCategoriesDtosResponse(CallCategoriesResponse callCategoriesResponse,
                    CallCategoryDto callCategoryDto)
        {

            AddCallCategoriesDtos(callCategoriesResponse, callCategoryDto);
            foreach (var item in callCategoryDto.Children)
            {
                AddCallCategoriesDtos(callCategoriesResponse, item);
                LoadCallCategoriesDtosResponse(callCategoriesResponse, item);
            }

        }
        public void LoadCallCategoriesDtosResponse(CallCategoriesResponse callCategoriesResponse)
        {
            foreach (var item in callCategoriesResponse.Root.Children)
            {
                AddCallCategoriesDtos(callCategoriesResponse, item);
                LoadCallCategoriesDtosResponse(callCategoriesResponse, item);
            }
        }

        void AddCallCategoriesDtos(CallCategoriesResponse callCategoriesResponse,
                                   CallCategoryDto item)
        {
            if (!callCategoriesResponse.CallCategoriesDtos.Any(x => x.Value == item.Value))
                callCategoriesResponse.CallCategoriesDtos.Add(new CallCategoryDto
                {
                    IsCI = item.IsCI,
                    Checked = item.Checked,
                    IsParentCI = item.IsParentCI,
                    QtdChildren = item.QtdChildren,
                    Text = item.Text,
                    Value = item.Value,
                    ParentId = item.ParentId,
                    Path = item.Path
                });
        }

        public async Task<CallCategoriesResponse> GetCallCategoriesParentsAsync()
        {
            var returnCallCategoriesResponse = new CallCategoriesResponse { Root = GetRootCategory() };
            var lstCategoriesParents = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Active && x.CallsCategoryParentId == null))
                                        .OrderBy(x => x.Description).ToList();
            foreach (var categoriesParent in lstCategoriesParents)
            {

                var callCategoriesResponse = _mapper.Map<CallCategoryDto>(categoriesParent);


                var children = categoriesParent.CallsCategoriesChildren.Where(x => x.Active).OrderBy(x => x.Description).ToList();
                foreach (var child in children)
                {
                    var callCategoryDtoAdd = _mapper.Map<CallCategoryDto>(child);
                    callCategoriesResponse.Children.Add(callCategoryDtoAdd);
                }
                returnCallCategoriesResponse.Root.Children.Add(callCategoriesResponse);
            }
            LoadCallCategoriesDtosResponse(returnCallCategoriesResponse);
            return returnCallCategoriesResponse;
        }

        void TreatCategories(IEnumerable<CallCategoryDto> categories,
                             CallCategoryDto callCategoryDto)
        {
            /*treeview com 5 niveis de excel chumbado*/
            var lstCategories = categories.Where(x => x.ParentId == callCategoryDto.Value).OrderBy(x => x.Text).ToList();


            foreach (var item in lstCategories)
            {

                item.Path += callCategoryDto.Path + item.Text + " - ";
                TreatCategories(categories, item);
                callCategoryDto.Children.Add(item);

            }
        }


        CallCategoriesResponse TreatCategories(IEnumerable<CallCategoryDto> categories)
        {
            var returnCallCategoriesResponse = new CallCategoriesResponse { Root = GetRootCategory() };
            var lstCategories = categories.Where(x => string.IsNullOrEmpty(x.ParentId)).OrderBy(x => x.Text).ToList();
            foreach (var item in lstCategories)
            {
                item.Path += item.Text + " - ";
                TreatCategories(categories, item);
                returnCallCategoriesResponse.Root.Children.Add(item);
            }
            return returnCallCategoriesResponse;
        }

        bool ValidParentCategoryAdd(IEnumerable<CallsCategoryDomain> lstCategorySearch,
                                    IEnumerable<CallCategoryDto> lstCategoryAdd,
                                    CallsCategoryDomain callsCategoryParentDomain)
        {

            return (
                        callsCategoryParentDomain != null
                    && callsCategoryParentDomain.CallsCategoryParentId.HasValue
                    && !lstCategoryAdd.Any(x => x.Value == callsCategoryParentDomain.CallsCategoryParentId.ToString())
                    && !lstCategorySearch.Any(x => x.Id.ToString() == callsCategoryParentDomain.CallsCategoryParentId.ToString())
                    );
        }

        List<CallsCategoryDomain> GetCI(CallsCategoryDomain callsCategoryDomain)
        {
            var lstReturn = new List<CallsCategoryDomain>();
            var Itens = callsCategoryDomain.CallsCategoriesChildren;

            if (Itens.Any(x => x.CI != null))
            {
                lstReturn.AddRange(Itens);
                return lstReturn;
            }

            if (Itens.Any())
                lstReturn.AddRange(GetCI(Itens.FirstOrDefault()));
            return lstReturn;
        }
        List<CallsCategoryDomain> GetCI(List<CallsCategoryDomain> ListCallCategories)
        {

            var lstReturn = new List<CallsCategoryDomain>();
            foreach (var item in ListCallCategories)
            {
                var ci = item.CI;
                if (ci == null)
                {
                    var Itens = item.CallsCategoriesChildren.Where(x => x.Active).ToList();

                    if (Itens.Any(x => x.CI != null))
                    {
                        lstReturn.AddRange(Itens);
                        continue;
                    }
                }
            }
            ListCallCategories.AddRange(lstReturn);
            return ListCallCategories;
        }
        public async Task<CallCategoriesResponse> GetCallCategoriesFromTextAsync(string text)
        {
            var lstCategoriesFromText = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Active && x.Description.Contains(text, StringComparison.InvariantCultureIgnoreCase))).ToList();
            if (!lstCategoriesFromText.Any())
                return await GetCallCategoriesParentsAsync();
            //Buscar os CI
            lstCategoriesFromText = (GetCI(lstCategoriesFromText));


            var lstCallCategoriesParentsAdd = new List<CallCategoryDto>();
            var lstCallCategories = new List<CallCategoryDto>();


            lstCallCategories.AddRange(lstCategoriesFromText.Select(x => _mapper.Map<CallCategoryDto>(x)));

            foreach (var categoryFromText in lstCategoriesFromText)
            {
                if (ValidParentCategoryAdd(lstCategoriesFromText,
                                           lstCallCategoriesParentsAdd,
                                           categoryFromText))
                {
                    var callCategoryParent = categoryFromText.CallsCategoryParent;
                    var callCategorySearchDto = _mapper.Map<CallCategoryDto>(callCategoryParent);
                    lstCallCategoriesParentsAdd.Add(callCategorySearchDto);
                    while (callCategoryParent != null)
                    {
                        callCategoryParent = callCategoryParent.CallsCategoryParent;
                        ValidAddCallCategoriesParentsAdd(lstCategoriesFromText, lstCallCategoriesParentsAdd, callCategoryParent);
                    }
                }
            }
            if (lstCallCategoriesParentsAdd.Any())
                lstCallCategories.AddRange(lstCallCategoriesParentsAdd);
            var resp = TreatCategories(lstCallCategories);
            LoadCallCategoriesDtosResponse(resp);
            return resp;
        }

        void ValidAddCallCategoriesParentsAdd(List<CallsCategoryDomain> lstCategoriesFromText,
                                             List<CallCategoryDto> lstCallCategoriesParentsAdd,
                                             CallsCategoryDomain callCategoryParent)
        {
            if (
                        callCategoryParent != null
                    && !lstCategoriesFromText.Any(x => x.Id.ToString() == callCategoryParent.Id.ToString())
                    && !lstCallCategoriesParentsAdd.Any(x => x.Value == callCategoryParent.Id.ToString())
                    )
            {
                var callCategorySearchDto = _mapper.Map<CallCategoryDto>(callCategoryParent);
                lstCallCategoriesParentsAdd.Add(callCategorySearchDto);
            }

        }
        (bool, DataSet) ValidExcelDocument(string patchCategoriesCallsExcel, string sheetDocument)
        {

            var excelDocument = new ExcelDocument(_lNotifications, patchCategoriesCallsExcel);

            if (excelDocument.notifications.Any())
                return (false, null);

            var dataSetExcelDocument = excelDocument.ReadExcelFileInLine();
            if (
                dataSetExcelDocument.Tables.Count <= 0
                || !dataSetExcelDocument.Tables.Contains(sheetDocument)
                || dataSetExcelDocument.Tables[sheetDocument].Columns.Count != 5
                )
            {
                _lNotifications.Add(new Notification { Message = " Atenção! não foi possível ler as informações do excel verifique o arquivo. " });
                return (false, null);
            }
            return (true, dataSetExcelDocument);
        }

        (bool, DataSet) ValidExcelDocumentNew(string patchCategoriesCallsExcel, string sheetDocument)
        {

            var excelDocument = new ExcelDocument(_lNotifications, patchCategoriesCallsExcel);

            if (excelDocument.notifications.Any())
                return (false, null);

            var dataSetExcelDocument = excelDocument.ReadExcelFileInLine();
            if (
                dataSetExcelDocument.Tables.Count <= 0
                || !dataSetExcelDocument.Tables.Contains(sheetDocument)
                )
            {
                _lNotifications.Add(new Notification { Message = " Atenção! não foi possível ler as informações do excel verifique o arquivo. " });
                return (false, null);
            }
            return (true, dataSetExcelDocument);
        }



        void UpdateQtdChildrenCallsCategoryDomain(CallsCategoryDomain callsCategoryDomain)
        {

            foreach (var item in callsCategoryDomain.CallsCategoriesChildren)
            {
                item.QtdChildren = item.CallsCategoriesChildren.Count();
                UpdateQtdChildrenCallsCategoryDomain(item);
            }
        }
        public async Task LoadOfTicketCategoriesAsync()
        {

            var folderCategoriesCallsExcel = _configuration.GetSection("CategoriesCallsExcel")?.Value;
            string patchCategoriesCallsExcel = Path.Combine(_hostEnvironment.ContentRootPath, folderCategoriesCallsExcel);
            var sheetDocument = "Sheet1";
            var listCallsCategoryAdd = new List<CallsCategoryDomain>();

            var respValidate = ValidExcelDocument(patchCategoriesCallsExcel, sheetDocument);
            if (!respValidate.Item1)
                return;

            var tableRows = respValidate.Item2.Tables[sheetDocument].AsEnumerable();
            var tableColumns = respValidate.Item2.Tables[sheetDocument].Columns;

            /*primeiro nivel*/
            var firstLevel = tableRows.Select(x => x.Field<string>("1")).Distinct();

            foreach (var first in firstLevel)
            {
                var retSecondLevel = GetSecondLevel(tableRows, first);
                CallsCategoryDomain callsCategoryFirstDomain = retSecondLevel.Item1;
                IEnumerable<string> secondLevel = retSecondLevel.Item2;



                foreach (var second in secondLevel)
                {

                    var retThirdLevel = GetthirdLevel(tableRows, first, second);
                    CallsCategoryDomain callsCategorySecondDomain = retThirdLevel.Item1;
                    IEnumerable<string> thirdLevel = retThirdLevel.Item2;


                    foreach (var third in thirdLevel)
                    {
                        var retFourLevel = GetFourLevel(tableRows, first, second, third);
                        CallsCategoryDomain callsCategoryThirdDomain = retFourLevel.Item1;
                        IEnumerable<string> fourLevel = retFourLevel.Item2;

                        foreach (var four in fourLevel)
                        {
                            var retFiveLevel = GetFiveLevel(tableRows, first, second, third, four);
                            CallsCategoryDomain callsCategoryFourDomain = retFiveLevel.Item1;
                            IEnumerable<string> fiveLevel = retFiveLevel.Item2;

                            foreach (var five in fiveLevel)
                            {
                                var callsCategoryFiveDomain = new CallsCategoryDomain { Level = 5, Description = five };
                                SetInsertEntity(callsCategoryFiveDomain);
                                callsCategoryFourDomain.CallsCategoriesChildren.Add(callsCategoryFiveDomain);
                            }
                            callsCategoryThirdDomain.CallsCategoriesChildren.Add(callsCategoryFourDomain);
                        }
                        callsCategorySecondDomain.CallsCategoriesChildren.Add(callsCategoryThirdDomain);
                    }

                    callsCategoryFirstDomain.CallsCategoriesChildren.Add(callsCategorySecondDomain);
                }
                listCallsCategoryAdd.Add(callsCategoryFirstDomain);
            }

            foreach (var item in listCallsCategoryAdd)
            {

                item.QtdChildren = item.CallsCategoriesChildren.Count();
                UpdateQtdChildrenCallsCategoryDomain(item);
            }

            foreach (var item in listCallsCategoryAdd)
            {
                await AddAsync(item);
            }
        }
        (CallsCategoryDomain, IEnumerable<string>) GetFourLevel(EnumerableRowCollection<DataRow> tableRows, string first, string second, string third)
        {
            var callsCategoryThirdDomain = new CallsCategoryDomain { Level = 3, Description = third };
            SetInsertEntity(callsCategoryThirdDomain);
            // await AddAsync(callsCategoryThirdDomain);

            /*verificar terceiro nivel*/
            var fourLevel = new List<string>();
            fourLevel.AddRange(tableRows.Where(x => x.Field<string>("1") == first
                                        && x.Field<string>("2") == second
                                        && x.Field<string>("3") == third)
                                        .Select(x => x.Field<string>("4")).Distinct());
            return (callsCategoryThirdDomain, fourLevel);
        }
        (CallsCategoryDomain, IEnumerable<string>) GetthirdLevel(EnumerableRowCollection<DataRow> tableRows, string first, string second)
        {
            var callsCategorySecondDomain = new CallsCategoryDomain { Level = 2, Description = second };
            SetInsertEntity(callsCategorySecondDomain);
            //  await AddAsync(callsCategorySecondDomain);
            /*verificar terceiro nivel*/
            var thirdLevel = new List<string>();
            thirdLevel.AddRange(tableRows.Where(x => x.Field<string>("1") == first
                                             && x.Field<string>("2") == second)
                                            .Select(x => x.Field<string>("3")).Distinct());
            return (callsCategorySecondDomain, thirdLevel);
        }
        (CallsCategoryDomain, IEnumerable<string>) GetSecondLevel(EnumerableRowCollection<DataRow> tableRows, string first)
        {
            var callsCategoryFirstDomain = new CallsCategoryDomain { Level = 1, Description = first };

            SetInsertEntity(callsCategoryFirstDomain);
            // await AddAsync(callsCategoryFirstDomain);
            /*verificar segundo nivel*/
            var secondLevel = new List<string>();
            secondLevel.AddRange(tableRows.Where(x => x.Field<string>("1") == first).Select(x => x.Field<string>("2")).Distinct());
            return (callsCategoryFirstDomain, secondLevel);
        }
        (CallsCategoryDomain, IEnumerable<string>) GetFiveLevel(EnumerableRowCollection<DataRow> tableRows, string first, string second, string third, string four)
        {
            var callsCategoryFourDomain = new CallsCategoryDomain { Level = 4, Description = four };
            SetInsertEntity(callsCategoryFourDomain);
            // await AddAsync(callsCategoryFourDomain);

            /*verificar quinto nivel*/
            var fiveLevel = new List<string>();
            fiveLevel.AddRange(tableRows.Where(x => x.Field<string>("1") == first
                                         && x.Field<string>("2") == second
                                         && x.Field<string>("3") == third
                                         && x.Field<string>("4") == four
                                         )
                                        .Select(x => x.Field<string>("Cis")).Distinct());
            return (callsCategoryFourDomain, fiveLevel);

        }



        void TreatCategoriesChecked(IEnumerable<Guid> AllCallCategoriesCheked, CallCategoryDto callCategoryDtos)
        {

            foreach (var callCategoryDto in callCategoryDtos.Children)
            {
                callCategoryDto.Checked = (AllCallCategoriesCheked.Any(x => x.ToString() == callCategoryDto.Value));
                TreatCategoriesChecked(AllCallCategoriesCheked, callCategoryDto);
            }
        }
        void TreatCategoriesChecked(IEnumerable<Guid> AllCallCategoriesCheked, List<CallCategoryDto> callCategoriesDtos)
        {
            foreach (var callCategoryDto in callCategoriesDtos)
            {
                callCategoryDto.Checked = (AllCallCategoriesCheked.Any(x => x.ToString() == callCategoryDto.Value));
                TreatCategoriesChecked(AllCallCategoriesCheked, callCategoryDto);
            }
        }
        public async Task<CallCategoriesResponse> GetCallCategoriesChildrenNodesAsync(IEnumerable<Guid> AllCallCategoriesCheked,
                                                                                      IEnumerable<Guid> AllCallCategories,
                                                                                      Guid CallCategoryChecked)
        {
            var lstCategories = new List<CallsCategoryDomain>();
            var lstCategoriesChildren = new List<CallsCategoryDomain>();

            lstCategories = (await _iBaseRepository._repositoryConsult.SearchAsync(x => AllCallCategories.Contains(x.Id))).ToList();
            lstCategoriesChildren = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Active && x.CallsCategoryParentId == CallCategoryChecked)).ToList();
            lstCategories.AddRange(lstCategoriesChildren);
            var callCategoriesResponse = TreatCategories(lstCategories.Select(x => _mapper.Map<CallCategoryDto>(x)));
            LoadCallCategoriesDtosResponse(callCategoriesResponse);
            return callCategoriesResponse;
        }

        public async Task LoadOfTicketCategoriesNewAsync()
        {

            var folderCategoriesCallsTxt = _configuration.GetSection("CategoriesCallsNewTxt")?.Value;
            string patchCategoriesCallsTxt = Path.Combine(_hostEnvironment.ContentRootPath, folderCategoriesCallsTxt);

            var listCallsCategoryAdd = new List<CallsCategoryDomain>();
            var ciDefault = (await _cIConsultRepository.SearchAsync(x => x.Active && x.DefaultCI == true)).FirstOrDefault();

            var tableRows = new TxtDocument(_lNotifications, patchCategoriesCallsTxt).LoadTxtDelemiterDataTable(",", new List<string> { "1", "2", "3", "4", "5", "6" });
            foreach (DataRow line in tableRows.Rows)
            {
                var patchLoad = string.Empty;

                foreach (DataColumn column in tableRows.Columns)
                {
                    var lineValue = line.Field<string>(column.ColumnName);


                    if (lineValue != null)
                    {

                        if (!patchLoad.Contains(lineValue))
                        {
                            if (lineValue.Contains(".#"))
                            {
                                var lineValueArray = lineValue.Split('#');
                                if (lineValueArray.Count() > 1)
                                {
                                    patchLoad += lineValueArray[0].Replace(".", "") + "|";
                                }
                            }
                            else
                                patchLoad += lineValue + "|";
                        }



                        if (listCallsCategoryAdd.Any(x => x.Patch == patchLoad))
                            continue;


                        var callcategoryParent = default(CallsCategoryDomain);

                        var callCategory = new CallsCategoryDomain
                        {
                            Description = line.Field<string>(column.ColumnName)

                        };

                        var lineValueSearch = string.Empty;

                        if (lineValue.Contains(".#"))
                        {
                            var lineValueArray = lineValue.Split('#');
                            if (lineValueArray.Count() > 1)
                            {
                                lineValueSearch = lineValueArray[0].Replace(".", "");
                            }
                        }
                        else
                            lineValueSearch = lineValue;



                        if (listCallsCategoryAdd.Any(x => x.Patch == patchLoad.Replace(lineValueSearch + "|", "")))
                        {
                            callcategoryParent = listCallsCategoryAdd.FirstOrDefault(x => x.Patch == patchLoad.Replace(lineValueSearch + "|", ""));
                            callcategoryParent.CallsCategoriesChildren.Add(callCategory);
                        }

                        if (lineValue.Contains(".#"))
                        {
                            var lineValueArray = lineValue.Split('#');
                            if (lineValueArray.Count() > 1)
                            {
                                callCategory.Description = lineValueArray[0].Replace(".", "");
                                var ciId = lineValueArray[1].Split('$');
                                if (ciId.Count() > 0)
                                {
                                    var ci = ((await _cIConsultRepository.SearchAsync(x => x.CIId == ciId[0]))).FirstOrDefault();

                                    if (ci == null)
                                    {
                                        ci = ciDefault;
                                    }
                                    if (ci != null)
                                    {
                                        callCategory.CI = ci;
                                        callCategory.CIId = ci.Id;
                                    }

                                }
                            }
                        }
                        callCategory.Patch = patchLoad;
                        SetInsertEntity(callCategory);
                        await AddAsync(callCategory);


                        listCallsCategoryAdd.Add(callCategory);
                    }

                }
            }
        }

        public async Task<CallCategoryDeleteResponse> CallCategoryDeleteAsync(Guid id)
        {

            var callCategory = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Id == id)).FirstOrDefault();
            if (callCategory != null)
            {
                var callCategoryParent = callCategory.CallsCategoryParent;
                if (callCategory.Active)
                {
                    SetDeleteEntity(callCategory);
                    if (callCategoryParent != null)
                        callCategoryParent.QtdChildren = (callCategoryParent.QtdChildren - 1);

                }

                else
                {
                    SetUpdateEntity(callCategory);
                    if (callCategoryParent != null)
                        callCategoryParent.QtdChildren = (callCategoryParent.QtdChildren + 1);
                }

            }

            else
            {
                _lNotifications.Add(new Notification { Message = "Atenção Categoria não encontrada. " });
            }

            return new CallCategoryDeleteResponse();
        }

        public async Task<CallCategoryInsertResponse> CallCategoryInsertAsync(CallCategoryInsertRequest callCategoryInsertRequest)
        {

            if (callCategoryInsertRequest.Description.Contains("|"))
            {
                _lNotifications.Add(new Notification { Message = $"Atenção a descrição {callCategoryInsertRequest.Description} contém caracteres inválidos = | " });
                return new CallCategoryInsertResponse();
            }

            if (!callCategoryInsertRequest.CiCode.HasValue && !string.IsNullOrEmpty(callCategoryInsertRequest.CallFormId))
            {

                _lNotifications.Add(new Notification { Message = $"Atenção não é possível setar um formulário sem um CI ." });
                return new CallCategoryInsertResponse();
            }
            var patch = "";
            var callCategoryInsert = default(CallsCategoryDomain);
            var callForm = default(CallFormDomain);

            if (!string.IsNullOrEmpty(callCategoryInsertRequest.CallFormId))
            {
                callForm = (await _callFormRepository.SearchAsync(x => x.Active && x.Id.ToString() == callCategoryInsertRequest.CallFormId)).FirstOrDefault();
                if (callForm == null)
                    _lNotifications.Add(new Notification { Message = $"Atenção formulário inexistente ou inativo ." });
            }



            if (callCategoryInsertRequest.CallCategoryParent != null
                                        )
            {
                var parentCategory = (await _iBaseRepository._repositoryConsult
                                                             .SearchAsync(x => x.Active && x.Id == callCategoryInsertRequest.CallCategoryParent.Id))
                                                             .FirstOrDefault();

                if (parentCategory != null)
                {

                    if (parentCategory.CIId.HasValue && callCategoryInsertRequest.CiCode.HasValue)
                    {
                        _lNotifications.Add(new Notification { Message = $"Atenção CI existe para uma categoria anterior e você está tentando setar um CI atualização não permitida." });
                        return new CallCategoryInsertResponse();
                    }

                    patch = parentCategory.Patch + callCategoryInsertRequest.Description + "|";
                    var callCategoryPatchSearch = (await _iBaseRepository._repositoryConsult
                                                             .SearchAsync(x => x.Patch == patch)).FirstOrDefault();

                    if (patch.Split('|')
                         .ToList()
                         .GroupBy(x => x).Any(c => c.Count() > 1))
                    {

                        _lNotifications.Add(new Notification { Message = $"Atenção seleção não pode ter categorias iguais ${patch}" });
                    }
                        

                    if (callCategoryPatchSearch != null)
                    {
                        _lNotifications.Add(new Notification { Message = $"Atenção categoria existente para a seleção {patch} com o status {callCategoryPatchSearch.Active}  ." });
                    }

                    if (_lNotifications.Any())
                        return new CallCategoryInsertResponse();


                        parentCategory.QtdChildren = parentCategory.QtdChildren + 1;
                        callCategoryInsert = _mapper.Map<CallsCategoryDomain>(callCategoryInsertRequest);
                        callCategoryInsert.Patch = patch;
                        if (callForm != null)
                            callCategoryInsert.CallForm = callForm;
                        SetUpdateEntity(parentCategory);
                        SetInsertEntity(callCategoryInsert);
                        Add(callCategoryInsert);
                        return _mapper.Map<CallCategoryInsertResponse>(callCategoryInsert);
                    

                }
                else
                {
                    _lNotifications.Add(new Notification { Message = "Atenção parent de categoria não encontrado." });
                }

                if (_lNotifications.Any())
                    return new CallCategoryInsertResponse();
            }

            callCategoryInsert = _mapper.Map<CallsCategoryDomain>(callCategoryInsertRequest);
            callCategoryInsert.Patch = callCategoryInsertRequest.Description + "|";
            if (callForm != null)
                callCategoryInsert.CallForm = callForm;
            SetInsertEntity(callCategoryInsert);
            Add(callCategoryInsert);
            return _mapper.Map<CallCategoryInsertResponse>(callCategoryInsert);
        }

        public async Task<CallCategoryUpdateResponse> CallCategoryUpdateAsync(CallCategoryUpdateRequest callCategoryUpdateRequest)
        {
            var patch = "";
            var callForm = default(CallFormDomain);
            var callCategoryUpdate = (await _iBaseRepository._repositoryConsult
                                                            .SearchAsync(x => x.Id == callCategoryUpdateRequest.Id))
                                                            .FirstOrDefault();

            if (callCategoryUpdate == null)
            {
                _lNotifications.Add(new Notification { Message = $" Atenção call category não existe." });
                return new CallCategoryUpdateResponse();
            }

            if (!callCategoryUpdateRequest.CiCode.HasValue
                                            && !string.IsNullOrEmpty(callCategoryUpdateRequest.CallFormId))
            {
                _lNotifications.Add(new Notification { Message = $"Atenção não é possível setar um formulário sem um CI ." });
                return new CallCategoryUpdateResponse();
            }

            if (!string.IsNullOrEmpty(callCategoryUpdateRequest.CallFormId))
            {
                callForm = (await _callFormRepository.SearchAsync(x => x.Active && x.Id.ToString() == callCategoryUpdateRequest.CallFormId)).FirstOrDefault();
                if (callForm == null)
                    _lNotifications.Add(new Notification { Message = $"Atenção form inexistente ou inativo ." });
            }

            if (callCategoryUpdateRequest.Description != callCategoryUpdate.Description)
            {

                var children = callCategoryUpdate.CallsCategoriesChildren;
                foreach (var item in children)
                {
                    var list = item.Patch.Split('|').ToList();

                    for (int i = 0; i < list.Count(); i++)
                    {
                        var idx = list.FindIndex(l => l == callCategoryUpdate.Description);
                        if (idx >= 0)
                        {
                            list[idx] = callCategoryUpdateRequest.Description;
                        }
                    }
                    item.Patch = string.Join('|', list);
                    SetUpdateEntity(item);
                }
            }

            var parentCategory = callCategoryUpdate.CallsCategoryParent;
            if (parentCategory != null)
            {
                if (parentCategory != null)
                {
                    patch = parentCategory.Patch + callCategoryUpdateRequest.Description + "|";
                    var callCategoryPatchSearch = (await _iBaseRepository._repositoryConsult
                                                             .SearchAsync(x => x.Active && x.Patch == patch
                                                             && x.Id != callCategoryUpdateRequest.Id)).FirstOrDefault();
                    if (callCategoryPatchSearch != null)
                    {
                        _lNotifications.Add(new Notification { Message = $"Atenção call categoria existente para a seleção {patch} com o status {callCategoryPatchSearch.Active}  ." });
                    }

                }
                else
                    _lNotifications.Add(new Notification { Message = "Atenção parent de categoria não encontrado." });


                if (_lNotifications.Any())
                    return new CallCategoryUpdateResponse();
            }

            SetUpdateEntity(callCategoryUpdate);
            callCategoryUpdate.Patch = callCategoryUpdate.Patch.Replace(callCategoryUpdate.Description + "|", "") + callCategoryUpdateRequest.Description + "|";
            callCategoryUpdate.Description = callCategoryUpdateRequest.Description;
            callCategoryUpdate.CIId = callCategoryUpdateRequest.CiCode;
            if (callForm != null)
                callCategoryUpdate.CallForm = callForm;
            return _mapper.Map<CallCategoryUpdateResponse>(callCategoryUpdate);

        }

        void UpdateCallsCategorQtd(CallsCategoryDomain callsCategoryDomain)
        {
            callsCategoryDomain.QtdChildren = callsCategoryDomain.CallsCategoriesChildren.Count(x => x.Active);
            foreach (var item in callsCategoryDomain.CallsCategoriesChildren)
            {
                item.QtdChildren = item.CallsCategoriesChildren.Count(x => x.Active);
                UpdateCallsCategorQtd(item);
            }
        }

        public async Task LoadQtdChildrenAsync()
        {
            var lstCat = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Active && !x.CallsCategoryParentId.HasValue)).ToList();

            foreach (var item in lstCat)
            {
                item.QtdChildren = item.CallsCategoriesChildren.Count(x => x.Active);
                UpdateCallsCategorQtd(item);
            }
        }
    }
}
