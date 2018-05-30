using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaOnline.Models;

namespace LojaOnline.Intarfaces
{
    public interface IUsuario
    {
        void Inserir(Usuarios usuario);
        Usuarios ListarUsuario(string email, string senha);
        void VerificarEmail(string email);
    }
}
