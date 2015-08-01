using System;
using NUnit.Framework;

[assembly:CLSCompliant(true)] // most of the time attributes are put on methods and classes
// you can put them on the entire assembly but you must explicitly say "assembly"

namespace Nutshell.Ch4
{
    [TestFixture]
    public class AttributesTests
    {
        // attributes are a way of marking up your code for various reasons

        // by convention, all attributes must end in "attribute" in the class definition

        [Obsolete] // generates a compiler warning for code trying to use this method
        public void OldMethod()
        {

        }

        [Serializable, Obsolete] // you can put multiple attributes on one line but you must comma delineate them
        public class Bar { }

        [Test]
        public void AnAttributeInheritsFromSystemAttribute()
        {
            OldMethod();
            Assert.That(typeof(ObsoleteAttribute).IsSubclassOf(typeof(System.Attribute)));
        }
    }


}
