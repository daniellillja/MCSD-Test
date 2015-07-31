using System;
using System.Dynamic;
using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class DynamicTests
    {
        // usually binding (figuring out what methods, classes, properties, etc) are defined as
        // happen during compile time (also known as "static")
        // use "dynamic" to shift then to runtime
        private dynamic dyn = new object();

        [Test]
        public void DynamicCanCompileWithNoMethodImplementation()
        {
            // since this method will not be found at runtime, CLR will throw RuntimeBinderException
            Assert.Throws<RuntimeBinderException>(() => dyn.MethodThatDoesntExist());

            // dynamic calls are VERY slightly slower;
            // with JIT compilation, dynamic expressions only take about 100 ns more on average
        }

        [Test]
        public void DuckCanRecieveAnyCalls()
        {
            dynamic d = new Duck();
            d.WriteSomething("print_this_string");
        }

        [Test]
        public void DynamicIsTheSameAsObject()
        {
            //Assert.That(typeof(dynamic) == typeof(object));

            // dynamic is the same thing as object except that binding is delayed until runtime
            // you can easily cast any object to be dynamic to enable dyamic operations

            // in fact, under the covers a dynamic object is just an object with a DynamicAttribute on it
            // this way, you can use reflection to identify dynamic types
        }

        public class Duck : DynamicObject
        {
            // this method gets called whenever you dynamically invoke a method on a duck
            // so you can intercept and do things when that happens
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                Console.WriteLine(binder.Name + " method was called");
                Console.WriteLine(args[0].ToString());
                result = null;
                return true;
            }
        }
    }


}
