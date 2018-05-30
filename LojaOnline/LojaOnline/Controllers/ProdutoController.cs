using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaOnline.DAO;
using LojaOnline.Models;

namespace LojaOnline.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProdutoCategoria(int categoriaId)
        {
            ProdutoDAO produto = new ProdutoDAO();
            IList<Produtos> prod = produto.ListarProdutoCategoria(categoriaId);
            ViewBag.Categoria = prod[0].Categoria.Nome;
            ViewBag.Produtos = prod;
            return View();
        }
    }
}