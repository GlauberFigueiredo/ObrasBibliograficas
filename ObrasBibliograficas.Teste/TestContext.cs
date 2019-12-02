using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using ObrasBibliograficas.Servico.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace ObrasBibliograficas.Teste
{
    public class TestContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public TestContext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            string curDir = Directory.GetCurrentDirectory();
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}
