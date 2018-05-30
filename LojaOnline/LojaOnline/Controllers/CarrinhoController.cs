using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaOnline.DAO;
using LojaOnline.Geral;
using LojaOnline.Models;

namespace LojaOnline.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        public ActionResult Index()
        {
            if (Session["ItensPedido"] != null)
                return View(Session["ItensPedido"]);
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult AdicionarItem(int produtoId)
        {
            IList<ItensCarrinho> itensCarrinho = new List<ItensCarrinho>();
            ProdutoDAO produto = new ProdutoDAO();
            Produtos prod = new Produtos();

            if (Session["ItensPedido"] != null)
            {
                bool controle = false;
                IList<ItensCarrinho> itensCarrinhoAux = (List<ItensCarrinho>)Session["ItensPedido"];
                foreach (var item in itensCarrinhoAux)
                {
                    if (produtoId == item.ProdutoId)
                    {
                        controle = true;
                        prod = produto.ListarProdutoId(produtoId);
                        itensCarrinho.Add(adicionarItem(item.Produto, produtoId, item.Quantidade + 1, item.UsuarioId, ((item.Quantidade + 1) * prod.Preco)));
                    }
                    else
                        itensCarrinho.Add(adicionarItem(item.Produto, item.ProdutoId, item.Quantidade, item.UsuarioId, item.Valor));
                }

                if (!controle)
                {
                    prod = produto.ListarProdutoId(produtoId);
                    itensCarrinho.Add(adicionarItem(prod.Nome, prod.Id, 1, 0, prod.Preco));
                }
            }
            else
            {
                prod = produto.ListarProdutoId(produtoId);
                itensCarrinho.Add(adicionarItem(prod.Nome, prod.Id, 1, 0, prod.Preco));
            }

            Session["ItensPedido"] = itensCarrinho;
            return View("Index", Session["ItensPedido"]);
        }

        public ActionResult RemoverItem(int produtoId)
        {
            IList<ItensCarrinho> itensCarrinho = new List<ItensCarrinho>();
            ProdutoDAO produto = new ProdutoDAO();
            Produtos prod = new Produtos();

            if (Session["ItensPedido"] != null)
            {
                IList<ItensCarrinho> itensCarrinhoAux = (List<ItensCarrinho>)Session["ItensPedido"];
                foreach (var item in itensCarrinhoAux)
                {
                    int quantidade = item.Quantidade - 1;

                    if (produtoId == item.ProdutoId)
                    {
                        if (quantidade == 0)
                            itensCarrinho.Remove(item);
                        else
                        {
                            prod = produto.ListarProdutoId(produtoId);
                            itensCarrinho.Add(adicionarItem(item.Produto, produtoId, quantidade, item.UsuarioId, (quantidade) * prod.Preco));
                        }
                    }
                    else
                        itensCarrinho.Add(item);

                }
            }

            if (itensCarrinho.Count == 0)
            {
                Session["ItensPedido"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
                Session["ItensPedido"] = itensCarrinho;

            return View("Index", Session["ItensPedido"]);
        }

        public ActionResult Finalizar()
        {
            if (Session["usuarioLogado"] == null)
                return RedirectToAction("Index", "Login");
            else
            {
                try
                {
                    Usuarios usuario = (Usuarios)Session["usuarioLogado"];
                    List<ItensCarrinho> itensCarrinho = (List<ItensCarrinho>)Session["ItensPedido"];
                    CarrinhoDAO carrinhoDAO = new CarrinhoDAO();
                    carrinhoDAO.Inserir(itensCarrinho, usuario.Id);
                    EnviarEmail();
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaegem = "Ocorreu um erro ao enviar o e-mail, e seu pedido não foi finalizado. Tente novamente.";
                    return View("_Erro");
                }
                
            }

            Session.Remove("ItensPedido");
            return View();
        }

        private ItensCarrinho adicionarItem(string produto, int produtoId, int quantidade, int usuarioId, double valor) {
            ItensCarrinho itensCarrinho = new ItensCarrinho();
            itensCarrinho.Produto = produto;
            itensCarrinho.ProdutoId = produtoId;
            itensCarrinho.Quantidade = quantidade;
            itensCarrinho.UsuarioId = usuarioId;
            itensCarrinho.Valor = valor;
            return itensCarrinho;
        }

        private void EnviarEmail() {

            EnviarEmail enviarEmail = new EnviarEmail();

            IList<ItensCarrinho> itensCarrinhoAux = (List<ItensCarrinho>)Session["ItensPedido"];
            string html = string.Empty;
            html = @"<htmll>
                        <head></head>
                        <title></title>
                        <body>
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th scope = ""col"">Produto</th>
                                <th scope = ""col"">Quantidade</th>
                                <th scope = ""col"">Valor</th>
                            </tr>
                        </thead>
                        <tbody>";

            string html2 = string.Empty;
            double valor = 0;
                

            foreach (var item in itensCarrinhoAux)
            {
                html2 = @"<tr>
                            <td>" + item.Produto + @"</td>" +
                           "<td>" + item.Quantidade + @" </td>" +
                           "<td>R$ " + item.Valor.ToString("N2") + @" </td>";

                valor = valor + item.Valor;
            }

            html = html + html2 + @"</tbody>
                                    </table>";
            html = html + @"<h2>O valor total do pedido é: R$ " + valor.ToString("N2") + @"</h2>" +
                                                                                @"</body>
                                                                            </html>";


            try
            {
                Usuarios usu = (Usuarios)Session["usuarioLogado"];
                string[] usuario = { usu.Email.ToString() };
                enviarEmail.Send(usuario, html);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}