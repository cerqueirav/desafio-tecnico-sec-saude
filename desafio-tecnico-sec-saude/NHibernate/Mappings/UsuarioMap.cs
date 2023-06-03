using DesafioTecnicoSecSaude.Usuarios.Model;
using FluentNHibernate.Mapping;

namespace DesafioTecnicoSecSaude.NHibernate.Mappings
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");
            Id(u => u.Id);
            Map(u => u.Nome);
            Map(u => u.Email);
            Map(u => u.Senha);
            Map(u => u.CPF);
            Map(u => u.DataNascimento);
            Map(u => u.Perfil);
            Map(u => u.CEP);
            Map(u => u.Logradouro);
            Map(u => u.Complemento);
            Map(u => u.Numero);
            Map(u => u.Cidade);
            Map(u => u.Estado);
            Map(u => u.Pais);
            Map(u => u.DataCriacao);   
            Map(u => u.DataAtualizacao);

            HasMany(u => u.Contatos)
                .KeyColumn("UsuarioId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}