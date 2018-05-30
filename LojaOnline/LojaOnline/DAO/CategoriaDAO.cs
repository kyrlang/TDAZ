using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LojaOnline.Context;
using LojaOnline.Intarfaces;
using LojaOnline.Models;

namespace LojaOnline.DAO
{
    public class CategoriaDAO : LojaOnlineContext, ICategoria
    {
        public IList<Categorias> Listar()
        {
            IList<Categorias> categoria = new List<Categorias>();

            try
            {
                using (var context = new LojaOnlineContext())
                    categoria = context.Categorias
                        .Include(c => c.Departamento)
                        .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

            return categoria;
        }
    }
}