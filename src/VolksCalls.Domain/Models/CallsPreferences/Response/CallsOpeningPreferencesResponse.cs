using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Calls.Request;

namespace VolksCalls.Domain.Models.CallsPreferences.Response
{
   public class CallsOpeningPreferencesResponse
    {

        public bool FindPreferences { get; set; }

        public string UserId { get; set; }
        public string Telephone { get; set; }
        public string CellPhone { get; set; }
        public int WorkSchedule { get; set; }
        public int Collaborator { get; set; }
        public int Locality { get; set; }
        public string Reference { get; set; }
        public int Ala { get; set; }
        public int Floor { get; set; }
        public int Side { get; set; }
        public string Column { get; set; }
        public string NameContact { get; set; }

        public string HostName { get; set; }

        public string PhoneContact { get; set; }

        public string EmailContact { get; set; }



    }
}
