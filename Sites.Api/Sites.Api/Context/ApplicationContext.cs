using Microsoft.EntityFrameworkCore;
using Sites.Api.DTO.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sites.Api.Context
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public DbSet<DefaultSite> default_siteBase { get; set;}
    }
}
