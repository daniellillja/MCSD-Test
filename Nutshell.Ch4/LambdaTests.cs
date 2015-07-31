using System;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class LambdaTests
    {
        public delegate int Transformer(int x);

        [Test]
        public void ADelegateIsAnExtremelyCompactWayOfWritingAMethod()
        {
            // here i is an int that "goes into" and the lambda returns i * i
            // lamdas have the form of (parameters) => [statement block]
            // you can ignore the parenthesis if there is only on parameter
            Transformer t = i => i * i;
            // Func is a generic class introduced that pretty much makes delegates obsolete
            Func<int, int> funcT = i => i * i;

            Assert.That(t(3), Is.EqualTo(9));
            Assert.That(funcT(3), Is.EqualTo(9));

        }

        [Test]
        public void CapturedVariables()
        {
            int factor = 5;
            // here factor is a "captured variable"
            // the Func is a closure because it is code that refences variables outside its scope

            Func<int, int> multiplier = i => i * factor;

            Assert.That(multiplier(5), Is.EqualTo(25));
            factor += 10;

            // the captured variables are evalutated when the Func is actually invoked:
            Assert.That(multiplier(5), Is.EqualTo(75));

            // under the scenes, captured variables are "hoisted" into a private class
            // the private class is attached to the lifetime of the delegate, so it is not garbage collected prematurely

        }

        [Test]
        public void AnAnonymousMethodIsAMethodWithoutAName()
        {
            Transformer t = delegate (int x) { return x*x; };
            // anonymous methods are very similar to lambda methods but they cannot have a name
            // anonymous methods capture variables in the same way that lamdas do
            // they also do not have restrictions on where you define them
            // for example, a method usually has to be defined INSIDE a class where
            // anonymous methods can be define inside a METHOD

        }
    }
}