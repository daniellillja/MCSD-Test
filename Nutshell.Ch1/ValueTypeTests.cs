using System;
using NUnit.Framework;

namespace Nutshell.Ch1
{
    [TestFixture]
    public class ValueTypeTests
    {

        [Test]
        public unsafe void ValueTypeSizes()
        {
            Assert.That(sizeof(short), Is.EqualTo(2)); // 2 bytes, 16 bits
            Assert.That(sizeof(byte), Is.EqualTo(1)); // 1 bytes, 8 bits
            Assert.That(sizeof(int), Is.EqualTo(4)); // 4 bytes, 32 bits
            Assert.That(sizeof(long), Is.EqualTo(8)); // 8 bytes, 64 bits
        }

        [Test]
        public void NumericLiterals()
        {
            long number = 0x7F;
            Assert.That(number, Is.EqualTo(127)); // different notation but same value

            var dec = 1.0M; // M used for decimals (128 bit)
            Console.WriteLine(sizeof(decimal) * 8);

            var flt = 1.0F; // F used for floats (32 bit)
            Console.WriteLine(sizeof(float) * 8);

            var dbl = 1.0; // default notation creates double (64 bit)
            Console.WriteLine(sizeof(double) * 8);

        }

        [Test]
        public void NumericConversions()
        {
            int x = 12345;
            long y = x; //implicit concertion - a long can always store more than an int
            short z = (short)x; // explicit conversion, this works because z can be stored in 16 bits
            Console.WriteLine(z);
        }
    }


}
