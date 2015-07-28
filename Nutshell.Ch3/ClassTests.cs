using System;
using NUnit.Framework;

namespace Nutshell.Ch3
{
    [TestFixture]
    public class ClassTests
    {
        public class TestClass1
        {
            public int Age = 10; // field initialization
            // field initialization occur BEFORE the constructor is called
            public int Number; // field initialization is optional, otherwise will use default value for this type (0)
            public object AnObject;
            public readonly object ReadonlyField;

            private TestClass1()
            {
                ReadonlyField = 67;
            }

            public static TestClass1 Create()
            {
                // constructors need not be public
                // this a static factory method:
                //  this is useful for cache/object pool pattern
                return new TestClass1();
            }
        }

        [Test]
        public void AClassIsTheMostCommonReferenceType()
        {
            var obj = TestClass1.Create();
            // a class is a reference type, which are stored on the heap
            // a reference (variable here is obj) is a stored on the stack
            // the reference is only the location of the object on the heap, not the entire object data
            Assert.That(obj.GetType().IsSubclassOf(typeof(ValueType)), Is.Not.True);

            // field initialization is optional, will use default values
            // default values are often a bitwise '0' of value
            
            Assert.That(obj.Number, Is.EqualTo(0));
            // for an int that would be '0x00000000' (an int is 32 bits/4 bytes)

            // CANNOT do this... a readonly field can only be written to in a constructor
            //obj.ReadonlyField = 67;
            Assert.That(obj.ReadonlyField, Is.EqualTo(67));
        }

        public class TestClass2
        {
            // like regular field initializers, static field initializers are called before static constructors
            public static int StaticField = 1;
            
            static TestClass2()
            {
                // classes can have static constructors, which are called everytime a type is made
                Console.WriteLine("Type initialized...");

                // this will write that message everytime the type is created
            }

            public TestClass2()
            {
                
            }

            // this is a finalizer
            // finalizers are called just before the type is garbage collected
            ~TestClass2()
            {
             // more in depth on these at a later date   
            }
        }



    }


}
