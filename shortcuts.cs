using dayz_gamma_script;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace dayz_gamma_script
{
    public class shortcuts
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        public void detectKeyPress()
        {
            while (true)
            {
                if (GetAsyncKeyState(0x11) < 0)
                {
                    if (GetAsyncKeyState(0x25) < 0)
                    {
                        new gamma().increaseGammar(0.1);
                    }
                    else if (GetAsyncKeyState(0x27) < 0)
                    {
                        new gamma().decreaseGammar(0.1);
                    }
                    else if (GetAsyncKeyState(0x26) < 0)
                    {
                        new gamma().setGammar();
                    }
                    else if (GetAsyncKeyState(0x71) < 0)
                    {
                        Console.Beep();
                        Console.Beep();
                        Environment.Exit(1);
                    }
                }
                Thread.Sleep(25);

            }
        }
    }
}