using Microsoft.Extensions.DependencyInjection;
using ObrasBibliograficas.Aplicacao.Interfaces;
using ObrasBibliograficas.Aplicacao.Servicos;
using ObrasBibliograficas.Dominio.Interfaces.Repositorios;
using ObrasBibliograficas.Dominio.Interfaces.Servicos;
using ObrasBibliograficas.Dominio.Servicos;
using ObrasBibliograficas.Infraestrutura.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Infraestrutura.IoC
{
    public class InjetorDependencias
    {
        public static void Registrar(IServiceCollection svcCollection)
        {
            //Aplicação
            svcCollection.AddScoped(typeof(IBaseApp<,>), typeof(ServicoAppBase<,>));
            svcCollection.AddScoped<IAutorApp, AutorApp>();

            //Domínio
            svcCollection.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));
            svcCollection.AddScoped<IAutorServico, AutorServico>();

            //Repositorio
            svcCollection.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            svcCollection.AddScoped<IAutorRepositorio, AutorRepositorio>();
        }
    }
}
