using ObrasBibliograficas.Dominio.Entidades;
using ObrasBibliograficas.Dominio.Interfaces.Repositorios;
using ObrasBibliograficas.Infraestrutura.Data.Contextos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Infraestrutura.Data.Repositorios
{
    public class AutorRepositorio : RepositorioBase<Autor>, IAutorRepositorio
    {
        public AutorRepositorio(Contexto contexto)
            : base(contexto)
        {
        }
    }
}
