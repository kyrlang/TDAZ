using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaOnline.DAO;
using LojaOnline.Models;

namespace LojaOnline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar(Usuarios usu)
        {
            try
            {
                if (usu != null) {
                    UsuarioDAO usuario = new UsuarioDAO();
                    usuario.VerificarEmail(usu.Email);
                    usuario.Inserir(usu);

                    Session["usuarioLogado"] = usu;
                    Session["email"] = usu.Email;
                }
            }
            catch (EmailCadastradoException ex)
            {
                Session.RemoveAll();
                Session.Clear();
                ViewBag.Mensagem = ex.Message;
                return View("Erro");
            }
            catch (Exception ex)
            {
                Session.RemoveAll();
                Session.Clear();
                ViewBag.Mensagem = ex.Message;
                return View("Erro");
            }

            return View();
        }

        public ActionResult Login (Usuarios usu)
        {
            try
            {
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                Usuarios usuario = new Usuarios();
                usuario = usuarioDAO.ListarUsuario(usu.Email, usu.Senha);
                if (usuario != null)
                {
                    Session["usuarioLogado"] = usuario;
                    Session["email"] = usuario.Email;
                }
                else
                    return View("Index");
            }
            catch (Exception)
            {
                throw;
            }

            if (Session["ItensPedido"] != null)
                return RedirectToAction("Index", "Carrinho");
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}