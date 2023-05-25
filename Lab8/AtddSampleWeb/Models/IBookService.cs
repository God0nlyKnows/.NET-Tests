using System.Collections.Generic;
using AtddSampleWeb.Models.DataModels;

namespace AtddSampleWeb.Models
{
    public interface IBookService
    {
        void Add(BookViewMoel book);
        IEnumerable<Book> GetBooks(BookQueryViewModel bookQueryViewModel);
    }
}