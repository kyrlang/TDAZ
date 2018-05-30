using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LojaOnline.Context;
using LojaOnline.Intarfaces;
using LojaOnline.Models;

namespace LojaOnline.DAO
{
    public class UsuarioDAO : LojaOnlineContext, IUsuario
    {
        public void Inserir(Usuarios usuario)
        {
            try
            {
                using (var context = new LojaOnlineContext())
                {
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public Usuarios ListarUsuario(string email, string senha)
        {
            Usuarios usuario = new Usuarios();

            try
            {
                using (var context = new LojaOnlineContext())
                    usuario = context.Usuarios.Where(u => u.Email == email && u.Senha == senha).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return usuario;
        }

        public void VerificarEmail(string email)
        {
            try
            {
                using (var context = new LojaOnlineContext())
                {
                    var usu = context.Usuarios.Where(u => u.Email == email).FirstOrDefault();
                    if (usu != null)
                        throw new EmailCadastradoException("Já existe um cadastro com o e-mail informado"); 
                }
            }
            catch (EmailCadastradoException ex)
            {
                throw new EmailCadastradoException(ex.Message);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}