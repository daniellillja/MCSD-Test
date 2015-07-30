using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class DelegateTests
    {
        public delegate int Transformer(int x);
        static int Square(int x)
        {
            return x*x;
        }

        class Util
        {
            public static void TransformList(IEnumerable<int> list, Transformer t)
            {
                foreach (var i in list)
                {
                    t(i);
                }
            } 
        }

        [Test]
        public void ADelegateIsAClassThatCallsOtherMethods()
        {
            // define the delegate type; this defines what method signatures can be called
            Transformer t = Square;
            // call the delegate, not the actual method
            // this is a good way of decoupling method calls
            int answer = t(3);
            Assert.That(answer, Is.EqualTo(9));

            // passing a delegate is a good way to let high level interfaces execute code for you
            // for example a utility class 
            var list = new List<int>() { 1,2,3};
            Util.TransformList(list, Square);
            Assert.That(list[1], Is.EqualTo(4));

        }
    }


}
