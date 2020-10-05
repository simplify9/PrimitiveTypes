using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes.UnitTests
{
    [TestClass]
    public class LookupTests
    {
        [TestMethod]
        public void TestSerializeDeserialize()
        {
            var lookup = Lookup.FromSearchy("countries");
            var lookupSerialized = JsonConvert.SerializeObject(lookup);
            var lookupDeserialized = JsonConvert.DeserializeObject<Lookup>(lookupSerialized);

            var lookup1 = Lookup.FromSearchy("countries");
            var lookup1Serialized = System.Text.Json.JsonSerializer.Serialize(lookup1);
            var lookup1Deserialized = System.Text.Json.JsonSerializer.Deserialize<Lookup>(lookup1Serialized);


        }
    }
}
