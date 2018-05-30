using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaOnline.Models
{
    public class CategoriaModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int DapartamentoId { get; set; }
        public DepartamentoModel Departamento { get; set; }

    }
}