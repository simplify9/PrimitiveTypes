using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SW.PrimitiveTypes.UnitTests
{
    [TestClass]
    public class SearchyEqualityTests
    {
        [TestMethod]
        public void TestSearchyRequestEquality()
        {
            var sr1 = new SearchyRequest("Id", SearchyRule.EqualsTo, "s");
            var sr2 = new SearchyRequest("ID", SearchyRule.EqualsTo, "s");
            var result = sr1 == sr2;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestSearchyFilterEquality()
        {
            var sf1 = new SearchyFilter
            {
                Field = "Id",
                ValueStringArray = new [] { "test", "test2" }
            };

            var sf2 = new SearchyFilter 
            {
                Field = "ID",
                ValueStringArray = new[] { "test", "test2" }
            };

            var result = sf1 == sf2;
            Assert.IsTrue(result);
        }


    }
}
