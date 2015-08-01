using NUnit.Framework;

namespace Nutshell.Ch4
{
    // there is more to the chapter
    // using Ghostdoc is an easy way to automate the process of creating documentation

    /// <summary>
    /// Text fixture for Ch.4 XML section
    /// </summary>
    [TestFixture]
    public class XmlDocumentationTests
    {
        /// <summary>
        /// Documents the test1.
        /// </summary>
        /// <param name="str1">The STR1.</param>
        /// <param name="str2">The STR2.</param>
        public void DocTest1(string str1, string str2)
        {

        }

        /// <summary>
        /// Methods the returns a string.
        /// </summary>
        /// <param name="param1">The param1.</param>
        /// <param name="param2">The param2.</param>
        /// <returns>A string with the returned value</returns>
        public string MethodReturnsAString(object param1, string param2)
        {
            return string.Empty;
        }
    }


}
