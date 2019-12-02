using Microsoft.AspNetCore.Mvc;
using ObrasBibliograficas.Aplicacao.DTO;
using ObrasBibliograficas.Aplicacao.Interfaces;
using ObrasBibliograficas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObrasBibliograficas.Servico.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase<Autor, AutorDTO>
    {
        public AutorController(IAutorApp app) : base(app)
        { }

        [HttpGet]
        [Route("")]
        public IActionResult ListarFormatado()
        {
            try
            {
                var autores = app.SelecionarTodos();
                if (autores.Count() > 0)
                {
                    foreach (var autor in autores)
                    {
                        if (!string.IsNullOrEmpty(autor.Nome))
                        {
                            autor.Nome = autor.Nome.FormataNome();
                        }
                    }
                }
                return new OkObjectResult(autores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
