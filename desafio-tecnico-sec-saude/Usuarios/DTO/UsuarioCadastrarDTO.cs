using System;
using System.Collections.Generic;

namespace DesafioTecnicoSecSaude.Usuarios.DTO
{
    public class UsuarioCadastrarDTO
    {
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string CPF { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Perfil { get; set; }
        public virtual List<ContatoDTO> Contatos { get; set; }
        public virtual EnderecoDTO Endereco { get; set; }

        public UsuarioCadastrarDTO(string nome, string email, string senha, string cpf, DateTime dataNascimento, string perfil, List<ContatoDTO> contatos, EnderecoDTO endereco)
        {
            Nome = nome;
            Email = email;
            CPF = cpf.Replace(".", "").Replace("-", "");
            Senha = senha;
            Perfil = perfil;
            DataNascimento = dataNascimento;
            Contatos = contatos;
            Endereco = endereco;
        }

        public UsuarioCadastrarDTO() { }
    }
}