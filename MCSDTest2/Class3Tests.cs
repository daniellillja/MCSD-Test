using System;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MCSDTest2
{
    [TestFixture]
    public class Class3Tests
    {
        [Test]
        // You are creating a console application by using C#. You need to access the application assembly. Which code segment should you use?
        public void Test3()
        {
            var assembly = Assembly.GetExecutingAssembly();
            TestHelper.PrintAsJson(assembly);
            
        }
    }

    public static class TestHelper
    {
        public static void PrintAsJson(object obj)
        {
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
    }
}
