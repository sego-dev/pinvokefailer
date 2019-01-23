using System;
using System.Collections.Generic;
using System.Linq;
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
            if (GetBool()) return 2;
            if (SetVolumeLabel("XYZ:\\", "My Imaginary Drive "))
                return 1;
            return 0;
        }
    }
}
