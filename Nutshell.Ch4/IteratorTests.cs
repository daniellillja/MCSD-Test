using System.Collections.Generic;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class IteratorTests
    {
        // an iterator is the PRODUCER of an enumerator
        // cool thing about these is that these are LAZY
        // if you loop through these and stop early, unneccessary calculation will be halted
        public static IEnumerable<int> GetFibonnaccis(int n)
        {
            for (int i = 0, prevFib = 1, curFib = 1; i < n; i++)
            {
                yield return prevFib; // each yield return will "add" to returned list
                int newFib = prevFib + curFib;
                prevFib = curFib;
                curFib = newFib;

            }
        }
            
            [Test]
        public void Method_Scenario_Expected()
        {
            
        }
    }


}
