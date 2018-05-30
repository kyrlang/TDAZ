using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaOnline.Models
{
    public class ItensCarrinho
    {
        public int CarrinhoId;
        public int ProdutoId;
        public int UsuarioId;
        public int Quantidade;
        public string Produto;
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public double Valor;
    }
}