using DesafioTecnicoSecSaude.Usuarios.Model;
using FluentNHibernate.Mapping;

namespace DesafioTecnicoSecSaude.NHibernate.Mappings
{
    public class ContatoMap : ClassMap<Contato>
    {
        public ContatoMap()
        {
            Table("Contato");
            Id(c => c.Id);
            Map(c => c.UsuarioId);
            Map(c => c.TipoContatoId);
            Map(c => c.Descricao);  
        }
    }
}