using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using PInvokeFailer;
using TypeMock.ArrangeActAssert;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Test]
        public void ShouldBeFailedWithDotCover()
        {
            Isolate.WhenCalled(() => ForceFailure.SetVolumeLabel("","")).WillReturn(true);
            var result = ForceFailure.CallMe();
            
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ShouldNotBeFailed()
        {
            //Array l = new int[]{1,2};
            Isolate.NonPublic.WhenCalled(typeof(ForceFailure), "SetVolumeLabel").WillReturn(true);
            Isolate.WhenCalled(() => ForceFailure.GetBool()).WillReturn(true);
            //Isolate.WhenCalled(() =>l.IsFixedSize).WillReturn(true);
            //ForceFailure.Main();  
            var result = ForceFailure.CallMe();


            Assert.AreEqual(2, result);


        }
        //[Test]
        public void TestMethod2()
        {
            var t = typeof(UnitTest1).GetNestedTypes(BindingFlags.NonPublic);

            //foreach (var tt in t)
            //{
            //    Console.WriteLine(tt.Name);

            //}

            var ttt = t.First();

            //MethodInfo methodInfo = ttt.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)[0];
            //var aaa = methodInfo.GetMethodBody()
            //    .GetILAsByteArray();
            //Console.WriteLine(methodInfo.Name);

            //int a = 0;
            //foreach (var b in aaa)
            //{

            //    Console.WriteLine(a+" "+b);
            //    a++;
            //}

            var m = ttt.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (var meth in m)
            {
                Console.WriteLine(meth.Name);

            }

        }

        //[Test]
        public void ShouldBeFailed()
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                .ResolveMember(BitConverter.ToInt32(new byte[] { 40, 0, 0, 10 }, 0)));
            Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                .ResolveMember(BitConverter.ToInt32(new byte[] { 44, 0, 0, 10 }, 0)));
            Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                .ResolveMember(BitConverter.ToInt32(new byte[] { 43, 0, 0, 10 }, 0)));

            Byte[] bb1 = {
                9,0,0,6
            };

            Byte[] bb2 = {
                10,0,0,6
            };

            Byte[] bb3 = {
                37,0,0,10
            };

            //int token = BitConverter.ToInt32(bb,0);
            int token2 = BitConverter.ToInt32(bb1, 0);
            int token3 = BitConverter.ToInt32(bb2, 0);
            int token4 = BitConverter.ToInt32(bb3, 0);
            


            //var m = Assembly.GetExecutingAssembly().Modules.First().ResolveMember(token);


            //Console.WriteLine(m.Name);
            Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First().ResolveMember(token2));
            Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First().ResolveMember(token3));
            Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First().ResolveMember(token4));

            //var t = typeof(UnitTest1);

            ////foreach (var tt in t)
            ////{
            ////    Console.WriteLine(tt.Name);

            ////}

            //var methodInfo = t.GetMethod("TestMethod1");

            //var aaa = methodInfo.GetMethodBody()
            //    .GetILAsByteArray();
            //Console.WriteLine(methodInfo.Name);

            //int a = 0;
            //foreach (var b in aaa)
            //{

            //    Console.WriteLine(a + " " + b);
            //    a++;
            //}

            //var m = ttt.GetMethods(BindingFlags.NonPublic);
            //foreach (var meth in m)
            //{
            //    Console.WriteLine(meth.Name);

            //}

        }

        [Test]
        public void WithoutCover()
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                .ResolveMember(BitConverter.ToInt32(new byte[] { 39, 0, 0, 10 }, 0)));

            Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                .ResolveMember(BitConverter.ToInt32(new byte[] { 43, 0, 0, 10 }, 0)));
            Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                .ResolveMember(BitConverter.ToInt32(new byte[] { 42, 0, 0, 10 }, 0)));
            Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                .ResolveMember(BitConverter.ToInt32(new byte[] { 37, 0, 0, 10 }, 0)));
        }
    }
}
