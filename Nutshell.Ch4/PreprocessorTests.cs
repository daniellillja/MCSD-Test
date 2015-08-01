using System.Diagnostics;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class PreprocessorTests
    {
        [Test]
        public void RunTestIfDebugIsDefined()
        {
            bool debug = false;
#if DEBUG
            debug = true;
#endif
            Assert.That(debug); // this statement will pass if you are running in DEBUG mode

            // the DEBUG symbol is defined by visual studio but you can define your own

        }

        [Conditional("DEBUG")]
        public void CompileThisIfDebug()
        {
            // this method will only be included in the build in DEBUG mode...
            // a cleaner way than using #if blocks
        }
    }


}
