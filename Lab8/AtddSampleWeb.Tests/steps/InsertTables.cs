using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtddSampleWebTests.DataModels;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AtddSampleWebTests.steps
{
    [Binding]
    public sealed class InsertTables
    {
        [Given(@"Book table existed books")]
        public void GivenBookTableExistedBooks(Table table)
        {
            var books = table.CreateSet<Books>();
            using (var dbcontext = new NorthwindEntities())
            {
                dbcontext.Books.AddRange(books);
                dbcontext.SaveChanges();
            }
        }
    }
}
