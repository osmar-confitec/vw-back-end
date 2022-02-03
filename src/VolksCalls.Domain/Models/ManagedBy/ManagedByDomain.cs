using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.ManagedBy
{
  public  class ManagedByDomain : EntityDataBase
    {
        public string MachineName { get; set; }

        public string MachineType { get; set; }

        public string SerialNumber { get; set; }

        public string UserId { get; set; }

        public string Monitor1 { get; set; }

        public string Monitor1Model { get; set; }

        public string Monitor1Brand { get; set; }

        public string Monitor1SerialNumber { get; set; }

        public string Monitor2Brand { get; set; }

        public string Monitor2Model { get; set; }

        public string Monitor2SerialNumber { get; set; }

        public string Monitor3SerialNumber { get; set; }

        public string Monitor3Brand { get; set; }

        public string Monitor3Model { get; set; }

        public string Plant { get; set; }

        public string Wing { get; set; }

        public string Floor { get; set; }

        public string Column { get; set; }

        public string Extension { get; set; }

        public string Side { get; set; }

        public string Collective { get; set; }
        public string UO { get; set; }

    }
}
