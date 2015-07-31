using System.Collections;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class EnumeratorTests
    {
        // an enumerator is a forward-only cursor of a sequence of objects
        // IEnumerator is a base C# interface that has two methods:
        public abstract class AnEnumerator : IEnumerator
        {
            public bool MoveNext() // moves the cursor forward
            {
                throw new System.NotImplementedException();
            }

            public void Reset() // move the cursor back to the beginning
            {
                throw new System.NotImplementedException();
            }

            public object Current // get the current object under the cursor
            {
                get { throw new System.NotImplementedException(); }
            }
        }

    }


}
