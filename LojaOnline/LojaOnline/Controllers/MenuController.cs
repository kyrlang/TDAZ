using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaOnline.DAO;
using LojaOnline.Models;

namespace LojaOnline.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            DepartamentoDAO departamento = new DepartamentoDAO();
            IList<Departamentos> dep = departamento.Listar();
            ViewBag.Departamentos = dep;
            CategoriaDAO categoria = new CategoriaDAO();
            IList<Categorias> cat = categoria.Listar();
            ViewBag.Categorias = cat;
            return View();
        }
    }
}