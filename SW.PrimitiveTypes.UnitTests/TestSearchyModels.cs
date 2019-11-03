using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SW.PrimitiveTypes.UnitTests
{
    [TestClass]
    public class TestSearchyModels
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sr = new SearchyRequest();
            var srStr = sr.ToString();

            var sr2 = new SearchyRequest(new SearchyCondition("Id", SearchyRule.GreaterThan, "kjkjhg...&"));
            sr2.Conditions.First().Filters.Add(new SearchyFilter("FirstName", SearchyRule.Contains, "sa#"));  
            var srStr2 = sr2.ToString();

            

            var sr3 = new SearchyRequest();
            sr3.PageSize = 0;
            var srStr3 = sr3.ToString();


            var sr4 = new SearchyRequest();
            sr4.Sorts.Add(new SearchySort("Date", SearchySortOrder.DEC)) ;
            sr4.CountRows = true; 
            var srStr4 = sr4.ToString();

            var srnew = new SearchyRequest(new string[] { "Id:1:testvalue" }, null, 0, 0, false);

        }
    }
}
