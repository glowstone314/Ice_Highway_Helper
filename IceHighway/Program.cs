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
            V2d v0 = new V2d(0, 0);
            V2d v1 = new V2d(0, 0);
            V2d v2 = new V2d(3, 2);
            Debug.WriteLine("v0 e v1" + v0.Equals(v1));
            Debug.WriteLine("v1 e v2" + v1.Equals(v2));
            Debug.WriteLine("v0 e v2" + v0.Equals(v2));
        }
    }
}