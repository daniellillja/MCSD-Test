using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Nutshell.Ch1
{
    [TestFixture]
    public class VariablesAndParameters
    {
        static void Foo(int p)
        {
            p++;
            Console.WriteLine(p);
        }

        static void RefFoo(ref int p)
        {
            p++;
            Console.WriteLine(p);
        }

        [Test]
        public void ArgumentsCanBePassedByReference()
        {
            // all of these calls reference the same variable
            int p = 10; 
            Console.WriteLine(p); // should output 10
            RefFoo(ref p); // should output 11
            Console.WriteLine(p); // should output 11

            int x;
            //RefFoo(ref x);
            // you must initialize a ref parameter, else it will not compile (ABOVE)
            

        }
        [Test]
        public void ArgumentsArePassedByValue()
        {
            // be default arguments are passed by value which essentially means they are copied
            int p = 10;
            Console.WriteLine(p); // this will output 10
            Foo(p); // this will output 11

            Console.WriteLine(p); // this will also be 10
        }

        static int GetSum(params int[] numbers)
        {
            var result = 0;
            foreach (var number in numbers)
            {
                result += number;
            }

            return result;
        }

        [Test]
        public void ParamsModifier()
        {
            // useful to pass any number of parameters into a function
            var result = GetSum(1, 2, 3, 4, 5, 6);
            Assert.That(result, Is.EqualTo(21));

        }

        static string OptionalParamterTestMethod(int x = 0, int y = 1)
        {
            return string.Empty;
        }

        [Test]
        public void OptionalParameters()
        {
            // you can call the test method without an parameters if you want
            var ret1 = OptionalParamterTestMethod();

            // in reality, the compiler just fills in the arguments at the call site
            // above call is the exact same as calling with the default argumments
            var ret2 = OptionalParamterTestMethod(0, 1);
        }

        // test this in a .NET disassembler (ildasm.exe)
        public class TestClass2
        {
            // properties look like fields (variables defined on the class level)
            // however, the compiler actually makes them into methods in assembly code
            public string AutomaticProperty { get; set; } // this is an 'automatic' property
                                                          // however for performance, the JIT will inline these to a field accessor where you access them

            // inline optimization: when a method call is replace with actual code
            // kind of like copy/paste the low level code where it is called
            // this prevents the CLR from having to create a new method/stack

            // this is a constant string
            // these are baked into the application at compile time
            // therefore the "CONSTANT_STRING" bytes are litterally copied by the compiler into wherever the are used
            // this is what ildasm.exe says:
            //      .field public static literal string AConstantString = "CONSTANT_STRING"
            public const string AConstantString = "CONSTANT_STRING";
            // be careful with constants... they really should never change
            // if you compile something that references the value, these bytes will be copied into that assembly
            // if the constant may change, it is best to use static readonly instead!

        }

        public class Sentence
        {
            private string[] _words = "The quick brown fox".Split(' ');

            // this is an indexer
            // is a property named
            public string this[int index]
            {
                get { return _words[index]; }
            }
        }

        [Test]
        public void IndexerTest()
        {
            var sentence = new Sentence();
            var word = sentence[1]; // get the second word easily
            Assert.That(word, Is.EqualTo("quick"));
        }
    }


}
