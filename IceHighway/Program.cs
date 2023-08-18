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
            Calculation test = new Calculation(0, 0, -5, 5, true);
            V2d c0 = test.getCoordinate(1);
            Debug.WriteLine(c0.x + ", " + c0.z);
            V2d c1 = test.getCoordinate(3);
            Debug.WriteLine(c1.x + ", " + c1.z);
            V2d c2 = test.getCoordinate(5);
            Debug.WriteLine(c2.x + ", " + c2.z);
            V2d c3 = test.getCoordinate(9);
            Debug.WriteLine(c3.x + ", " + c3.z);
        }
    }
}