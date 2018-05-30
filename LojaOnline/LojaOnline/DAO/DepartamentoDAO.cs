using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaOnline.Context;
using LojaOnline.Intarfaces;
using LojaOnline.Models;

namespace LojaOnline.DAO
{
    public class DepartamentoDAO : LojaOnlineContext, IDepartamento
    {
        public void Adicionar(Departamentos departamento)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Departamentos departamento)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int idDepartamento)
        {
            throw new NotImplementedException();
        }

        public IList<Departamentos> Listar()
        {
            IList<Departamentos> departamento = new List<Departamentos>();

            try
            {
                using (var contexto = new LojaOnlineContext())
                    departamento = contexto.Departamentos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return departamento;
        }

        public Departamentos ListarDepartamentoId(int idDepartamento)
        {
            throw new NotImplementedException();
        }
    }
}