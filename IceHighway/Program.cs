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
            Debug.WriteLine("ƫ�ƣ�" + d.deviation);
            Debug.WriteLine("�Ƕȣ�" + d.buildDeg);
            Debug.WriteLine("�յ�x���꣺" + d.endpoint.x);
            Debug.WriteLine("�յ�z���꣺" + d.endpoint.z);
            Litematic litematic = ice.GetLitematic();
            litematic.name = "�������ֲ���";
            litematic.author = "Ice_Highway_Helper";
            CompoundTag tag = litematic.BuildLitematic();
            NbtFile.Write("D:\\Minecraft\\schematics\\��������.litematic", tag, 
                FormatOptions.Java, CompressionType.GZip, 
                System.IO.Compression.CompressionLevel.Fastest);
        }
    }
}