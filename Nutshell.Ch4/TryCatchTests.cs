using System;
using MCSDTest.Common;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class TryCatchTests
    {
        [Test]
        public void TryCatchFinallyTests()
        {
            int[] intArray = new int[4];
            try
            {
                var test = intArray[6];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown");
            }
            finally
            {
                // finally will run evertime whether exception was thrown or not
                Console.WriteLine("Finally is good for deterministic cleanup operations");
            }
        }

        [Test]
        public void RethrowingAnException()
        {
            Action testCode = () =>
            {
                int[] intArray = new int[4];
                try
                {
                    var test = intArray[6];
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception was thrown");
                    Console.WriteLine(
                        "Exception has stack trace that lists all method layers between failure and try/catch:");
                    ex.StackTrace.ConsoleWriteAsJson();
                    Console.WriteLine();
                    Console.WriteLine("Exception has a message that is a short description of the failure:");
                    ex.Message.ConsoleWriteAsJson();
                    Console.WriteLine();

                    throw; // rethrowing an exception is good because you can log the exception with swallowing it
                }
                finally
                {
                    // this still runs even though exception was encountered
                    Console.WriteLine("Finally is good for deterministic cleanup operations");
                }
            };

            Assert.Throws<IndexOutOfRangeException>(() => testCode.Invoke());
        }
    }


}
