using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes.UnitTests
{
    [TestClass]
    public class TestSearchyModels
    {

        [TestMethod]
        public void TestFilterSerialization()
        {
            var filter = new SearchyFilter()
            {
                Field = "CreatedOn",
                Rule =   SearchyRule.EqualsTo,
                ValueDateTimeArray = new DateTime[] { DateTime.Now, DateTime.UtcNow }
            };

            var searchRequest = new SearchyRequest(filter.ToString());

            //var filterDeserialized = new SearchyFilter(Uri.UnescapeDataString(filter.ToString())); 

            var filter2 = new SearchyFilter
            {
                Field = "CreatedOn",
                Rule = SearchyRule.EqualsTo,
                ValueDateTimeArray = new DateTime[] { DateTime.Now }
            };

            var filter2Deserialized = new SearchyFilter(Uri.UnescapeDataString(filter2.ToString()));

        }


        [TestMethod]
        public void TestMethod1()
        {
            var sr = new SearchyRequest();
            var srStr = sr.ToString();

            var sr2 = new SearchyRequest(new SearchyCondition("Id", SearchyRule.GreaterThan, "kjkjhg...&"));
            sr2.Conditions.First().Filters.Add(new SearchyFilter("FirstName", SearchyRule.EqualsTo, null));
            sr2.Sorts.Add(new SearchySort("Id", SearchySortOrder.ASC));
            sr2.Sorts.Add(new SearchySort("Name:2"));
            var srStr2 = sr2.ToString();

            

            var sr3 = new SearchyRequest();
            sr3.PageSize = 0;
            var srStr3 = sr3.ToString();


            var sr4 = new SearchyRequest();
            sr4.Sorts.Add(new SearchySort("Date", SearchySortOrder.DEC)) ;
            sr4.CountRows = true; 
            var srStr4 = sr4.ToString();

            var srnew = new SearchyRequest("filter=Id:1:testvalue");


            var sres = new SearchyResponse<string>();

            sres.Result = new List<string>
            {
                "val1",
                "val2"
            };

            ISearchyResponse<object> sresDown = sres; 

            

        }

       
        Task<ISearchyResponse<string>> TestSearchyResponseCasting()
        {
            var sr = new SearchyResponse<string>();

            sr.Result = new List<string>
            {
                "val1",
                "val2"
            };

            return Task.FromResult(sr as ISearchyResponse<string>);
        }
    }
}
