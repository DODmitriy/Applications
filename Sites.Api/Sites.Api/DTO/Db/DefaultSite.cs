using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sites.Api.DTO.Db
{
    public class DefaultSite
    {
        [Key]
        public Guid site_id { get; set; }
        public int page_number { get; set; }
        public string page_content { get; set; }
    }
}
