using System;

namespace DesafioTecnicoSecSaude.Usuarios.DTO
{
    public class UsuarioDTO
    {
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string CPF { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Telefones { get; set; }
        public virtual string Perfil { get; set; }
        public virtual string Endereco { get; set; }


        public UsuarioDTO(string nome, string email, string senha, string cpf, DateTime dataNascimento, string telefone, string perfil, string endereco)
        {
            Nome = nome;
            Email = email;
            CPF = cpf.Replace(".", "").Replace("-", "");
            Senha = senha;
            Perfil = perfil;
            DataNascimento = dataNascimento;
            Telefones = telefone.Replace("(", "").Replace(")", "").Replace("-", "");
            Endereco = endereco;
        }

        public UsuarioDTO() { }
    }
}