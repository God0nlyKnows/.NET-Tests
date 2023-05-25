using AtddSampleWeb.Controllers;
using AtddSampleWeb.Models;
using AtddSampleWebTests.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AtddSampleWebTests
{
    [Binding]
    [Scope(Feature = "BookController")]
    public class BookControllerSteps
    {
        private BookController _bookController;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            this._bookController = new BookController(new BookService());
        }

        [Given(@"a book for registering")]
        public void GivenABookForRegistering(Table table)
        {
            var book = table.CreateInstance<BookViewMoel>();
            ScenarioContext.Current.Set<BookViewMoel>(book);
        }

        [When(@"Create")]
        public void WhenCreate()
        {
            var book = ScenarioContext.Current.Get<BookViewMoel>();
            this._bookController.Create(book);
        }

        [Then(@"Book table should exist a record")]
        public void ThenBookTableShouldExistARecord(Table table)
        {
            using (var dbcontext = new NorthwindEntities())
            {
                var firstBook = dbcontext.Books.FirstOrDefault();
                Assert.IsNotNull(firstBook);

                table.CompareToInstance(firstBook);
            }
        }

        [Given(@"Query condition is")]
        public void GivenQueryConditionIs(Table table)
        {
            var queryCondition = table.CreateInstance<BookQueryViewModel>();
            ScenarioContext.Current.Set<BookQueryViewModel>(queryCondition);
        }

        [When(@"Query")]
        public void WhenQuery()
        {
            var condition = ScenarioContext.Current.Get<BookQueryViewModel>();
            var result = this._bookController.Query(condition);

            ScenarioContext.Current.Set<ActionResult>(result);
        }

        [Then(@"ViewModel\.Books should be equals")]
        public void ThenViewModel_BooksShouldBeEquals(Table table)
        {
            var viewResult = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            var model = viewResult.ViewData.Model as BookQueryViewModel;

            table.CompareToSet(model.Books);
        }
    }
}