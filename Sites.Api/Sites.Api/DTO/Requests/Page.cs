using Sites.Api.DTO.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sites.Api.DTO.Requests
{
    public class Page
    {
        public int PageNumber { get; set; }
        public List<PageContent> Content { get; set; }

    }
}
