using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Nutshell.Ch4.Annotations;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class CallerInfoAttributeTests
    {
        // caller info attributes are optional parameters
        // they are put in at compile time, and give context about your code:
        public void UsefulForLogging([CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumer = 0)
        {
            Console.WriteLine("Membername:{0}", memberName);
            Console.WriteLine("File_path:{0}", filePath);
            Console.WriteLine("Line_number:{0}", lineNumer);
        }

        [Test]
        public void CallerInfoTest()
        {
            // compile will "substitute" the default values here when you compile
            UsefulForLogging(); // will output this class, line 23

            // this is very useful for implementing INotifyPropertyChanged
            // will tell you what property is raising the event in the class
        }

        [Test]
        public void PropertyChangedTest()
        {
            var foobar = new Foo();
            foobar.PropertyChanged += delegate (object sender, PropertyChangedEventArgs args)
            {
                Console
                    .WriteLine("{0} changed", args.PropertyName);
            };
            foobar.FullName = "Daniel"; // will call delegate above
            foobar.FullName = "Daniel Lillja";
        }

        public class Foo : INotifyPropertyChanged
        {
            private string _fullName;

            public string FullName
            {
                get
                {
                    return _fullName;
                }
                set
                {
                    if (value == _fullName) return;
                    _fullName = value;
                    OnPropertyChanged();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


}
