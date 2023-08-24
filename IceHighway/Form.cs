using SharpNBT;

namespace Ice_Highway_Helper.IceHighway
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private string text_beginX_text = "";
        private string text_beginZ_text = "";
        private string text_endX_text = "";
        private string text_endZ_text = "";

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void text_beginX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!text_beginX.Text.Equals("-") && !text_beginX.Text.Equals(""))
                    int.Parse(text_beginX.Text);
            }
            catch (Exception)
            {
                text_beginX.Text = text_beginX_text;
                text_beginX.SelectionStart = text_beginX.TextLength;
                return;
            }
            text_beginX_text = text_beginX.Text;
        }

        private void text_beginZ_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!text_beginZ.Text.Equals("-") && !text_beginZ.Text.Equals(""))
                    int.Parse(text_beginZ.Text);
            }
            catch (Exception)
            {
                text_beginZ.Text = text_beginZ_text;
                text_beginZ.SelectionStart = text_beginZ.TextLength;
                return;
            }
            text_beginZ_text = text_beginZ.Text;
        }

        private void text_endX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!text_endX.Text.Equals("-") && !text_endX.Text.Equals(""))
                    int.Parse(text_endX.Text);
            }
            catch (Exception)
            {
                text_endX.Text = text_endX_text;
                text_endX.SelectionStart = text_endX.TextLength;
                return;
            }
            text_endX_text = text_endX.Text;
        }

        private void text_endZ_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!text_endZ.Text.Equals("-") && !text_endZ.Text.Equals(""))
                    int.Parse(text_endZ.Text);
            }
            catch (Exception)
            {
                text_endZ.Text = text_endZ_text;
                text_endZ.SelectionStart = text_endZ.TextLength;
                return;
            }
            text_endZ_text = text_endZ.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("<自定义>"))
                text_iceBlock.ReadOnly = false;
            else
                text_iceBlock.ReadOnly = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.Equals("<自定义>"))
                text_buttonBlock.ReadOnly = false;
            else
                text_buttonBlock.ReadOnly = true;
        }

        private IceHighway iceHighway;
        int x0, z0, x1, z1;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_beginX.Text.Equals("") || text_beginX.Text.Equals("-"))
                {
                    x0 = 0;
                    text_beginX.Text = "0";
                }
                else x0 = int.Parse(text_beginX.Text);
                if (text_beginZ.Text.Equals("") || text_beginZ.Text.Equals("-"))
                {
                    z0 = 0;
                    text_beginZ.Text = "0";
                }
                else z0 = int.Parse(text_beginZ.Text);
                if (text_endX.Text.Equals("") || text_endX.Text.Equals("-"))
                {
                    x1 = 0;
                    text_endX.Text = "0";
                }
                else x1 = int.Parse(text_endX.Text);
                if (text_endZ.Text.Equals("") || text_endZ.Text.Equals("-"))
                {
                    z1 = 0;
                    text_endZ.Text = "0";
                }
                else z1 = int.Parse(text_endZ.Text);
            }
            catch
            {
                MessageBox.Show("输入坐标有误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Math.Abs(x0 - x1) + Math.Abs(z0 - z1) < 4)
            {
                MessageBox.Show("两地距离过短！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Math.Abs(x0) > 30000000 || Math.Abs(x1) > 30000000 
                    || Math.Abs(z0) > 30000000 || Math.Abs(z1) > 30000000)
            {
                MessageBox.Show("坐标超过限制：±30,000,000！", "警告", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            iceHighway = new IceHighway("冰道", "由冰道助手生成的冰道", "Ice_Highway_Helper");
            int interval = (comboBox3.SelectedIndex == 0 ? 1 : 2);
            Block ice = GetIceBlock();
            Block button = GetButtonBlock();
            HighwayInformation d = iceHighway.Build(interval, ice, button, new Calculation(x0, z0, x1, z1, checkBox1.Checked));

            label_deviation.Text = "偏差：" + d.deviation;
            label_angle.Text = "角度：" + Tools.GetMinecraftDeg(d.buildDeg) + "°，返程：" +
                Tools.GetMinecraftDeg(Tools.GetOppositeDeg(d.buildDeg)) + "°";
            label_endPosition.Text = "终点坐标：(" + d.endpoint.x + ", " + d.endpoint.z + ")";

            button2.Enabled = d.deviation > 4.0;
            button_saveLitematic.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iceHighway = new IceHighway("冰道", "由冰道助手生成的冰道", "Ice_Highway_Helper");
            int interval = (comboBox3.SelectedIndex == 0 ? 1 : 2);
            Block ice = GetIceBlock();
            Block button = GetButtonBlock();

            HighwayInformationSegmentedly d = iceHighway.BuildSegmentedly(interval, ice, button,
                    new Calculation(x0, z0, x1, z1, false), ice, button);

            label_crossPosition.Text = "交点坐标：(" + d.cross.x + ", " + d.cross.z + ")";
            label_angle_1.Text = "第1段角度：" + Tools.GetMinecraftDeg(d.angle0) + "°，返程：" + 
                Tools.GetMinecraftDeg(Tools.GetOppositeDeg(d.angle0)) + "°";
            label_angle_2.Text = "第2段角度：" + Tools.GetMinecraftDeg(Tools.GetOppositeDeg(d.angle1)) + 
                "°，返程：" + Tools.GetMinecraftDeg(d.angle1) + "°";
        }

        private void button_saveLitematic_Click(object sender, EventArgs e)
        {
            if (iceHighway != null)
            {
                Litematic litematic = iceHighway.GetLitematic(new V3d(x0, 0, z0));
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "保存投影";
                sfd.InitialDirectory = "c:/";
                sfd.Filter = "投影文件 | *.litematic";
                sfd.ShowDialog();
                string path = sfd.FileName;
                if (path == "") return;

                try
                {
                    NbtFile.Write(path, litematic.BuildLitematic(), FormatOptions.Java,
                            CompressionType.GZip, System.IO.Compression.CompressionLevel.Fastest);
                }
                catch (IOException ioe)
                {
                    MessageBox.Show("IO错误：\n" + ioe.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("未知的错误：\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Block GetIceBlock()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: return new Block("blue_ice");
                case 1: return new Block("packed_ice");
                case 2: return new Block("ice");
                default: return new Block(text_iceBlock.Text);
            }
        }

        private Block GetButtonBlock()
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0: return new Block("stone_button[face=floor,facing=north,powered=false]");
                case 1: return new Block("polished_blackstone_button[face=floor,facing=north,powered=false]");
                case 2: return new Block("stone_pressure_plate[powered=false]");
                case 3: return new Block("polished_blackstone_pressure_plate[powered=false]");
                case 4: return new Block("oak_button[face=floor,facing=north,powered=false]");
                case 5: return new Block("spruce_button[face=floor,facing=north,powered=false]");
                case 6: return new Block("birch_button[face=floor,facing=north,powered=false]");
                case 7: return new Block("jungle_button[face=floor,facing=north,powered=false]");
                case 8: return new Block("acacia_button[face=floor,facing=north,powered=false]");
                case 9: return new Block("dark_oak_button[face=floor,facing=north,powered=false]");
                case 10: return new Block("mangrove_button[face=floor,facing=north,powered=false]");
                case 11: return new Block("cherry_button[face=floor,facing=north,powered=false]");
                case 12: return new Block("bamboo_button[face=floor,facing=north,powered=false]");
                case 13: return new Block("crimson_button[face=floor,facing=north,powered=false]");
                case 14: return new Block("warped_button[face=floor,facing=north,powered=false]");
                case 15: return new Block("oak_pressure_plate[powered=false]");
                case 16: return new Block("spruce_pressure_plate[powered=false]");
                case 17: return new Block("birch_pressure_plate[powered=false]");
                case 18: return new Block("jungle_pressure_plate[powered=false]");
                case 19: return new Block("acacia_pressure_plate[powered=false]");
                case 20: return new Block("dark_oak_pressure_plate[powered=false]");
                case 21: return new Block("mangrove_pressure_plate[powered=false]");
                case 22: return new Block("cherry_pressure_plate[powered=false]");
                case 23: return new Block("bamboo_pressure_plate[powered=false]");
                case 24: return new Block("crimson_pressure_plate[powered=false]");
                case 25: return new Block("warped_pressure_plate[powered=false]");
                case 26: return null;
                default: return new Block(text_buttonBlock.Text);
            }
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            if ((int)MessageBox.Show(
                    "Ice_Highway_Helper 冰道助手\n" +
                    "Version 1.0.0\n" +
                    "by Glow_Creeper\n" +
                    "本软件免费开源，使用GPL 3.0开源协议\n\n" +
                    "打开github页面？",
                    "关于", MessageBoxButtons.YesNo, MessageBoxIcon.Information
            ) == 6)
            {
                System.Diagnostics.Process.Start("explorer", "https://github.com/glowstone314/Ice_Highway_Helper");
            }
        }
    }
}