using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Application.Services
{
    public class CallCategoriesListApplication : BaseApplication, ICallCategoriesListApplication
    {

        readonly ICallCategoriesListServices _callCategoriesListServices;
        public CallCategoriesListApplication(IUnitOfWork _unitOfWork,
            ICallCategoriesListServices callCategoriesListServices, 
            LNotifications _LNotifications) 
            : base(_unitOfWork, _LNotifications)
        {
            _callCategoriesListServices = callCategoriesListServices;
        }

        public async Task LoadCallCategoriesListAsync()
        {
            await _callCategoriesListServices.LoadCallCategoriesListAsync();
            await unitOfWork.CommitAsync();

        }
         
    }
}
