using System.Collections.Generic;
using System.Web.Mvc;
using AtddSampleWeb.Models;
using AtddSampleWeb.Models.DataModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AtddSampleWeb.Controllers.Tests
{
    [TestClass()]
    public class BookControllerTests
    {
        private IBookService bookServiceStub = Substitute.For<IBookService>();

        [TestMethod()]
        public void CreateTest_should_invoke_IBookService_Add_one_time()
        {
            var bookController = new BookController(bookServiceStub);

            var book = new BookViewMoel() { ISBN = "9789869094481", Name = "玩出好創意" };
            var result = bookController.Create(book);

            bookServiceStub.Received().Add(Arg.Is<BookViewMoel>
                (x => x.ISBN == book.ISBN && x.Name == book.Name));
        }

        [TestMethod()]
        public void QueryTest()
        {
            var bookController = new BookController(bookServiceStub);

            bookServiceStub.GetBooks(new BookQueryViewModel())
                .ReturnsForAnyArgs(new List<Book>
                {
                    new Book {ISBN = "9789869094481", Name = "玩出好創意"},
                    new Book {ISBN = "9789869094481", Name = "玩出好創意"},
                });

            var result = bookController.Query(new BookQueryViewModel()) as ViewResult;

            var model = result.ViewData.Model as BookQueryViewModel;

            Assert.IsNotNull(model);

            var expected = new List<BookViewMoel>
            {
                new BookViewMoel() {ISBN = "9789869094481", Name = "玩出好創意"},
                new BookViewMoel() {ISBN = "9789869094481", Name = "玩出好創意"},
            };

            model.Books.ShouldAllBeEquivalentTo(expected);

        }
    }
}