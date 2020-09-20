﻿using System;
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
        public void TestSearchyRequestEquality2()
        {
            int? x = 5;
            var sr1 = new SearchyRequest("Id", SearchyRule.EqualsTo, x);
            var sr2 = new SearchyRequest("Id", SearchyRule.EqualsTo, 5.0);
            var result = sr1 == sr2;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestSearchyRequestEquality3()
        {
            var sr1 = new SearchyRequest
            {
                Conditions = new List<SearchyCondition>
                {
                    new SearchyCondition
                    {
                        Filters = new List<SearchyFilter>
                        {
                            new SearchyFilter
                            {
                                Field = "Id",
                                Rule = SearchyRule.EqualsTo ,
                                ValueDecimal = 5
                            }
                        }
                    }
                }
            };
            var sr2 = new SearchyRequest
            {
                Conditions = new List<SearchyCondition>
                {
                    new SearchyCondition
                    {
                        Filters = new List<SearchyFilter>
                        {
                            new SearchyFilter
                            {
                                Field = "Id",
                                Rule = SearchyRule.EqualsTo ,
                                ValueDecimal = 6
                            }
                        }
                    }
                }
            };

            var result = sr1 == sr2;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestSearchyFilterEquality()
        {
            var sf1 = new SearchyFilter
            {
                Field = "Id",
                ValueStringArray = new[] { "test", "test2" }
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
