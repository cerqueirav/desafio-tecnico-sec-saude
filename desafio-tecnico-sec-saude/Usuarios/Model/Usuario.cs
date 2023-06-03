using System;
using System.Collections.Generic;

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
        public virtual DateTime? DataAtualizacao { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Perfil { get; set; }
        public virtual string CEP { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Pais { get; set; }
        public virtual IList<Contato> Contatos { get; set; }
    }
}