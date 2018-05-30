using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaOnline.Models
{
    public class Carrinhos
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Aberto, Fechado
    }
}