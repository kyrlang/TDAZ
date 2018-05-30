using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaOnline.Models
{
    public class ProdutoCarrinho
    {
        public int ProdutoId { get; set; }
        public Produtos Produto { get; set; }
        public int CarrinhoId { get; set; }
        public Carrinhos Carrinho { get; set; }
        public int Quantidade { get; set; }
    }
}