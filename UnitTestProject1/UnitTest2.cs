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


namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest2
    {
        private readonly ConcurrentDictionary<string, bool> cncDictionary = new ConcurrentDictionary<string, bool>();
        private SafeDictionary<string, bool> safeDictionary = new SafeDictionary<string, bool>();
        [Test]
        public void TestMethod1()
        {
            BenchmarkRunner.Run<UnitTest2>();
        }

        [Benchmark]
        public void BenchmarksConcurrent()
        {
            Parallel.ForEach(Enumerable.Range(0, 500), (el) => { cncDictionary[el.ToString()] = true; });

            bool o;
            Parallel.ForEach(Enumerable.Range(0, 500), el =>
            {
                if (cncDictionary.ContainsKey(el.ToString()))
                {
                    o = cncDictionary[el.ToString()];
                }
            });
        }

        [Benchmark]
        public void BenchmarksSafe()
        {
            Parallel.ForEach(Enumerable.Range(0, 500), (el) => { safeDictionary[el.ToString()] = true; });

            bool o;
            Parallel.ForEach(Enumerable.Range(0, 500), el =>
            {
                if (safeDictionary.ContainsKey(el.ToString()))
                {
                    o = safeDictionary[el.ToString()];
                }
            });
        }
    }
}
