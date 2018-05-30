using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using LojaOnline.Context;
using LojaOnline.Intarfaces;
using LojaOnline.Models;

namespace LojaOnline.DAO
{
    public class CarrinhoDAO : LojaOnlineContext, ICarrinho
    {
        public void Inserir(IList<ItensCarrinho> itensCarrinho, int usuarioId)
        {
            try
            {
                using (var context = new LojaOnlineContext())
                {
                    double total = 0;
                    Carrinhos carrinho = new Carrinhos();
                    carrinho.Status = Status.Fechado;
                    carrinho.UsuarioId = usuarioId;
                    carrinho.Total = total;
                    context.Carrinho.Add(carrinho);
                    context.SaveChanges();

                    foreach (var item in itensCarrinho)
                    {
                        ProdutoCarrinho produtoCarrinho = new ProdutoCarrinho();
                        produtoCarrinho.Carrinho = carrinho;
                        produtoCarrinho.ProdutoId = item.ProdutoId;
                        produtoCarrinho.Quantidade = item.Quantidade;
                        context.ProdutoCarrinho.Add(produtoCarrinho);
                        context.SaveChanges();
                        total = total + item.Valor;
                    }

                    carrinho.Total = total;
                    context.Carrinho.AddOrUpdate(carrinho);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}