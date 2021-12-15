using Sites.Api.Context;
using Sites.Api.DTO.Db;
using Sites.Api.DTO.JsonModels;
using Sites.Api.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sites.Api.Services
{
    public class SiteOperationService
    {
        private readonly ApplicationContext Context;
        public SiteOperationService(ApplicationContext context)
        {
            Context = context;
        }

        public void CreateDefaultSite(Page request)
        {
            if (request.Content != null)
                throw new Exception("Невозможно создать страницу без контента");

            Context.default_siteBase.Add(new DefaultSite
            {
                page_number = request.PageNumber,
                page_content = JsonSerializer.Serialize(request.Content)
            });
            Context.SaveChanges();
        }

        public void AddPageToSite(Guid siteId, Page request)
        {
            Context.default_siteBase.Add(new DefaultSite
            {
                site_id = siteId,
                page_number = request.PageNumber,
                page_content = JsonSerializer.Serialize(request.Content)
            });
            Context.SaveChanges();
        }

        public List<Page> GetDefaultSite(Guid siteId)
        {
            var pages = Context.default_siteBase.Where(x => x.site_id == siteId)?.ToList();
            if (pages == null)
                return null;
            List<Page> result = new List<Page>();
            pages.ForEach(page =>
            {
                result.Add(new Page
                {
                    PageNumber = page.page_number,
                    Content = JsonSerializer.Deserialize<List<PageContent>>(page.page_content)
                });
            });

            return result;
        }

        public void RemoveSite()
        {
            throw new Exception("NO!!!!");
        }

      

    }
}
