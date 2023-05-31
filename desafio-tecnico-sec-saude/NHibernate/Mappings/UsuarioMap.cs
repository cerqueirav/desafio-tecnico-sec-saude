﻿using DesafioTecnicoSecSaude.Usuarios.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioTecnicoSecSaude.NHibernate.Mappings
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");
            Id(u => u.Id);
            Map(u => u.Nome);
            Map(u => u.CPF);
            Map(u => u.DataNascimento);
        }
    }
}