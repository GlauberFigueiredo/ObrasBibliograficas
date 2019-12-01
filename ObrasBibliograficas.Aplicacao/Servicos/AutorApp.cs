using AutoMapper;
using ObrasBibliograficas.Aplicacao.DTO;
using ObrasBibliograficas.Aplicacao.Interfaces;
using ObrasBibliograficas.Dominio.Entidades;
using ObrasBibliograficas.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Aplicacao.Servicos
{
    public class AutorApp : ServicoAppBase<Autor, AutorDTO>, IAutorApp
    {
        public AutorApp(IMapper iMapper, IAutorServico servico) : base(iMapper, servico)
        {

        }
    }
}
