using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SW.PrimitiveTypes.UnitTests;

[TestClass]
public class ObjectExtensionsTests
{
    [TestMethod]
    public void TestUtcHandling()
    {
        var input = "2024-02-26T21:10:00.000Z";

        var output =input.ConvertValueToType(typeof(DateTime));

        Assert.AreEqual(new DateTime(2024, 2, 26, 21, 10, 0, DateTimeKind.Utc), output);
    }
        
    [TestMethod]
    public void TestNullableUtcHandling()
    {
        var input = "2024-02-26T21:10:00.000Z";

        var output =input.ConvertValueToType(typeof(DateTime?));

        Assert.AreEqual(new DateTime(2024, 2, 26, 21, 10, 0, DateTimeKind.Utc), output);
    }

}