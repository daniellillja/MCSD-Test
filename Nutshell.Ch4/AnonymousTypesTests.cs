using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class AnonymousTypesTests
    {
        [Test]
        public void AnonymousType()
        {
            // an anonymous type is actually compiled into the program, but does not have a name
            // similar to anonmous methods
            // check ildasm.exe to confirm...
            var dude = new {Name = "Bob", Age = 22};

        } 
    }


}
