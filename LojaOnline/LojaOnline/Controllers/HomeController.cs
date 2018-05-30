using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaOnline.DAO;
using LojaOnline.Geral;
using LojaOnline.Models;

namespace LojaOnline.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ProdutoDAO produto = new ProdutoDAO();
            IList<Produtos> prod = produto.Listar();
            IList<Produtos> newProd = new List<Produtos>();

            Random random = new Random();
            int numero = 0;

            for (int i = 0; i < 4; i++)
            {
                numero = random.Next(0, prod.Count);
                newProd.Add(prod[numero]);
            }

            ViewBag.Produtos = newProd;
            return View();

        }

        public ActionResult Contato()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult ConfigurarSMTP(FormCollection data)
        {

            if (data.Count > 0)
            {
                    EnviarEmail enviarEmail = new EnviarEmail();
                    enviarEmail.ConfigurarSmtp(data["from"].ToString(), data["smtp"].ToString(), data["senha"].ToString(), data["usuario"].ToString());
                    ViewBag.Mensaegem = "A configuração foi realizada com sucesso.";
                    return View("Mensagem");
            }
            else
            {
                data.Add("from", (ConfigurationManager.AppSettings["from"].ToString() == string.Empty) ? null : ConfigurationManager.AppSettings["from"].ToString());
                data.Add("smtp", (ConfigurationManager.AppSettings["smtp"].ToString() == string.Empty) ? null : ConfigurationManager.AppSettings["smtp"].ToString());
                data.Add("usuario", (ConfigurationManager.AppSettings["usuario"].ToString() == string.Empty) ? null : ConfigurationManager.AppSettings["usuario"].ToString());
                data.Add("senha", (ConfigurationManager.AppSettings["senha"].ToString() == string.Empty) ? null : ConfigurationManager.AppSettings["senha"].ToString());
                return View(data);
            }
        }
    }
}