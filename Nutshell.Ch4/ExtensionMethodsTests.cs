using System;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    // to use the extension methods, the static helper class namespace must be availible to
    // the call in its "using" statements
    public static class StringHelper
    {
        // the "this" parameter references the object that the extension method is called on
        public static bool IsCapitalized(this string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            return (Char.IsUpper(str[0]));
        }
    }
    [TestFixture]
    public class ExtensionMethodsTests
    {
        [Test]
        public void IsCapitalizedWorks()
        {
            Assert.That("Daniel".IsCapitalized());
        }
    }


}
