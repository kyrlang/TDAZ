using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaOnline.Models;

namespace LojaOnline.Intarfaces
{
    public interface ICategoria
    {
        IList<Categorias> Listar();
    }
}
