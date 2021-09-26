using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using tp01web;

namespace tp01web2
{
    class ArquivoCSV
    {
        private static readonly string nomeArquivoCSV = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Autor.csv";
        
        public ArquivoCSV()
        {

        }

        public List<Book> buscarNomes()
        {
            using (var file = File.OpenText(ArquivoCSV.nomeArquivoCSV))
            {
                var lBooks = new List<Book>();
                List<Author> list = new List<Author>();           

                while (!file.EndOfStream)
                {
                    var textBook = file.ReadLine();

                    if (string.IsNullOrEmpty(textBook))
                    {
                        continue;
                    }
                    var infoBook = textBook.Split(';');

                    var firstAuthor = new Author();
                    firstAuthor.Name = infoBook[1];
                    list.Add(firstAuthor);


                    if (infoBook.Length == 6)
                    {
                        var secondAuthor = new Author();
                        firstAuthor.Name = infoBook[5];
                        list.Add(secondAuthor);
                    }
                    
                    var book = new Book(infoBook[0], list.ToArray(), double.Parse(infoBook[2]), int.Parse(infoBook[3]));

                    

                    lBooks.Add(book);
                
                }
                return lBooks;
            }
        }
        
    }

}
