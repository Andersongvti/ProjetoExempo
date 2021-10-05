using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProjetoExemplo.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {   
            return View( );
        }
    }
}