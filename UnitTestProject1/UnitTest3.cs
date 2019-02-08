using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using NUnit.Framework;
using TypeMock;
using TypeMock.ArrangeActAssert;


namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest3
    {
       
        [Test]
        public void TestMethod1()
        {
            BenchmarkRunner.Run<UnitTest3>();
        }

        [Benchmark]
        public void BenchmarksCall100()
        {
            Isolate.Fake.NextInstance<UnderTest>();
            var ut = new UnderTest();
            for (int i = 0; i < 20; i++)
            {
                ut.CallMe();
            }
        }

        //[Benchmark]
        public void BenchmarksCall1000()
        {
            Isolate.Fake.NextInstance<UnderTest>();
            var ut = new UnderTest();
            for (int i = 0; i < 1000; i++)
            {
                ut.CallMe();
            }
        }

        //[Benchmark]
        public void BenchmarksCall10000()
        {
            Isolate.Fake.NextInstance<UnderTest>();
            var ut = new UnderTest();
            for (int i = 0; i < 10000; i++)
            {
                ut.CallMe();
            }
        }

        //[Benchmark]
        public void BenchmarksCall100000()
        {
            Isolate.Fake.NextInstance<UnderTest>();
            var ut = new UnderTest();
            for (int i = 0; i < 100000; i++)
            {
                ut.CallMe();
            }
        }

        //[Benchmark]
        public void BenchmarksSafe()
        {
            
        }

        public class UnderTest
        {
            public int I { get; set; }  
            public void CallMe()
            {
                I = 4;
            }
        }
    }
}
