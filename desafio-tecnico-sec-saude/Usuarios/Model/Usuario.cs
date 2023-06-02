using System;

namespace DesafioTecnicoSecSaude.Usuarios.Model
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string CPF { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual DateTime DataAtualizacao { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Telefones { get; set; }
        public virtual string Perfil { get; set; }
        public virtual string Endereco { get; set; }
    }
}