using System;
using System.Security.Cryptography;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class UnsafeCodePointersTests
    {
        // pointers are an advanced way to do direct memory manipulation
        // a pointer holds the memory location of a variable
        // every type "V" has a pointer type of "V*"

        // special pointer operators:
        //      * [&] - "address-of" operator returns a pointer to some address
        //      * [*] - "pointer dereference" operator returns the variable associated with a pointer
        //      * [->] - "pointer-to-member" operator is convienent for getting the subfields of a pointer
        //          this is equal to deferencing the pointer and then using the dot operator to access the field (*x).y

        // unsafe C# code may be faster than calling unsafe C code because it doesn't have to leave the managed environment!

        [Test]
        public unsafe void PointerTest()
        {
            int i = 1000; // create an integer with the value of 1000


            int* pointerToI = &i;
            // pointer type is int* (pointer to an int)
            // the value of the int pointer is set to the location (in-memory) of the original 1000 variable

            int sameAsIntI = *pointerToI;

            // use fixed keyword to "pin" object in place on the heap
            // CLR will periodically reorganize and "defragment" the heap for efficiency
            // so the fixed keyword prevents that

            // a block of memory can be allocated on the stack using "stackalloc" keyword:
            int* a = stackalloc int[10]; // this say "make a block of 40 bytes (10*4) availible on the stack"
            // here a is a pointer to an int
            // a is also an array of ints!
            // the indexer function will offset the bracketed position

            Assert.That(a[3], Is.EqualTo(0)); // will be 0 because it is the default value of int
        }

        [Test]
        public unsafe void VoidPointers()
        {
            // a void pointer can point to ANY type
            // however, it cannot be easily dereferenced
            // therefore you must cast it to some time that you want to deal with
            // these are useful for large blocks of raw memory (say an MP3 file)

            Console.WriteLine(sizeof(short)); // size of short in bytes is 2 bytes

            short[] a = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55}; // create array of shorts
            fixed (short* p = a) // used fixed so that the array is not moved by the GC
            {
                Zap(p, a.Length*sizeof (short));
            }

            foreach (var s in a)
            {
                Assert.That(s, Is.EqualTo(0)); // the zap function will take the block of shorts and write the memory with 0's
            }
        }

        // here memory is some number of bytes where the type is unknown
        private unsafe void Zap(void* memory, int lengthInBytes)
        {
            byte* b = (byte*) memory; // cast the void pointer to a byte pointer
            for (int i = 0; i < lengthInBytes; i++)
            {
                *b++ = 0; // set the value of pointer b to zero and move the pointer to next byte
            }

        }

        // pointers are also useful when referencing methods/variables in unmanaged code
    }


}
