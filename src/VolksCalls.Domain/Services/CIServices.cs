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
using VolksCalls.Domain.Models.CI;
using VolksCalls.Domain.Models.CI.Request;
using VolksCalls.Domain.Models.CI.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.Documents;

namespace VolksCalls.Domain.Services
{
    public class CIServices : BaseServiceEntity<CIDomain>, ICIServices
    {

        readonly IConfiguration _configuration;
        readonly IHostEnvironment _hostEnvironment;
        readonly IMapper _mapper;
        readonly IBaseConsultRepository<CallsCategoryDomain> _callsCategoryRepository;
        public CIServices(ICIRepository _cIRepository,
                          IConfiguration configuration,
                          IMapper mapper, 
                          IHostEnvironment hostEnvironment,
                          IUser user,
                          LNotifications lNotifications)
                        : base(_cIRepository,user,  lNotifications)
        {
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _callsCategoryRepository = _iBaseRepository.unitOfWork.GetRepository<CallsCategoryDomain>();
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
                )
            {
                _lNotifications.Add(new Notification { Message = " Atenção! não foi possível ler as informações do excel verifique o arquivo. " });
                return (false, null);
            }
            return (true, dataSetExcelDocument);
        }

        public async Task LoadCIAsync()
        {
            var folderCIExcel = _configuration.GetSection("CIExcel")?.Value;
            string patchCIExcel = Path.Combine(_hostEnvironment.ContentRootPath, folderCIExcel);
            var sheetDocument = "Relatório 1";

            var respValidate = ValidExcelDocument(patchCIExcel, sheetDocument);
            if (!respValidate.Item1)
                return;

            var tableRows = respValidate.Item2.Tables[sheetDocument].AsEnumerable();
            var tableColumns = respValidate.Item2.Tables[sheetDocument].Columns;

            foreach (var item in tableRows)
            {
                var ci = new CIDomain { CIId = item["CI ID (Logical Name)"].ToString(), CIName = item["CI Name"].ToString() };
                SetInsertEntity(ci);
                await AddAsync(ci);
            }

        }

        (bool, DataSet) ValidGeneralSupportGroupExcelDocument(string patchCategoriesCallsExcel,
            string sheetDocument)
        {

            var excelDocument = new ExcelDocument(_lNotifications, patchCategoriesCallsExcel);

            if (excelDocument.notifications.Any())
                return (false, null);

            var dataSetExcelDocument = excelDocument.ReadExcelFileInLine(2, new List<string> { "CI - General Support Group" });
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

        public async Task LoadGeneralSupportGroupAsync()
        {
            var folderCategoriesCallsExcel = _configuration.GetSection("Assignment")?.Value;
            string patchCategoriesCallsExcel = Path.Combine(_hostEnvironment.ContentRootPath, folderCategoriesCallsExcel);
            var sheetDocument = "CI - General Support Group";
            var listCallsCategoryAdd = new List<CallsCategoryDomain>();

            var respValidate = ValidGeneralSupportGroupExcelDocument(patchCategoriesCallsExcel, sheetDocument);
            if (!respValidate.Item1)
                return;

            var tableRows = respValidate.Item2.Tables[sheetDocument].AsEnumerable();
            var tableColumns = respValidate.Item2.Tables[sheetDocument].Columns;

            foreach (var row in tableRows)
            {
                var ciSearch = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.CIId == row["CI ID"].ToString())).FirstOrDefault();
                if (ciSearch != null)
                {
                    ciSearch.CallGroup = row["General Support Group"].ToString();
                }
            }

        }

        public async Task<CIInsertResponse> CIInsertAsync(CIInsertRequest cIInsertRequest )
        {
           

            if (cIInsertRequest.DefaultCI )
            {

                var ciDefault = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Active && x.DefaultCI == true)).FirstOrDefault();
                if (ciDefault != null)
                {

                    _lNotifications.Add(new Notification { Message = $" Atenção CI Default está setado para outro CI {ciDefault.CIId} " });
                    return new CIInsertResponse();

                }
                   
            }


            var ciCallExists = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.CIId == cIInsertRequest.CIId
                                                                        && x.CallGroup == cIInsertRequest.CallGroup
                                                                        && x.CIName == cIInsertRequest.CIName
                                                                        )).FirstOrDefault();

            if (ciCallExists != null)
            {

                _lNotifications.Add(new Notification { Message = $" Atenção CI {ciCallExists.CIId} já existe para a combinação CIId {cIInsertRequest.CIId} CIName ${cIInsertRequest.CIName} e CallGroup ${cIInsertRequest.CallGroup} no status ${ciCallExists.Active}. " });
                return new CIInsertResponse();
            }



            var ciAdd = _mapper.Map<CIDomain>(cIInsertRequest);
            SetInsertEntity(ciAdd);
            Add(ciAdd);
            return _mapper.Map<CIInsertResponse>(ciAdd);
        }

        public async Task<CIUpdateResponse> CIUpdateAsync(CIUpdateRequest cIUpdateRequest )
        {

            if (cIUpdateRequest.DefaultCI)
            {

                var ciDefault = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Active && x.DefaultCI == true && x.Id != cIUpdateRequest.Id)).FirstOrDefault();
                if (ciDefault != null)
                    _lNotifications.Add(new Notification { Message = $" Atenção CI Default está setado para outro CI {ciDefault.CIId} " });

                return new CIUpdateResponse();
            }


            var ciCallExists = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.CIId == cIUpdateRequest.CIId
                                                                        && x.CallGroup == cIUpdateRequest.CallGroup
                                                                        && x.CIName == cIUpdateRequest.CIName
                                                                        && x.Id != cIUpdateRequest.Id
                                                                        )).FirstOrDefault();

            if (ciCallExists != null)
            {

                _lNotifications.Add(new Notification { Message = $" Atenção CI {ciCallExists.CIId} já existe para a combinação CIId {cIUpdateRequest.CIId} CIName ${cIUpdateRequest.CIName} e CallGroup ${cIUpdateRequest.CallGroup} no status ${ciCallExists.Active}. " });
                return new CIUpdateResponse();
            }




            var ciUpdate = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Id == cIUpdateRequest.Id)).FirstOrDefault();
            SetUpdateEntity(ciUpdate);
            ciUpdate.CIId = cIUpdateRequest.CIId;
            ciUpdate.CIName = cIUpdateRequest.CIName;
            ciUpdate.CallGroup = cIUpdateRequest.CallGroup;
            ciUpdate.DefaultCI = cIUpdateRequest.DefaultCI;

            return _mapper.Map<CIUpdateResponse>(ciUpdate);

        }

        public async Task<CIDeleteResponse> CIDeleteAsync(Guid id)
        {
            var ciDelete = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Id == id)).FirstOrDefault();
            if (ciDelete.Active)
                SetDeleteEntity(ciDelete);
            else
                SetUpdateEntity(ciDelete);
            return new CIDeleteResponse();
        }
    }
}
