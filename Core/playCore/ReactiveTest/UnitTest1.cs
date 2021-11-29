using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace ReactiveTest
{
    [TestClass]
    public class UnitTest1
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


        static void ImDone()
        {
            Console.WriteLine("Done baby!");
        }
    }
}
