using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Infra.CrossCutting
{
    public abstract class PagedDataRequest
    {

        public int Page { get; set; }

        public int Limit { get; set; }

        public PagedDataRequest()
        {
            Page = 1;
            Limit = 30;
              
        }

    }
}
