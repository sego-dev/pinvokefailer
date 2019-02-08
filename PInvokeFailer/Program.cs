using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PInvokeFailer
{
    public class ForceFailure
    {
        [DllImport("kernel32.dll")]
        static extern uint GetLastError();
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetVolumeLabel(string lpRootPathName, string lpVolumeName);

        public static bool GetBool()
        {
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool GetBool1() => true;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool GetBool2() => true;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool GetBool3() => true;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool GetBool4() => true;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool GetBool5() => true;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool GetBool6() => true;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool GetBool7() => true;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool GetBool8() => true;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool GetBool9() => true;




        public static void Main()
        {
            if (SetVolumeLabel("XYZ:\\", "My Imaginary Drive "))
                System.Console.WriteLine("It worked???");
            else
            {
                // the first last error check is fine here:
                System.Console.WriteLine(GetLastError());
                System.Console.WriteLine(Marshal.GetLastWin32Error());
                if (GetBool())
                {
                    System.Console.WriteLine("It works");
                }
            }

            Console.ReadLine();
        }

        public static int CallMe()
        {
            if (!GetBool1()) return 2;
            if (!GetBool2()) return 2;
            if (!GetBool3()) return 2;
            if (!GetBool4()) return 2;
            if (!GetBool5()) return 2;
            if (!GetBool6()) return 2;
            if (!GetBool7()) return 2;
            if (!GetBool8()) return 2;
            if (!GetBool9()) return 2;
            if (GetBool()) return 2;
            if (SetVolumeLabel("XYZ:\\", "My Imaginary Drive "))
                return 1;
            return 0;
        }
    }
}
