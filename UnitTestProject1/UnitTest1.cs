﻿using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using NUnit.Framework;
using PInvokeFailer;
using TypeMock.ArrangeActAssert;

namespace UnitTestProject1
{
    [TestFixture]
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

       // [Test]
        public void TestViewer()
        {
            var fake = Isolate.Fake.NextInstance<UnderTest>();
            
            var underTest = new UnderTest();
            Isolate.WhenCalled(() => fake.GetBool()).WillReturn(true);

            Assert.IsTrue(underTest.GetBool());
        }

        //[Test]
        public void TestMethodGetIl()
        {
            var t = typeof(UnitTest1).GetMethod("ShouldBeFailedWithDotCover");
            var aaa = t.GetMethodBody().GetILAsByteArray();
            int a = 0;
            foreach (var b in aaa)
            {
                Console.WriteLine(a + " " + b + " " + b.ToString("X") + " || " + ((OpCodeValues)b).ToString());
                if ((OpCodeValues)b == OpCodeValues.Call)
                {
                    try
                    {
                        Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                            .ResolveMember(BitConverter.ToInt32(new byte[] { aaa[a + 1], aaa[a + 2], aaa[a + 3], aaa[a + 4] }, 0)));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Is not a call");
                    }
                }
                a++;
            }
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

            MethodInfo methodInfo = ttt.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)[0];
            var aaa = methodInfo.GetMethodBody()
                .GetILAsByteArray();

            var bbb = methodInfo.GetMethodBody().LocalVariables;
            foreach (var localVariableInfo in bbb)
            {
                Console.WriteLine(localVariableInfo);
            }
            Console.WriteLine(methodInfo.Name);

            int a = 0;
            foreach (var b in aaa)
            {
                Console.WriteLine(a + " " + b + " " + b.ToString("X") + " || " + ((OpCodeValues)b).ToString());
                if ((OpCodeValues) b == OpCodeValues.Call)
                {
                    try
                    {
                        Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                            .ResolveMember(BitConverter.ToInt32(new byte[] { aaa[a + 1], aaa[a + 2], aaa[a + 3], aaa[a + 4] }, 0)));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Is not a call");
                    }
                }
                a++;
            }

            var m = ttt.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (var meth in m)
            {
                Console.WriteLine(meth.Name);

            }

        }


        //[Test]
        public void ShouldBeFailed()
        {

            try
            {
                Console.WriteLine("new byte[] { 0, 0, 112, 114 }=>");  
                Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                    .ResolveMember(BitConverter.ToInt32(new byte[] { 0, 0, 112, 114 }, 0)));
            }
            catch (Exception)
            {
                Console.WriteLine("new byte[] { 0, 0, 112, 114 }");
                
            }

            try
            {
                Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                    .ResolveMember(BitConverter.ToInt32(new byte[] { 47, 0, 0, 10 }, 0)));
            }
            catch
            {
                Console.WriteLine("new byte[] { 49, 0, 0, 10 }");
            }

            try
            {
                Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                    .ResolveMember(BitConverter.ToInt32(new byte[] { 47, 0, 0, 10 }, 0)));
            }
            catch
            {
                Console.WriteLine("new byte[] { 47, 0, 0, 10 }");
            }

            try
            {
                Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                    .ResolveMember(BitConverter.ToInt32(new byte[] { 50, 0, 0, 10 }, 0)));
            }
            catch
            {
                Console.WriteLine("new byte[] { 50, 0, 0, 10 }");
            }

            try
            {
                Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                    .ResolveMember(BitConverter.ToInt32(new byte[] { 51, 0, 0, 10 }, 0)));
            }
            catch
            {
                Console.WriteLine("new byte[] { 51, 0, 0, 10 }");
            }

            try
            {
                Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                    .ResolveMember(BitConverter.ToInt32(new byte[] { 52, 0, 0, 10 }, 0)));
            }
            catch
            {
                Console.WriteLine("new byte[] { 52, 0, 0, 10 }");
            }

            try
            {
                Console.WriteLine(Assembly.GetExecutingAssembly().Modules.First()
                    .ResolveMember(BitConverter.ToInt32(new byte[] { 44, 0, 0, 10 }, 0)));
            }
            catch
            {
                Console.WriteLine("new byte[] { 44, 0, 0, 10 }");
            }

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

        //[Test]
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

    public class UnderTest
    {
        public bool GetBool()
        {
            return false;
        }

        public int GetInt()
        {
            return 0;
        }
    }

    internal enum OpCodeValues
    {
        Nop = 0,
        Break = 1,
        Ldarg_0 = 2,
        Ldarg_1 = 3,
        Ldarg_2 = 4,
        Ldarg_3 = 5,
        Ldloc_0 = 6,
        Ldloc_1 = 7,
        Ldloc_2 = 8,
        Ldloc_3 = 9,
        Stloc_0 = 10, // 0x0000000A
        Stloc_1 = 11, // 0x0000000B
        Stloc_2 = 12, // 0x0000000C
        Stloc_3 = 13, // 0x0000000D
        Ldarg_S = 14, // 0x0000000E
        Ldarga_S = 15, // 0x0000000F
        Starg_S = 16, // 0x00000010
        Ldloc_S = 17, // 0x00000011
        Ldloca_S = 18, // 0x00000012
        Stloc_S = 19, // 0x00000013
        Ldnull = 20, // 0x00000014
        Ldc_I4_M1 = 21, // 0x00000015
        Ldc_I4_0 = 22, // 0x00000016
        Ldc_I4_1 = 23, // 0x00000017
        Ldc_I4_2 = 24, // 0x00000018
        Ldc_I4_3 = 25, // 0x00000019
        Ldc_I4_4 = 26, // 0x0000001A
        Ldc_I4_5 = 27, // 0x0000001B
        Ldc_I4_6 = 28, // 0x0000001C
        Ldc_I4_7 = 29, // 0x0000001D
        Ldc_I4_8 = 30, // 0x0000001E
        Ldc_I4_S = 31, // 0x0000001F
        Ldc_I4 = 32, // 0x00000020
        Ldc_I8 = 33, // 0x00000021
        Ldc_R4 = 34, // 0x00000022
        Ldc_R8 = 35, // 0x00000023
        Dup = 37, // 0x00000025
        Pop = 38, // 0x00000026
        Jmp = 39, // 0x00000027
        Call = 40, // 0x00000028
        Calli = 41, // 0x00000029
        Ret = 42, // 0x0000002A
        Br_S = 43, // 0x0000002B
        Brfalse_S = 44, // 0x0000002C
        Brtrue_S = 45, // 0x0000002D
        Beq_S = 46, // 0x0000002E
        Bge_S = 47, // 0x0000002F
        Bgt_S = 48, // 0x00000030
        Ble_S = 49, // 0x00000031
        Blt_S = 50, // 0x00000032
        Bne_Un_S = 51, // 0x00000033
        Bge_Un_S = 52, // 0x00000034
        Bgt_Un_S = 53, // 0x00000035
        Ble_Un_S = 54, // 0x00000036
        Blt_Un_S = 55, // 0x00000037
        Br = 56, // 0x00000038
        Brfalse = 57, // 0x00000039
        Brtrue = 58, // 0x0000003A
        Beq = 59, // 0x0000003B
        Bge = 60, // 0x0000003C
        Bgt = 61, // 0x0000003D
        Ble = 62, // 0x0000003E
        Blt = 63, // 0x0000003F
        Bne_Un = 64, // 0x00000040
        Bge_Un = 65, // 0x00000041
        Bgt_Un = 66, // 0x00000042
        Ble_Un = 67, // 0x00000043
        Blt_Un = 68, // 0x00000044
        Switch = 69, // 0x00000045
        Ldind_I1 = 70, // 0x00000046
        Ldind_U1 = 71, // 0x00000047
        Ldind_I2 = 72, // 0x00000048
        Ldind_U2 = 73, // 0x00000049
        Ldind_I4 = 74, // 0x0000004A
        Ldind_U4 = 75, // 0x0000004B
        Ldind_I8 = 76, // 0x0000004C
        Ldind_I = 77, // 0x0000004D
        Ldind_R4 = 78, // 0x0000004E
        Ldind_R8 = 79, // 0x0000004F
        Ldind_Ref = 80, // 0x00000050
        Stind_Ref = 81, // 0x00000051
        Stind_I1 = 82, // 0x00000052
        Stind_I2 = 83, // 0x00000053
        Stind_I4 = 84, // 0x00000054
        Stind_I8 = 85, // 0x00000055
        Stind_R4 = 86, // 0x00000056
        Stind_R8 = 87, // 0x00000057
        Add = 88, // 0x00000058
        Sub = 89, // 0x00000059
        Mul = 90, // 0x0000005A
        Div = 91, // 0x0000005B
        Div_Un = 92, // 0x0000005C
        Rem = 93, // 0x0000005D
        Rem_Un = 94, // 0x0000005E
        And = 95, // 0x0000005F
        Or = 96, // 0x00000060
        Xor = 97, // 0x00000061
        Shl = 98, // 0x00000062
        Shr = 99, // 0x00000063
        Shr_Un = 100, // 0x00000064
        Neg = 101, // 0x00000065
        Not = 102, // 0x00000066
        Conv_I1 = 103, // 0x00000067
        Conv_I2 = 104, // 0x00000068
        Conv_I4 = 105, // 0x00000069
        Conv_I8 = 106, // 0x0000006A
        Conv_R4 = 107, // 0x0000006B
        Conv_R8 = 108, // 0x0000006C
        Conv_U4 = 109, // 0x0000006D
        Conv_U8 = 110, // 0x0000006E
        Callvirt = 111, // 0x0000006F
        Cpobj = 112, // 0x00000070
        Ldobj = 113, // 0x00000071
        Ldstr = 114, // 0x00000072
        Newobj = 115, // 0x00000073
        Castclass = 116, // 0x00000074
        Isinst = 117, // 0x00000075
        Conv_R_Un = 118, // 0x00000076
        Unbox = 121, // 0x00000079
        Throw = 122, // 0x0000007A
        Ldfld = 123, // 0x0000007B
        Ldflda = 124, // 0x0000007C
        Stfld = 125, // 0x0000007D
        Ldsfld = 126, // 0x0000007E
        Ldsflda = 127, // 0x0000007F
        Stsfld = 128, // 0x00000080
        Stobj = 129, // 0x00000081
        Conv_Ovf_I1_Un = 130, // 0x00000082
        Conv_Ovf_I2_Un = 131, // 0x00000083
        Conv_Ovf_I4_Un = 132, // 0x00000084
        Conv_Ovf_I8_Un = 133, // 0x00000085
        Conv_Ovf_U1_Un = 134, // 0x00000086
        Conv_Ovf_U2_Un = 135, // 0x00000087
        Conv_Ovf_U4_Un = 136, // 0x00000088
        Conv_Ovf_U8_Un = 137, // 0x00000089
        Conv_Ovf_I_Un = 138, // 0x0000008A
        Conv_Ovf_U_Un = 139, // 0x0000008B
        Box = 140, // 0x0000008C
        Newarr = 141, // 0x0000008D
        Ldlen = 142, // 0x0000008E
        Ldelema = 143, // 0x0000008F
        Ldelem_I1 = 144, // 0x00000090
        Ldelem_U1 = 145, // 0x00000091
        Ldelem_I2 = 146, // 0x00000092
        Ldelem_U2 = 147, // 0x00000093
        Ldelem_I4 = 148, // 0x00000094
        Ldelem_U4 = 149, // 0x00000095
        Ldelem_I8 = 150, // 0x00000096
        Ldelem_I = 151, // 0x00000097
        Ldelem_R4 = 152, // 0x00000098
        Ldelem_R8 = 153, // 0x00000099
        Ldelem_Ref = 154, // 0x0000009A
        Stelem_I = 155, // 0x0000009B
        Stelem_I1 = 156, // 0x0000009C
        Stelem_I2 = 157, // 0x0000009D
        Stelem_I4 = 158, // 0x0000009E
        Stelem_I8 = 159, // 0x0000009F
        Stelem_R4 = 160, // 0x000000A0
        Stelem_R8 = 161, // 0x000000A1
        Stelem_Ref = 162, // 0x000000A2
        Ldelem = 163, // 0x000000A3
        Stelem = 164, // 0x000000A4
        Unbox_Any = 165, // 0x000000A5
        Conv_Ovf_I1 = 179, // 0x000000B3
        Conv_Ovf_U1 = 180, // 0x000000B4
        Conv_Ovf_I2 = 181, // 0x000000B5
        Conv_Ovf_U2 = 182, // 0x000000B6
        Conv_Ovf_I4 = 183, // 0x000000B7
        Conv_Ovf_U4 = 184, // 0x000000B8
        Conv_Ovf_I8 = 185, // 0x000000B9
        Conv_Ovf_U8 = 186, // 0x000000BA
        Refanyval = 194, // 0x000000C2
        Ckfinite = 195, // 0x000000C3
        Mkrefany = 198, // 0x000000C6
        Ldtoken = 208, // 0x000000D0
        Conv_U2 = 209, // 0x000000D1
        Conv_U1 = 210, // 0x000000D2
        Conv_I = 211, // 0x000000D3
        Conv_Ovf_I = 212, // 0x000000D4
        Conv_Ovf_U = 213, // 0x000000D5
        Add_Ovf = 214, // 0x000000D6
        Add_Ovf_Un = 215, // 0x000000D7
        Mul_Ovf = 216, // 0x000000D8
        Mul_Ovf_Un = 217, // 0x000000D9
        Sub_Ovf = 218, // 0x000000DA
        Sub_Ovf_Un = 219, // 0x000000DB
        Endfinally = 220, // 0x000000DC
        Leave = 221, // 0x000000DD
        Leave_S = 222, // 0x000000DE
        Stind_I = 223, // 0x000000DF
        Conv_U = 224, // 0x000000E0
        Prefix7 = 248, // 0x000000F8
        Prefix6 = 249, // 0x000000F9
        Prefix5 = 250, // 0x000000FA
        Prefix4 = 251, // 0x000000FB
        Prefix3 = 252, // 0x000000FC
        Prefix2 = 253, // 0x000000FD
        Prefix1 = 254, // 0x000000FE
        Prefixref = 255, // 0x000000FF
        Arglist = 65024, // 0x0000FE00
        Ceq = 65025, // 0x0000FE01
        Cgt = 65026, // 0x0000FE02
        Cgt_Un = 65027, // 0x0000FE03
        Clt = 65028, // 0x0000FE04
        Clt_Un = 65029, // 0x0000FE05
        Ldftn = 65030, // 0x0000FE06
        Ldvirtftn = 65031, // 0x0000FE07
        Ldarg = 65033, // 0x0000FE09
        Ldarga = 65034, // 0x0000FE0A
        Starg = 65035, // 0x0000FE0B
        Ldloc = 65036, // 0x0000FE0C
        Ldloca = 65037, // 0x0000FE0D
        Stloc = 65038, // 0x0000FE0E
        Localloc = 65039, // 0x0000FE0F
        Endfilter = 65041, // 0x0000FE11
        Unaligned_ = 65042, // 0x0000FE12
        Volatile_ = 65043, // 0x0000FE13
        Tail_ = 65044, // 0x0000FE14
        Initobj = 65045, // 0x0000FE15
        Constrained_ = 65046, // 0x0000FE16
        Cpblk = 65047, // 0x0000FE17
        Initblk = 65048, // 0x0000FE18
        Rethrow = 65050, // 0x0000FE1A
        Sizeof = 65052, // 0x0000FE1C
        Refanytype = 65053, // 0x0000FE1D
        Readonly_ = 65054, // 0x0000FE1E
    }
}
