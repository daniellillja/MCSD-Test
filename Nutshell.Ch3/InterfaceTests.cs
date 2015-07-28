using System;
using NUnit.Framework;

namespace Nutshell.Ch3
{
    [TestFixture]
    public class InterfaceTests
    {
        public interface IUndoable { void Undo(); }
        public class TextBox : IUndoable
        {
            void IUndoable.Undo() { Console.WriteLine("TextBox.Undo"); }
        }
        public class RichTextBox : TextBox, IUndoable
        {
            public new void Undo() { Console.WriteLine("RichTextBox.Undo"); }
        }



        [Test]
        public void InterfaceReimplementation()
        {
            RichTextBox r = new RichTextBox();
            r.Undo();                 // RichTextBox.Undo      Case 1
            ((IUndoable)r).Undo();    // RichTextBox.Undo      Case 2

            // this is an interesting siutation
            // we are trying to call the interface method of the base class
            // but because we reimplemented, calling the base class interface calls the subclass NON interface code
            ((IUndoable)((TextBox)r)).Undo();      // TextBox.Undo          Case 3


            // since this is a bit confusing, it is a better idea to try
            // and use virtual and override keywords to do this
        }
    }


}
