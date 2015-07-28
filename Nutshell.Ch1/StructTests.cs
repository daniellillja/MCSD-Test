using System;
using System.Reflection;
using NUnit.Framework;

namespace Nutshell.Ch1
{
    [TestFixture]
    public class StructTests
    {
        private PointStruct _p1;
        private PointStruct _p2;

        [SetUp]
        public void Setup()
        {
            _p1 = new PointStruct();
            _p1.X = 7;
            _p1.Y = 10;

            _p2 = _p1;
        }

        [Test]
        public void StructsAreCopiedByValueNotReference()
        {
            // assigment will copy, by VALUE not REFERENCE
            Assert.That(_p1, Is.Not.SameAs(_p2));

        }

        [Test]
        private void StructsAreValueTypes()
        {
            // structs are inherited from System.ValueType
            Assert.That(_p1.GetType().IsSubclassOf(typeof(ValueType)));
        }

        [Test]
        public void StructsCanNotBeNull()
        {
            // structs cannot be assigned a value of null unless they are "nullable"
            Assert.That(_p1, Is.Not.Null);
        }

        [Test]
        public unsafe void StructsSizeIsSumOfPropertySizes()
        {
            // structs are more memory effience they do not have "object metadata"

            // ints are 4 bytes
            Assert.That(sizeof(PointStruct), Is.EqualTo(8));
        }

    }

    public struct PointStruct
    {
        public int X;
        public int Y;

        // struct "constructors" MUST assign each instance field
        // compiler checks for this
        public PointStruct(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
