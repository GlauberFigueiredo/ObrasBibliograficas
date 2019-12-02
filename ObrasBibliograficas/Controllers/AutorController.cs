using ObrasBibliograficas.Aplicacao.DTO;
using ObrasBibliograficas.Aplicacao.Interfaces;
using ObrasBibliograficas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObrasBibliograficas.Servico.API.Controllers
{
    public class AutorController : ControllerBase<Autor, AutorDTO>
    {
        public AutorController(IAutorApp app) : base(app)
        {

        }
    }
}
