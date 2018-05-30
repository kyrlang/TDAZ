using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaOnline.Models;

namespace LojaOnline.Intarfaces
{
    public interface IDepartamento
    {
        void Adicionar(Departamentos departamento);
        void Atualizar(Departamentos departamento);
        void Excluir(int idDepartamento);
        IList<Departamentos> Listar();
        Departamentos ListarDepartamentoId(int idDepartamento);
    }
}
