using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tp01web2
{
    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("/nomeLivro",BookNames);
            builder.MapRoute("/TotalToString",TotalToString);
            builder.MapRoute("/NomeDosAutores",NomeDosAutores);
            builder.MapRoute("/livro/ApresentaLivro", GerarHtml);
            var rotas = builder.Build();
            app.UseRouter(rotas);
        }
        public Task BookNames(HttpContext context)
        {
            ArquivoCSV arq = new ArquivoCSV();
            var books = arq.buscarNomes();
            return context.Response.WriteAsync(books[0].Name);
        }
        public Task TotalToString (HttpContext context)
        {
            ArquivoCSV arq = new ArquivoCSV();
            var books = arq.buscarNomes();
            return context.Response.WriteAsync(books[0].ToString());

        }
        public Task NomeDosAutores(HttpContext context)
        {
            ArquivoCSV arq = new ArquivoCSV();
            var books = arq.buscarNomes();
            return context.Response.WriteAsync(books[0].getAuthorNames());

        }
        public Task GerarHtml(HttpContext context)
        {
            ArquivoCSV arq = new ArquivoCSV();
            var books = arq.buscarNomes();
            var pHtml = $"<div><h1>Nome do Livro: </h1><p>{books[0].Name}</p><h2>Autor(es)</h2><p>{books[0].getAuthorNames()}</p></div>";
            return context.Response.WriteAsync(pHtml);
        }
       
        
    }
}
