using CadastroUrlBackendMobile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CadastroUrlBackendMobile.Controllers
{
    [RoutePrefix("api/url")]
    public class urlController : ApiController
    {
        static string senha = ConfigurationManager.AppSettings["senha"];
        _Database db = new _Database();

        [HttpGet]
        [Route("PegarUrl")]
        public IHttpActionResult PegarUrl(string cnpj, string chave)
        {
            if(chave.Equals(senha)) {
                if (!string.IsNullOrEmpty(cnpj) && cnpj.Length == 14)
                {
                    var url = db.urlBackendMobilesTable.FirstOrDefault(x => x.CNPJ.Equals(cnpj));

                    if (url != null)
                    {
                        return Ok(url);
                    }
                    else
                    {
                        return Ok("erro");
                    }
                }
                else
                {
                    return Ok("erro");
                }
            }
            else
            {
                return Ok("erro");
            }
        }
    }
}
