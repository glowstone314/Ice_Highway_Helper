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
            Application.Run(new Form());
            /*int begX = -5;
            int begZ = 9;
            int endX = 70;
            int endZ = 405;
            IceHighway ice = new IceHighway("±˘µ¿÷˙ ÷≤‚ ‘", "", "Ice_Highway_Helper");
            ice.BuildSegmentedly(1, new Block("blue_ice"), 
                    new Block("polished_blackstone_button[face=floor,facing,north,powered=false]"), 
                    new Calculation(begX, begZ, endX, endZ, false), new Block("smooth_stone"), 
                    new Block("stone_brick_slab[type=bottom,waterlogged=false]"));
            Litematic litematic = ice.GetLitematic(new V3d(begX, 0, begZ));
            CompoundTag tag = litematic.BuildLitematic();
            NbtFile.Write("D:\\Minecraft\\schematics\\±˘µ¿≤‚ ‘.litematic", tag, 
                    FormatOptions.Java, CompressionType.GZip, 
                    System.IO.Compression.CompressionLevel.Fastest);*/
        }
    }
}