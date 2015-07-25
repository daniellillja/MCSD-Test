using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MCSDTest2
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void QueueExplore()
        {
            var queue = new Queue<string>();
            queue.Enqueue("1");
            queue.Enqueue("2");
            
            Assert.That(queue.Dequeue(), Is.EqualTo("1"));
            Assert.That(queue.Count, Is.EqualTo(1));
            queue.Enqueue("3");
            // you CAN loop through a queue as it implements IEnumerable
            foreach (var number in queue)
            {
                Console.WriteLine(number);
            }

            // original queue would have memory for 3, decrease it to only use 2 (same as count)
            queue.TrimExcess(); 
        }
    }


}
