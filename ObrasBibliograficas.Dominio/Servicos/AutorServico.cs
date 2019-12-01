using ObrasBibliograficas.Dominio.Entidades;
using ObrasBibliograficas.Dominio.Interfaces.Repositorios;
using ObrasBibliograficas.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Dominio.Servicos
{
    public class AutorServico : ServicoBase<Autor>, IAutorServico
    {
        public AutorServico(IAutorRepositorio repositorio) : base(repositorio)
        {

        }
    }
}
