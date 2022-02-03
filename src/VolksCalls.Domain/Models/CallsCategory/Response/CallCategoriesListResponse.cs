using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallsCategory.Dto;

namespace VolksCalls.Domain.Models.CallsCategory.Response
{
    public class CallCategoriesListResponse
    {
        public string DescriptionFirst { get; set; }

        public Guid IdFirst { get; set; }

        public string DescriptionSecond { get; set; }

        public Guid IdSecond { get; set; }

        public string DescriptionThird { get; set; }

        public Guid IdThird { get; set; }

        public string DescriptionFour { get; set; }

        public Guid IdFour { get; set; }


        public string CIId { get; set; }

        public string CIName { get; set; }

        public string CallGroup { get; set; }

    }
}
