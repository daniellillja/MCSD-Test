using System;
using MCSDTest1.Test1;
using NUnit.Framework;

namespace MCSDTest2
{
    [TestFixture]
    public class Class1Tests
    {
        [Test]
        public void Number1()
        {
            var test = new Employee();
            Assert.That(test, Is.Not.Null);
        }
    }
}
