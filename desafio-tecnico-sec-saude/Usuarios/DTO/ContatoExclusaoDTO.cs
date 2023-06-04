using DesafioTecnicoSecSaude.Usuarios.Model;
using System.Collections.Generic;

namespace DesafioTecnicoSecSaude.Usuarios.DTO
{
    public class ContatoExclusaoDTO
    {
        private List<Contato> contatos;
        public ContatoExclusaoDTO()
        {
            contatos = new List<Contato>();
        }
    }
}
