using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CadastroUrlBackendMobile.Models
{
    public class _Database : DbContext
    {
        public _Database() : base("MEUBD")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<UrlBackendMobileTable> urlBackendMobilesTable { get; set; }
    }
}