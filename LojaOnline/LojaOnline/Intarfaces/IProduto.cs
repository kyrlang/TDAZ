using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaOnline.Models;

namespace LojaOnline.Intarfaces
{
    public interface IProduto
    {
        IList<Produtos> Listar();

        IList<Produtos> ListarProdutoCategoria(int idCategoria);

        Produtos ListarProdutoId(int idProduto);
    }
}
