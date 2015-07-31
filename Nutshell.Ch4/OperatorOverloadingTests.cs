using System;
using System.ComponentModel;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class OperatorOverloadingTests
    {
        // you can overload the standard c# operators and write your own custom meanings for them
        public struct Note
        {
            public int SemitonesFromA;

            public Note(int semitonesFromA)
            {
                this.SemitonesFromA = semitonesFromA;
            }

            // this is the operator function
            public static Note operator +(Note x, int semiTones)
            {
                return new Note(x.SemitonesFromA + semiTones);
            }

            // some operators are "paired"
            // which means that you have to implement != when you implement ==
            public static bool operator ==(Note n1, Note n2)
            {
                return n1.SemitonesFromA.Equals(n2.SemitonesFromA);
            }

            // this cleverly just takes the logical NOT of the overloaded == operator!
            public static bool operator !=(Note n1, Note n2)
            {
                return !(n1 == n2);
            }

            // this is an example of a casting operator overload
            // note that the name of the type to return is the "function name"
            public static implicit operator double(Note n)
            {
                // this converts the semitones value to Hertz
                return 440*Math.Pow(2, (double) n.SemitonesFromA/12);
            }

            public static explicit operator Note(double d)
            {
                return new Note((int)(0.5 + 12 * (Math.Log(d / 440) / Math.Log(2))));
            }
        }

        [Test]
        public void NoteOperatorPlus()
        {
            Note n1 = new Note(1), n2 = new Note(3);
            var addNotes = n1 + 4;
            // can use the equality operator because structs are value types
            Assert.That(addNotes, Is.EqualTo(new Note(5)));

            // the compound assignment operator is also written once you do '+'
            Assert.That(addNotes += 1, Is.EqualTo(new Note(6)));

            Assert.That(n1 != n2);

            double n1Hz = n1;
            // since this is an EXPLICIT operator, casting MUST be done
            Assert.That((Note)n1Hz, Is.EqualTo(n1));
        }
    }
}