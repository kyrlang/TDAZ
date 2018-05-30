using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaOnline.Models
{
    public class Categorias
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int DepartamentoId { get; set; }
        public Departamentos Departamento { get; set; }

    }
}