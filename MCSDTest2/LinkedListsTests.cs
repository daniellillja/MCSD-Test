using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MCSDTest2
{
    [TestFixture]
    public class LinkedListsTests
    {
        [Test]
        public void ExploreLinkedLists()
        {
            // a LinkedList is a doubly linked list
            var linkedList = new LinkedList<string>();
            linkedList.AddFirst("1");
            // first argument accepts a "LinkedListNode"
            linkedList.AddAfter(linkedList.First, "2");
            linkedList.AddLast("3");
            linkedList.AddAfter(linkedList.Find("2"), "4");

            var orderedArray = linkedList.ToArray();
            // order should be 1,2,4,3
            Assert.That(orderedArray[0], Is.EqualTo("1"));
            Assert.That(orderedArray[1], Is.EqualTo("2"));
            Assert.That(orderedArray[2], Is.EqualTo("4"));
            Assert.That(orderedArray[3], Is.EqualTo("3"));

            // advantages:
            //  insertion is really easy

            // disadvantages:
            // looping through the objects is harder because they arent saved on contigous memory blocks

            // most of the time it is best NOT to use linked lists
            // essentially they are only good for insert/remove in the middle of lists
            // LinkedList<T> does NOT implement IList<T> - so does not have alot of useful methods
            // List<T> is much faster for random access (because backed by Array)
            // SEE: https://stackoverflow.com/questions/169973/when-should-i-use-a-list-vs-a-linkedlist


        }
    }


}
