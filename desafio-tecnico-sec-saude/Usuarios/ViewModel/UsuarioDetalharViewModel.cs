using DesafioTecnicoSecSaude.Usuarios.Model;
using System.Collections.Generic;

namespace DesafioTecnicoSecSaude.Usuarios.ViewModel
{
    public class UsuarioDetalharViewModel
    {
        public virtual Usuario Usuario { get; set; }
        public virtual IList<Contato> Contatos { get; set; }
    }
}
