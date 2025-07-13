using System;
using System.Runtime.InteropServices;


namespace dayz_gamma_script
{
    static class Program
    {

        static void Main()
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
            gamma.setGamma();
            new shortcuts().detectKeyPress();
        }
    }

}