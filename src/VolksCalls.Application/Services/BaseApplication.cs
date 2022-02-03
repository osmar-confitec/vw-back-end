using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Application.Services
{
    public class BaseApplication : IBaseApplication
    {

        protected BaseApplication(IUnitOfWork _unitOfWork,
                                  LNotifications _LNotifications)
        {

            if (LNotifications == null)
                LNotifications = new LNotifications();

            unitOfWork = _unitOfWork;

            LNotifications = _LNotifications;
        }

        public void ValidAnnotation<T>(T obj) where T:class
        {
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var validContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            if (!System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, validContext, results, true))
            {

                foreach (var errors in results)
                {
                    LNotifications.Add(new Notification { Message = errors.ErrorMessage });
                }
            }

        }

        public IUnitOfWork unitOfWork { get; protected set; }

        public LNotifications LNotifications { get; protected set; }

        public void Dispose() => GC.SuppressFinalize(this);




    }
}
