using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LojaOnline.Models;

namespace LojaOnline.Context
{
    public class LojaOnlineContext : DbContext
    {

        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Carrinhos> Carrinho { get; set; }
        public DbSet<ProdutoCarrinho> ProdutoCarrinho { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Produtos>().HasRequired(p => p.Categoria);
            builder.Entity<Categorias>().HasRequired(c => c.Departamento);
            builder.Entity<ProdutoCarrinho>().HasKey(pc => new { pc.CarrinhoId, pc.ProdutoId });
        }

    }
}