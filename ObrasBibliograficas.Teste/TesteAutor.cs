using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using ObrasBibliograficas.Aplicacao.DTO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace ObrasBibliograficas.Teste
{
    [TestClass]
    public class TesteAutor
    {
        private readonly TestContext _testContext;

        public TesteAutor()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task AuthorsGetAll_ReturnOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/Author/");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAuthor_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/Autor?id=1");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAuthor_ReturnsBadRequestResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/Autor?id=-1");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetAuthor_CorrectContentType()
        {
            var response = await _testContext.Client.GetAsync("/api/Autor?id=2");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Fact]
        public async Task CreateOrEditAuthor_ReturnsOkRequestResponse()
        {
            var param = new AutorDTO { Id = 0, Nome = "Glauber Figueiredo" };
            var content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/api/Autor/CreateOrEdit", content);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
