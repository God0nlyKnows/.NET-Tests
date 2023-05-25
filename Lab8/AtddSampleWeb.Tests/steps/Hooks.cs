using AtddSampleWebTests.DataModels;
using FluentAutomation;
using System.Linq;
using TechTalk.SpecFlow;

namespace AtddSampleWebTests.steps
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeFeature()]
        [Scope(Tag = "web")]
        public static void SetBrowser()
        {
            SeleniumWebDriver.Bootstrap(
               SeleniumWebDriver.Browser.Chrome
           );
        }

        [BeforeScenario()]
        public void CleanTable()
        {
            CleanTableByTag();
        }

        private static void CleanTableByTag()
        {
            var tags = ScenarioContext.Current.ScenarioInfo.Tags
                .Where(x => x.StartsWith("Clean"))
                .Select(x => x.Replace("Clean", ""));

            if (!tags.Any())
            {
                return;
            }

            using (var dbcontext = new NorthwindEntities())
            {
                foreach (var tag in tags)
                {
                    dbcontext.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{tag}]");
                }

                dbcontext.SaveChangesAsync();
            }
        }

        [AfterFeature()]
        public static void CleanTableAfterFeature()
        {
            CleanTableByTag();
        }
    }
}