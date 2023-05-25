using AtddSampleWeb.Models.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace AtddSampleWeb.Models
{
    public class BookService : IBookService
    {
        public void Add(BookViewMoel model)
        {
            using (var dbcontext = new BookEntities())
            {
                var book = new Book { ISBN = model.ISBN, Name = model.Name };
                dbcontext.Books.Add(book);

                dbcontext.SaveChanges();
            }
        }

        public IEnumerable<Book> GetBooks(BookQueryViewModel bookQueryViewModel)
        {
            using (var dbcontext = new BookEntities())
            {
                var books = dbcontext.Books
                    .Where(x => x.Name == bookQueryViewModel.Name)
                    .ToList();

                return books;
            }
        }
    }
}