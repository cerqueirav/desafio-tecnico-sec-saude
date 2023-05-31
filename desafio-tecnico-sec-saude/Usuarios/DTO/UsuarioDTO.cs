namespace DesafioTecnicoSecSaude.Usuarios.DTO
{
    public class UsuarioDTO
    {
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string CPF { get; set; }
        public virtual string DataNascimento { get; set; }
        public virtual string Telefones { get; set; }
        public virtual string Perfil { get; set; }
        public virtual string Endereco { get; set; }
    }
}