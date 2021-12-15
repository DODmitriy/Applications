using Microsoft.AspNetCore.Mvc;
using Sites.Api.Context;
using Sites.Api.DTO.Db;
using Sites.Api.DTO.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sites.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext Context;
        public HomeController(ApplicationContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPut("Test")]
        public IActionResult PutSite()
        {


            int i = 0;
            var test = new PageContent
            {
                Text = "TESTarr TEXT",
                Image = "TESTarr IMAGE",
                ImageStyle = "TESTarr IMAGE STYLE",
                TextStyle = "TESTarr TEXT STYLE"
            };

            var test2 = new PageContent
            {
                Text = "TEST2arr TEXT",
                Image = "TEST2arr IMAGE",
                ImageStyle = "TEST2arr IMAGE STYLE",
                TextStyle = "TEST2arr TEXT STYLE"
            };

            var qwe = new PageContent[] { test, test2 };


            string jsonString = JsonSerializer.Serialize(qwe);
         //   string jsonString2 = JsonSerializer.Serialize(test2);

            Context.default_siteBase.Add(new DefaultSite
            {
                site_id = new Guid("ee9b3c8b-dc0f-45f2-b3c6-f16b7c40b707"),
                page_number = 1,
                page_content =  jsonString 
            });
            Context.SaveChanges();
            return Ok();
        }


    }
}
