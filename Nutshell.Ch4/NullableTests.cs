using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class NullableTests
    {
        // a nullable is an immutable wrapper class for ValueTypes
        // ValueTypes, by definition cannot be null
        // putting a ValueType inside of a nullable makes it able to be null



        [Test]
        public void Nullables()
        {
            int? nullableInt = 15;
            Assert.That(nullableInt.HasValue, Is.True);
            Assert.That(nullableInt.Value, Is.EqualTo(15));
        }

        [Test]
        public void NullCoalescingOperator()
        {
            // null coalescing operator first checks to see if something is null,
            // and then assigns a default value to it if it is

            int? i = null;
            int o = i ?? 5;
            Assert.That(o, Is.EqualTo(5));
        }
    }


}
