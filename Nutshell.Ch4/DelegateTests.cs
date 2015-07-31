using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Nutshell.Ch4
{
    [TestFixture]
    public class DelegateTests
    {
        public delegate int Transformer(int x);
        static int Square(int x)
        {
            return x * x;
        }

        class Util
        {
            public static List<int> TransformList(List<int> list, Transformer t)
            {
                return list.Select(l => l = t(l)).ToList();

            }
        }

        [Test]
        public void ADelegateIsAClassThatCallsOtherMethods()
        {
            // define the delegate type; this defines what method signatures can be called
            Transformer t = Square;
            // call the delegate, not the actual method
            // this is a good way of decoupling method calls
            int answer = t(3);
            Assert.That(answer, Is.EqualTo(9));

            // passing a delegate is a good way to let high level interfaces execute code for you
            // for example a utility class 
            var list = new List<int>() { 1, 2, 3 };
            list = Util.TransformList(list, t);
            Assert.That(list[1], Is.EqualTo(4));

        }

        public delegate void PrintSomethingToConsole(string text);

        public void ConsoleWrapper1(string str1)
        {
            Console.WriteLine(str1);
        }

        public void ConsoleWrapper2(string str2)
        {
            Console.WriteLine(str2);
        }

        [Test]
        public void ADelegateHasMulticastCapibilities()
        {
            PrintSomethingToConsole printTwice = ConsoleWrapper1;
            printTwice += ConsoleWrapper2;

            // delegates with create an invocation list and will loop through them
            // you can add any currently accessable function with the same signature as the delegate

            printTwice("Print this string twice");

            // all delegates derive from the System.Delegate class
            Assert.That(printTwice.GetType().IsSubclassOf(typeof(System.MulticastDelegate)));

        }

        public delegate void PrintProgress(int number);

        public void PrintProgressMethod(int number)
        {
            Console.WriteLine(number);
        }

        [Test]
        public void DelegatesAreAGoodWayToDecouple()
        {
            // lets say you have code to log the progress of something
            PrintProgress p = PrintProgressMethod;

            // essentially it is easy to pass in the code for the "PrintProgressMethod" here
            // therefore "HardWorkerMethod" only has to know the signature for the method it is calling
            // almost like programming to an interface for only one method
            HardWorkerMethod(10, p);
        }

        private void HardWorkerMethod(int num, PrintProgress printProgress)
        {
            for (int i = 0; i < num; i++)
            {
                printProgress(i);
                Thread.Sleep(100); // thread will stop for 100 ms and go do other OS work
            }
        }

        [Test]
        public void WhatIsTheTargetOfADelegate()
        {
            var targetReference = new TargetClass();
            TextConsoleWriter p = targetReference.WorkerMethod;

            // the target is the object that the method you are calling is part of
            Assert.That(p.Target, Is.EqualTo(targetReference));
            Assert.That(((TargetClass)p.Target).TargetName, Is.EqualTo("target_name"));

        }

        [Test]
        public void EventSubscriber()
        {

            var broadcaster = new Broadcaster();
            broadcaster.PriceChanged += PriceChangedWriter;

            broadcaster.Price = 30;
            broadcaster.Price = 40;
            broadcaster.Price = 50;


            // everytime you the the "Price" field the handler is called
        }

        private void PriceChangedWriter(decimal oldprice, decimal newprice)
        {
            Console.WriteLine("price changed from {0} to {1}", oldprice, newprice);
        }


        // in .NET events have a standard pattern:
        [Test]
        public void EventsHaveAStandardPattern()
        {
            
        }


    }

    public class PriceChangedEventArgs : EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }

    public delegate void TextConsoleWriter(string text);

    public class TargetClass
    {
        public string TargetName { get; set; }

        public TargetClass()
        {
            TargetName = "target_name";
        }
        public void WorkerMethod(string text)
        {
            var reverse = text.ToCharArray().ToList();
            reverse.Reverse();
            Console.WriteLine(reverse);
        }



        public class Stock
        {
            private decimal _price;

            public decimal Price
            {
                get
                {
                    return _price;
                }
                set
                {
                    if (_price == value) return;
                    decimal oldPrice = _price;
                    _price = value;
                    OnPriceChanged(new PriceChangedEventArgs(oldPrice, _price));
                }
            }

            public event EventHandler<PriceChangedEventArgs> PriceChanged;
            // any method inside of Stock class can call the event, which then triggers subscribers

            protected virtual void OnPriceChanged(PriceChangedEventArgs e)
            {
                PriceChanged?.Invoke(this, e); // null propagation, will check for null before invocation
            }
        }


    }


    // events: events are a formalized C# design pattern around delegates
    // these make it easy to implement a "publish and subscribe" model

    public delegate void PriceChangedCallThisCode(decimal oldPrice, decimal newPrice);


    public class Broadcaster
    {
        // the broadcaster, by definition has an event which other objects can access
        public event PriceChangedCallThisCode PriceChanged;
        // objects outside of this class can only subscribe to this code,
        // while objects inside tell when to call this delegate

        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set
            {
                PriceChanged(_price, value);
                _price = value;
            }
        }


    }


}
