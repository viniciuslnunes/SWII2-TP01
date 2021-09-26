using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading;
using tp01web;

namespace tp01web2
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();

            Author[] at = new Author[2];
            Author a = new Author("Autor1", "Autor1@Test", 'm');
            Author a1 = new Author("Autor2", "Autor2@Test", 'f');
            at.SetValue(a, 0);
            at.SetValue(a1, 1);
            Book b = new Book("Livro de Testes",at,2.00,0);
            Console.WriteLine(b.ToString());
            Console.WriteLine();
            Console.WriteLine(b.getAuthorNames());            

            Console.ReadKey();
        }
    }
}
