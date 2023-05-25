using FluentAutomation;
using System.Collections.Generic;
using System.Linq;

namespace AtddSampleWebTests
{
    public class BookQueryPage : PageObject<BookQueryPage>
    {
        public BookQueryPage(FluentTest test) : base(test)
        {
            this.Url = $"{PageContext.Domain}/book/query";
        }

        public void Query(BookQueryCondition condition)
        {
            I.Enter(condition.Name).In("#name")
                .Click("input[type=\"submit\"]");
        }

        public void ShouldDisplay(IEnumerable<BookQueryResult> books)
        {
            for (int i = 1; i < books.Count(); i++)
            {
                var book = books.ElementAt(i);

                var cssSelector = $".table tbody>tr:nth-child({i + 1}) td.name";
                I.Assert.Text(book.Name).In(cssSelector);
            }
        }
    }
}