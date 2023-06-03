namespace DesafioTecnicoSecSaude.Usuarios.Model
{
    public class Contato
    {
        public virtual int Id { get; set; }
        public virtual int UsuarioId { get; set; }
        public virtual int TipoContatoId { get; set; }
        public virtual string Descricao { get; set; }
    }
}