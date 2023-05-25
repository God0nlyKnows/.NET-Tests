using AtddSampleWeb.Models;
using FluentAutomation;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AtddSampleWebTests.steps
{
    [Binding]
    [Scope(Feature = "BookMaintenance")]
    public class BookMaintenanceSteps : FluentTest
    {
        private BookRegisterPage _bookRegisterPage;
        private BookQueryPage _bookQueryPage;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            this._bookRegisterPage = new BookRegisterPage(this);
            this._bookQueryPage = new BookQueryPage(this);
        }

        [Given(@"go to Book Registering Page")]
        public void GivenGoToBookRegisteringPage()
        {
            this._bookRegisterPage.Go();
        }

        [Given(@"a book for registering")]
        public void GivenABookForRegistering(Table table)
        {
            var book = table.CreateInstance<BookViewMoel>();
            ScenarioContext.Current.Set<BookViewMoel>(book);
        }

        [When(@"Add book into library")]
        public void WhenAddBookIntoLibrary()
        {
            var book = ScenarioContext.Current.Get<BookViewMoel>();
            this._bookRegisterPage.Create(book);
        }

        [Then(@"added successfully message should be displayed")]
        public void ThenAddedSuccessfullyMessageShouldBeDisplayed()
        {
            string addedSuccessFulMessage = GetSuccessfulMessage();
            this._bookRegisterPage.ShouldDisplay(addedSuccessFulMessage);
        }

        private string GetSuccessfulMessage()
        {
            return "新增成功";
        }

        [Given(@"go to Book Query Page")]
        public void GivenGoToBookQueryPage()
        {
            this._bookQueryPage.Go();
        }

        [Given(@"Query Condition: book name is ""(.*)""")]
        public void GivenQueryConditionBookNameIs(string name)
        {
            ScenarioContext.Current.Set<string>(name, "name");
        }

        [When(@"Query")]
        public void WhenQuery()
        {
            var name = ScenarioContext.Current.Get<string>("name");
            var condition = new BookQueryCondition { Name = name };
            this._bookQueryPage.Query(condition);
        }

        [Then(@"it should display book records")]
        public void ThenItShouldDisplayBookRecords(Table table)
        {
            var books = table.CreateSet<BookQueryResult>();
            this._bookQueryPage.ShouldDisplay(books);
        }
    }
}