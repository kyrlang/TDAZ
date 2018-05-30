﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaOnline.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public byte[] Imagem { get; set; }
        public int CategoriaId { get; set; }
        public Categorias Categoria { get; set; }
    }
}