using System;
using NUnit.Framework;

namespace Nutshell.Ch1
{
    [TestFixture]
    public class ArrayTests
    {
        [Test]
        public void RectangularArrays()
        {
            int[,] rectArray = new int[3,3]; // pretty much same size as regular array
            // but indexer is 2d and more convienent
            
            Assert.That(rectArray.Rank, Is.EqualTo(2)); // rank is number of dimensions
            Assert.That(rectArray.Length, Is.EqualTo(9));
            Assert.That(rectArray.GetUpperBound(1), Is.EqualTo(2)); // rectArray[2,2] is the last element in each dimension

            Assert.That(rectArray.GetType().IsSubclassOf(typeof(ValueType)), Is.Not.True); // arrays are always reference types even if they store ValueTypes
        }

        [Test]
        public void JaggedArrays()
        {
            // a jagged array is "an array of arrays"
            int[][] jaggedArray = new int[3][]
            {
                new int[] {0, 1, 2},
                new int[] {0, 1, 2},
                new int[] {0, 1, 2},
            };
        }

        [Test]
        public void IndexOutOfRange()
        {
            var array = new int[10];
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var result = array[11];
            });
        }
    }


}
