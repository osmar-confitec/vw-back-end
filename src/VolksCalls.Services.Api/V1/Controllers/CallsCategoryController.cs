using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Models.CallsCategory.Request;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Services.Api.Controllers;
using VolksCalls.Services.Api.Filters;

namespace VolksCalls.Services.Api.V1.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/callscategory")]
    [Authorize]
    public class CallsCategoryController : MainController
    {
        readonly ICallsCategoryApplication _callsCategoryApplication;

        readonly ICallCategoriesListApplication _callCategoriesListApplication;

        readonly ICIApplication _cIApplication;
        public CallsCategoryController(ICallsCategoryApplication callsCategoryApplication,
                                        ICIApplication cIApplication,
                                        ICallCategoriesListApplication callCategoriesListApplication, 
                                       LNotifications notifications,
                                       ILogger<CallsCategoryController> logger
                                       )
            : base(logger,notifications)
        {
            _cIApplication = cIApplication;
            _callsCategoryApplication = callsCategoryApplication;
            _callCategoriesListApplication = callCategoriesListApplication;
        }


        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpGet("LoadCategoriesList")]
       // [AllowAnonymous]
        public async Task<IActionResult> LoadCategoriesListAsync() => 
            await ExecControllerAsync(()=> _callCategoriesListApplication.LoadCallCategoriesListAsync());

        [HttpGet("LoadQtdChildren")]
        [AllowAnonymous]
        public async Task<IActionResult> LoadQtdChildrenAsync() =>
           await ExecControllerAsync(() => _callsCategoryApplication.LoadQtdChildrenAsync());

        //
        
        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpGet("GetCallCategories")]
      //  [AllowAnonymous]
        public async Task<IActionResult> GetCallCategoriesAsync([FromQuery] CallsCategoryGetRequest callsCategoryGetRequest) =>
            await ExecControllerAsync(() => _callsCategoryApplication.GetCallCategoriesAsync(callsCategoryGetRequest));

        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpGet("GetCallsCategoryManage")]
        public async Task<IActionResult> GetCallsCategoryManageAsync([FromQuery] Guid Id) =>
            await ExecControllerAsync(() => _callsCategoryApplication.GetCallsCategoryManageAsync(Id));

        //GetCallsCategoryManageAsync
        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpGet("")]
        public async Task<IActionResult> GetCallsCategoriesExcel() => await ExecControllerAsync(_callsCategoryApplication.GetCallCategoriesExcelAsync);

        [HttpGet("CallCategoriesFromText")]
        public async Task<IActionResult> GetCallCategoriesFromTextAsync([FromQuery]string txtSearch) => await ExecControllerAsync(() => _callsCategoryApplication.GetCallCategoriesFromTextAsync(txtSearch));

        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpGet("CallsCategoryAsync")]
        public async Task<IActionResult> GetCallsCategoryAsync([FromQuery]CallsCategoryGetRequest callsCategoryGetRequest) 
            => await ExecControllerAsync(()=> _callsCategoryApplication.GetCallsCategoryAsync(callsCategoryGetRequest));

        [HttpGet("CallCategoriesParents")]
        
        public async Task<IActionResult> GetCallCategoriesParentsAsync() => await ExecControllerAsync(() => _callsCategoryApplication.GetCallCategoriesParentsAsync());

        //[AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpGet("LoadOfTicketCategories")]
        [AllowAnonymous]
        public async Task<IActionResult> LoadOfTicketCategoriesAsync() => await ExecControllerAsync(()=> _callsCategoryApplication.LoadOfTicketCategoriesNewAsync());

        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpGet("LoadCI")]
        [AllowAnonymous]
        public async Task<IActionResult> LoadCIAsync() => await ExecControllerAsync(() => _cIApplication.LoadCIAsync());


       
        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpGet("LoadGeneralSupportGroup")]
        public async Task<IActionResult> LoadGeneralSupportGroupAsync() => await ExecControllerAsync(() => _cIApplication.LoadGeneralSupportGroupAsync());

        [HttpPost("CallCategoriesChildrenNodes")]
        public async Task<IActionResult> GetCallCategoriesChildrenNodesAsync([FromBody] CallCategoriesChildrenNodesRequest callCategoriesChildrenNodesRequest) => await ExecControllerAsync(() => _callsCategoryApplication.GetCallCategoriesChildrenNodesAsync(callCategoriesChildrenNodesRequest));

        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpDelete("CallCategoryDelete")]
        public async Task<IActionResult> CallCategoryDeleteAsync([FromQuery]Guid id) => await ExecControllerAsync(() => _callsCategoryApplication.CallCategoryDeleteAsync(id));

        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpPost("CallCategoryInsert")]
        public async Task<IActionResult> CallCategoryInsertAsync([FromBody] CallCategoryInsertRequest callCategoryInsertRequest)

        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(callCategoryInsertRequest);
            }

            return await ExecControllerAsync(() => _callsCategoryApplication.CallCategoryInsertAsync(callCategoryInsertRequest));

        }

        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        [HttpPut("CallCategoryUpdate")]
        public async Task<IActionResult> CallCategoryUpdateAsync([FromBody] CallCategoryUpdateRequest  callCategoryUpdateRequest)

        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(callCategoryUpdateRequest);
            }
            return await ExecControllerAsync(() => _callsCategoryApplication.CallCategoryUpdateAsync(callCategoryUpdateRequest));
        }

    }
}
