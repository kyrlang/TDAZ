using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LojaOnline.Context;
using LojaOnline.Intarfaces;
using LojaOnline.Models;

namespace LojaOnline.DAO
{
    public class ProdutoDAO : LojaOnlineContext, IProduto
    {
        public IList<Produtos> Listar()
        {
            IList<Produtos> produto = new List<Produtos>();
            
            try
            {
                using (var context = new LojaOnlineContext())
                {
                    produto = context.Produtos.Include(p => p.Categoria).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return produto;
        }

        public IList<Produtos> ListarProdutoCategoria(int idCategoria)
        {
            IList<Produtos> produto = new List<Produtos>();

            try
            {
                using (var context = new LojaOnlineContext())
                {
                    produto = context
                        .Produtos
                        .Include(c => c.Categoria)
                        .Where(c => c.CategoriaId == idCategoria)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return produto;
        }

        public Produtos ListarProdutoId(int idProduto)
        {
            Produtos produto = new Produtos();

            try
            {
                using (var context = new LojaOnlineContext())
                {
                    produto = context
                        .Produtos
                        .Include(p => p.Categoria)
                        .Where(p => p.Id == idProduto)
                        .First();
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return produto;
        }
    }
}