using SharpNBT;
using System.Diagnostics;

namespace Ice_Highway_Helper.IceHighway
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form());
            double x0 = 0, z0 = 2, x1 = 4, z1 = -4;
            double rad = Math.Atan2(z1 - z0, x1 - x0);
            double distance = 5;
            double x = x0 + distance * Math.Cos(rad);
            double z = z0 + distance * Math.Sin(rad);
            Debug.WriteLine("x = " + x);
            Debug.WriteLine("z = " + z);
        }
    }
}