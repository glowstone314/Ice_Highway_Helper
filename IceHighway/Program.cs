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
            Debug.WriteLine(LiteRegion.getLongFromBitList(new bool[]{ 
                true, false, false, false, false, false, false, false,
                true, false, false, false, false, false, false, false,
                true, false, false, false, false, false, false, false,
                true, false, false, false, false, false, false, false,
                true, false, false, false, false, false, false, false,
                true, false, false, false, false, false, false, false,
                true, false, false, false, false, false, false, false,
                true, false, false, false, false, false, false, true
            }));
        }
    }
}