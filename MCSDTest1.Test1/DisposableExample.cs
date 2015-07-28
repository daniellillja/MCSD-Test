using System;

namespace MCSDTest1.Test1
{
    // IDisposable interface is useful if you want to clean up an object that uses alot of memory right when you are done using it
    // otherwise you will have to wait until the garbage collector comes by
    public class ClassToBeDisposed : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);

            // SuppressFinalize should only be called by a class that has a finalizer. 
            // It's informing the Garbage Collector (GC) that this object was cleaned up fully.
            GC.SuppressFinalize(this);
        }

        // this is a finalizer method
        // be careful when implementing these - you make make false assumptions about the state of the program
        ~ClassToBeDisposed()
        {
            // finalizer can only be called by garbage collector, so it is non-deterministic
            Dispose(false);
        }

        // all resource cleanup should be contained in the protected method
        protected virtual void Dispose(bool disposing)
        {
            // if disposing is true, then this method was called by user code or using statement
            if (disposing)
            {
                // dispose of managed resources NOW
            }
            // this will be run whether this was a user or a garbage collection dispose
            // dispose of unmanaged resources
        }
    }
}
