using Microsoft.AspNetCore.Mvc;
using Sites.Api.DTO.Requests;
using Sites.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sites.Api.Controllers
{
    /// <summary>
    /// Сваггер не видит из за отсутствия роутов.
    /// </summary>
    public class SiteController : Controller
    {
        private readonly SiteOperationService SiteOperations;
        public SiteController(SiteOperationService siteOperations)
        {
            SiteOperations = siteOperations;
        }

        [HttpPut("qwe")]
        public IActionResult PutSite(Page request)
        {
            SiteOperations.CreateDefaultSite(request);
            return Ok();
        }
        [HttpPut]
        public IActionResult PutPage(Guid siteId,Page request)
        {
            SiteOperations.AddPageToSite(siteId, request);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetSite(Guid siteId)
        {
            return Ok(SiteOperations.GetDefaultSite(siteId));
        }
    }
}
