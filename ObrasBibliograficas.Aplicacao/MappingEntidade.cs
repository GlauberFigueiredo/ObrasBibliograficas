using AutoMapper;
using ObrasBibliograficas.Aplicacao.DTO;
using ObrasBibliograficas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Aplicacao
{
    public class MappingEntidade : Profile
    {
        public MappingEntidade()
        {
            CreateMap<Autor, AutorDTO>();
            CreateMap<AutorDTO, Autor>();
        }
    }
}
