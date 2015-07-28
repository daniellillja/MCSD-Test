using System;
using System.Linq;
using NUnit.Framework;

namespace Nutshell.Ch3
{
    public class Asset
    {
        public string Name { get; set; }
        // virtual properties can be overriden in sub classes
        // use these sparingly:
        //      * these are dangerous to call in constructors because there could be uninteded sideeffects
        // however, the can be useful tools to maintain Liskov substitution principle

        // Liskov substitution principle: subclasses can always be used properly when they are cast to their base types
        public virtual decimal Liability { get; set; }
    }

    public class House : Asset // house is a subclass of Asset
    {
        public decimal Mortgage { get; set; }
    }

    public class Stock : Asset
    {
        public long SharesOwned { get; set; }
    }

    [TestFixture]
    public class InheritanceTests
    {
        [Test]
        public void SubclassTests()
        {
            var house = new House();
            Assert.That(house.GetType().IsSubclassOf(typeof(Asset))); // a house is a subclass of Asset

            // a house has a property named 'Name'
            Assert.That(house.GetType().GetProperties().Select(p => p.Name).Contains("Name"));
        }

        [Test]
        public void Polymorphism()
        {
            var house = new House();
            // polymorphism is the concept that subclass can be used as their base type
            var asset = ((Asset)house);
            var name = asset.Name; // this will use the 'Asset' name not the 'House' name
            // cannot do this:
            //      asset.Mortage;
        }

        [Test]
        public void DownCasting()
        {
            var stock = new Stock();
            var stockAsAsset = (Asset)stock; // this is an 'upcast' operation which should always work
            var stockAsStock = (Stock)stockAsAsset;// reverse the upcast with a downcast

            // 'as' operator will not throw InvalidCastException but returns null if it fails
            var stockAsAsset2 = stock as Asset;

            bool canConvert = false;
            if (stock is Asset)
            {
                // the 'is' operator will tell if the object can be successfully cast
                canConvert = true;
                Console.WriteLine("Stock can be converted to an Asset");
            }

            Assert.That(canConvert);

            Assert.Throws<InvalidCastException>(() =>
            {
                var aStockAssetCannotBeAHouseAsset = (House)stockAsAsset;
                // this fails on runtime and will throw INvalidCastException    
            });

        }


        public class A
        {
            public int Zero
            {
                get { return 0; }
            }
        }

        public class B : A
        {
            // this will hide original property
            public new int Zero { get { return 1; } }
            // note that there is a compiler warning on this field
            // to turn off the warning, use the new operator - note that the default treatement is still true

        }



        [Test]
        public void MemberHiding()
        {
            var objAsB = new B();
            var objAsA = (A) objAsB;

            // by default the compiler will use the property implementation assigned to each type
            Assert.That(objAsB.Zero, Is.EqualTo(1));
            Assert.That(objAsA.Zero, Is.EqualTo(0));

        }

        [Test]
        public void BoxingIsMakingAReferenceTypeFromAValueType()
        {
            int x = 9;
            // this moves the value type from the stack to the heap
            // this can be costly in terms of perforance to do this alot
            object obj = (object) x;
            Assert.That(obj, Is.InstanceOfType<object>());
            Assert.That(obj, Is.InstanceOfType<ValueType>());

            // unboxing reverses the boxing operation
            int y = (int) obj;
            Assert.That(obj, Is.EqualTo(x));

        }

        [Test]
        public void TypeChecking()
        {
            // programs are type checked at compile time
            // for example, you cant do this:
            //int x = "4";
            object x = new object();

            // things that are done at compile time are called static
            // typeof() operator is static (done at compile time), or by the JIT compiler in generics
            Type t1 = typeof (object);

            // things that are done at runtime are called dynamic
            Type t2 = x.GetType();


            // each object on the heap has a token that cooresponds to the type
            Console.WriteLine(x.GetType().MetadataToken);
            // this is used for runtime type checking
        }
    }


}
