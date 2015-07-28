using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Nutshell.Ch3
{
    [TestFixture]
    public class GenericsTests
    {
        class A<T> where T : struct
        {
            static void Zap<T>(T[] array)
            {
                for (int i = 0; i < array.Length; i++)
                    // the default keyword can be used to get a type parameters default value
                    // for all reference types this will be null
                    array[i] = default(T);
            }

            static void ZapNew<T>(T[] array) where T : new() // this constraint enables new T() constructor call
            {
                for (int i = 0; i < array.Length; i++)
                    // the default keyword can be used to get a type parameters default value
                    // for all reference types this will be null
                    array[i] = new T();
            }
        }

        class A<T1, T2>
            where T1 : class // reference type constraint
        where T2 : struct // ValueType constraint
        { }


        [Test]
        public void UnboundGenericTypes()
        {
            var a1 = typeof(A<>); // this is an unbound type (it has no type parameters)
            var a2 = typeof(A<,>); // an open generic type has unknown type arugments at compile time
            // An unbound type can't be used in expressions other than typeof() and you can't instantiate it or call its methods
            Assert.That(a1.IsGenericType);
            Assert.That(a1.IsGenericTypeDefinition);

            var a3 = new A<int>();
            Assert.That(a3.GetType().IsGenericType, Is.True); // a3 is generic but CLOSED
            Assert.That(a3.GetType().IsGenericTypeDefinition, Is.False); // a3 is generic but open
            Assert.That(a3.GetType().IsConstructedGenericType, Is.True);
        }

        [Test]
        public void TheDefaultKeyword()
        {
            var a1 = new A<int>();
            //Assert.That(A.Zap<int>());
        }

        public class Animal
        {
             
        }

        public class Bear : Animal
        {
             
        }

        public class Camel: Animal
        {
             
        }


        [Test]
        public void ContravarianceTests()
        {
            
            var bears = new Stack<Bear>();
            //Stack<Animal> animals = bears; 
            // this is not allowed; compile time error because a stack of bears is not convertible to a stock of animals
            // what would happend when you tried to add a camel to the stack of bears (as animals)
            // animals.add(new Camel()); would fail because Camels are not Bears

            // covariance: use "out" constaint to tell the compiler that type can only be in return values,
            // not in paramater list


            // contravariance is similar concept: except uses 'in' keyword in type constraint

            IEnumerable<Animal> animals = new List<Bear>();
            // this works because IEnumerable out fetches output list, interface does not allow you to add (input parameter)
        }
    }


}
