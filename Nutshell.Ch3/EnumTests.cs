using System;
using System.Configuration;
using System.Linq;
using NUnit.Framework;

namespace Nutshell.Ch3
{
    [TestFixture]
    public class EnumTests
    {
        // these are assigned to ints 0,1,2,3 by default
        // the actual size stored of the enum is sizeof(int)
        // which would be 4 bytes
        public enum BorderSide { Left, Right, Top, Bottom }
        

        // you can also tell the enum to use other integral types (to use less memory)
        // this one will only use one byte
        public enum BorderSidesByteSized : byte { Left, Right, Top, Bottom=4 }

        [Flags]
        public enum BorderSides { Left, Right, Top, Bottom }

        [Test]
        public void EnumHelpsToDefineNumericConstants()
        {
            var right = BorderSide.Right;
            int x = (int)right;
            Assert.That(x, Is.EqualTo(1));

            Assert.That(Enum.GetNames(typeof (BorderSides)).Length, Is.EqualTo(4));
            Assert.That(Enum.IsDefined(right.GetType(), right));

            // you can also override the default values to one that you want
            Assert.That((int)BorderSidesByteSized.Bottom, Is.EqualTo(4));

            // flags enums can have multiple values at once
            // enum with both left and right
            var leftAndRight = BorderSides.Left | BorderSides.Right;
            var y = (int) leftAndRight;
            Assert.That(y, Is.EqualTo(1));

        }
    }


}
