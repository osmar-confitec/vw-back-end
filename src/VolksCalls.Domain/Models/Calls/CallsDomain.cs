using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Archive;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.Calls.Request;

namespace VolksCalls.Domain.Models.Calls
{



    public enum StatusCalls
    {

        EmailSent = 1

    }

   public class CallsDomain: EntityDataBase
    {

        public string Email { get; set; }

        public bool Vip { get; set; }

        public StatusCalls StatusCalls { get; set; }

        public string HostName { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }

        public string UserId { get; set; }

        public string Plate { get; set; }

        public string CellPhone { get; set; }

        public WorkSchedule WorkSchedule { get; set; }

        public CollaboratorOf Collaborator { get; set; }

        public Locality Locality { get; set; }

        public string Reference { get; set; }

        public Ala Ala { get; set; }

        public Floor Floor { get; set; }

        public Side Side { get; set; }

        public string Column { get; set; }

        public string NameContact { get; set; }

        public string PhoneContact { get; set; }

        public string EmailContact { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid CallsCategoryId { get; set; }

        public virtual CallsCategoryDomain CallsCategory { get; set; }

        public Guid? CallFormId { get; set; }

        public virtual CallFormDomain CallForm { get; set; }
        public virtual List<ArchiveDomain> Archives { get; set; }
        public string CIName { get; set; }

        public string CIId { get; set; }

        public string CIQuee { get; set; }

        public CallsDomain()
        {
            Archives = new List<ArchiveDomain>();
            StatusCalls = StatusCalls.EmailSent;
        }
    }
}
