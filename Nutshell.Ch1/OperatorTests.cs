using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
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

        [Test]
        public void DivideByZeroWillThrowException()
        {
            var a = 5;
            var b = 0;
            Assert.Throws<DivideByZeroException>(() =>
            {
                var result = a/b;
            });
        }

        [Test]
        public void EqualityOperator()
        {
            var d1 = new Dude("John"); // create new dude on the heap
            var d2 = new Dude("John"); // create another dude on the heap
            Assert.That((d1 == d2), Is.False);
            var d3 = d1; // d3 variable in fact only stores the reference or "location" of that value on the heap
            Assert.That((d1 == d3), Is.True);

        }

        [Test]
        public void TernaryOperator()
        {
            var a = 2;
            var b = 4;
            var c = (a < b) ? "a less than b" : "something else";
            // if a < b, then evaluate first expression
            Assert.That(c, Is.EqualTo("a less than b"));
        }

        // stopped at page 34
       
    }

    public class Dude
    {
        public string Name { get; set; }

        public Dude(string name)
        {
            Name = name;
        }
    }
}
