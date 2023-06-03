using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioTecnicoSecSaude.Usuarios.DTO
{
    public class ContatoDTO
    {
        public int TipoContatoId { get; set; }
        public int UsuarioId { get; set; }
        public string Descricao { get; set; }
    }
}