using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

namespace ReactiveTest
{
    [TestClass]
    public class ObservingWithThreadControl
    {
        [TestMethod]
        public void TestMethod1()
        {
            var query = Enumerable.Range(1, 25).Select(x => x.ToString());
            var obsQuery = query.ToObservable(Scheduler.Default);//used to be Scheduler.ThreadPool
            obsQuery.Subscribe(n => Console.WriteLine(n));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var query = Enumerable.Range(1, 25).Select(x => x.ToString());
            var obsQuery = query.ToObservable();
            obsQuery.Subscribe(Console.WriteLine, ImDone);

        }

        [TestMethod]
        public void TestMethod3()
        {
            Console.WriteLine($"my thread {Thread.CurrentThread.ManagedThreadId}");
            var query = Enumerable.Range(1, 25).Select(x => x.ToString());
            var obsQuery = query.ToObservable();
            obsQuery.Subscribe(ProcessNum, ImDone);
            Console.WriteLine("obs2");
           var obsQuery2 = query.ToObservable().ObserveOn(Scheduler.NewThread);// Don't know how to force new thread now.
            obsQuery2.Subscribe(ProcessNum, ImDone);
            Console.WriteLine("obs3");
            var obsQuer3 = query.ToObservable(Scheduler.NewThread);// Don't know how to force new thread now.
            obsQuer3.Subscribe(ProcessNum, ImDone);
            Console.WriteLine($"finishing my thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static void ProcessNum(string num)
        {
            Console.WriteLine($"{num} {Thread.CurrentThread.ManagedThreadId}");
        }

        static void ImDone()
        {
            Console.WriteLine($"Done baby! {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
