using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Calls.Request;

namespace VolksCalls.Domain.Models.CallsPreferences
{
  public  class CallCategoryDomain : EntityDataBase
    {
        public string UserId { get; set; }
        public string Telephone { get; set; }
        public string HostName { get; set; }
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




    }
}
