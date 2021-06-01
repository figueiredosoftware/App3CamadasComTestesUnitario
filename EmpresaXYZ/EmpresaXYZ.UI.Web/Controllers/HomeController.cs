using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpresaXYZ.BLL;

namespace EmpresaXYZ.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Clientes()
        {
            var bll = new ClienteBLL();
            var lista = bll.Listagem();
            return View(lista);
        }


    }
}