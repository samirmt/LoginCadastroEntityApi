using CadastroUrlBackendMobile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UrlBackendMobile.Models;

namespace CadastroUrlBackendMobile.Controllers
{
    public class HomeController : Controller
    {
        static string usuario = ConfigurationManager.AppSettings["usuario"];
        static string senha = ConfigurationManager.AppSettings["senha"];
        _Database db = new _Database();

        [SessionCheck]
        public ActionResult Index()
        {
            List<UrlBackendMobileTable> url = db.urlBackendMobilesTable.ToList();
            return View(url);
        }

        [SessionCheck]
        public ActionResult About()
        {
            ViewBag.Message = "Sistema para cadastro de URL do backend para uso no Mobile";

            return View();
        }

        [SessionCheck]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "user, pass")] string user, string pass)
        {
            if (user.Equals(usuario) && pass.Equals(senha))
            {
                Cookie.Set("usuariologado", usuario);
                Session["usuario"] = usuario;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["mensagem"] = "usuário e/ou senha inválidos!";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Contents.RemoveAll();
            Cookie.Delete("usuariologado");
            return RedirectToAction("Login");
        }
    }
}