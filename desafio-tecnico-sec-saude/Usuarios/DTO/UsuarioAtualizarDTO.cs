using System.Collections.Generic;
using System;
using DesafioTecnicoSecSaude.Usuarios.Model;

namespace DesafioTecnicoSecSaude.Usuarios.DTO
{
    public class UsuarioAtualizarDTO
    {
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string CPF { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Perfil { get; set; }
        public virtual List<Contato> Contatos { get; set; }
        public virtual List<Contato> ContatosExcluidos { get; set; }
        public virtual EnderecoDTO Endereco { get; set; }

        public UsuarioAtualizarDTO(string nome, string email, string senha, string cpf, DateTime dataNascimento, string perfil, List<Contato> contatos, List<Contato> contatosExcluidos, EnderecoDTO endereco)
        {
            Nome = nome;
            Email = email;
            CPF = cpf.Replace(".", "").Replace("-", "");
            Perfil = perfil;
            DataNascimento = dataNascimento;
            Contatos = contatos;
            ContatosExcluidos = contatosExcluidos;
            Endereco = endereco;
        }

        public UsuarioAtualizarDTO() { }
    }
}
