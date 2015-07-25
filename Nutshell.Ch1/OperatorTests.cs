using System;
using NUnit.Framework;

namespace Nutshell.Ch1
{
    [TestFixture]
    public class OperatorTests
    {
        [Test]
        public void IncrementAndDecrementOperators()
        {
            int x=0, y = 0;
            Console.WriteLine(x++); // print x before increment (displays 0)
            Console.WriteLine(++y); // increment y before print (displays 1)

        }

        [Test]
        public void DivisionTruncatesDecimalPoints()
        {
            int a = 2/3;
            Console.WriteLine(a);
            Assert.That(a, Is.EqualTo(0));
        }

       
    }


}
