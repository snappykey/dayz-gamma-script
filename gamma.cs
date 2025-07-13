using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace dayz_gamma_script
{
    public class gamma
    {
        [DllImport("gdi32.dll")]
        static extern bool SetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct RAMP
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public ushort[] Red, Green, Blue;
        }

        private static double gammar = 1;

        public void increaseGammar(double num)
        {
            if (gammar < 2.1)
            {
                gammar = gammar + num;
            }

            setGamma();
        }

        public void decreaseGammar(double num)
        {
            if (gammar > 0.5)
            {
                gammar = gammar - num;
            }

            setGamma();
        }
        public void setGammar()
        {
            gammar = 1;

            setGamma();
        }

        public static void setGamma()
        {
            var ramp = new RAMP
            {
                Red = new ushort[256],
                Green = new ushort[256],
                Blue = new ushort[256]
            };

            for (int i = 1; i < 256; i++)
                ramp.Red[i] =
                    ramp.Green[i] =
                        ramp.Blue[i] = (ushort)Math.Min(65535, i * 256 * gammar);
            SetDeviceGammaRamp(Graphics.FromHwnd(IntPtr.Zero).GetHdc(), ref ramp);
            Console.WriteLine(gammar);
            // Thread.Sleep(1);
        }
    }
}