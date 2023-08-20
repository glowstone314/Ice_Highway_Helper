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
            IceHighway ice = new IceHighway(-152, 253, -406, 116, true);
            ice.BuildLitematic("", "", "");
            D d = ice.build(1, new Block("blue_ice"), 
                null);
            Debug.WriteLine("偏移：" + d.deviation);
            Debug.WriteLine("角度：" + d.buildDeg);
            Debug.WriteLine("终点x坐标：" + d.endpoint.x);
            Debug.WriteLine("终点z坐标：" + d.endpoint.z);
            Litematic litematic = ice.GetLitematic();
            litematic.name = "冰道助手测试";
            litematic.author = "Ice_Highway_Helper";
            CompoundTag tag = litematic.BuildLitematic();
            NbtFile.Write("D:\\Minecraft\\schematics\\冰道测试.litematic", tag, 
                FormatOptions.Java, CompressionType.GZip, 
                System.IO.Compression.CompressionLevel.Fastest);
        }
    }
}