namespace Ice_Highway_Helper.IceHighway
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            box_beginLocation = new GroupBox();
            text_beginZ = new TextBox();
            label2 = new Label();
            text_beginX = new TextBox();
            label1 = new Label();
            box_endLocation = new GroupBox();
            text_endZ = new TextBox();
            text_endX = new TextBox();
            label4 = new Label();
            label3 = new Label();
            box_set = new GroupBox();
            label_angle_2 = new Label();
            label_angle_1 = new Label();
            label_crossPosition = new Label();
            button2 = new Button();
            label_endPosition = new Label();
            label_angle = new Label();
            label_deviation = new Label();
            button1 = new Button();
            label_interval = new Label();
            comboBox3 = new ComboBox();
            checkBox1 = new CheckBox();
            text_buttonBlock = new TextBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            text_iceBlock = new TextBox();
            label_buttonBlock = new Label();
            label_iceBlock = new Label();
            button_about = new Button();
            button_language = new Button();
            button_saveLitematic = new Button();
            box_beginLocation.SuspendLayout();
            box_endLocation.SuspendLayout();
            box_set.SuspendLayout();
            SuspendLayout();
            // 
            // box_beginLocation
            // 
            box_beginLocation.Controls.Add(text_beginZ);
            box_beginLocation.Controls.Add(label2);
            box_beginLocation.Controls.Add(text_beginX);
            box_beginLocation.Controls.Add(label1);
            box_beginLocation.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            box_beginLocation.Location = new Point(12, 12);
            box_beginLocation.Name = "box_beginLocation";
            box_beginLocation.Size = new Size(240, 146);
            box_beginLocation.TabIndex = 0;
            box_beginLocation.TabStop = false;
            box_beginLocation.Text = "起始位置";
            // 
            // text_beginZ
            // 
            text_beginZ.Location = new Point(69, 95);
            text_beginZ.Name = "text_beginZ";
            text_beginZ.Size = new Size(165, 45);
            text_beginZ.TabIndex = 2;
            text_beginZ.TextChanged += text_beginZ_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 98);
            label2.Name = "label2";
            label2.Size = new Size(57, 38);
            label2.TabIndex = 2;
            label2.Text = "z =";
            // 
            // text_beginX
            // 
            text_beginX.Location = new Point(69, 44);
            text_beginX.Name = "text_beginX";
            text_beginX.Size = new Size(165, 45);
            text_beginX.TabIndex = 1;
            text_beginX.TextChanged += text_beginX_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 47);
            label1.Name = "label1";
            label1.Size = new Size(57, 38);
            label1.TabIndex = 0;
            label1.Text = "x =";
            // 
            // box_endLocation
            // 
            box_endLocation.Controls.Add(text_endZ);
            box_endLocation.Controls.Add(text_endX);
            box_endLocation.Controls.Add(label4);
            box_endLocation.Controls.Add(label3);
            box_endLocation.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            box_endLocation.Location = new Point(12, 164);
            box_endLocation.Name = "box_endLocation";
            box_endLocation.Size = new Size(240, 146);
            box_endLocation.TabIndex = 1;
            box_endLocation.TabStop = false;
            box_endLocation.Text = "终点位置";
            // 
            // text_endZ
            // 
            text_endZ.Location = new Point(69, 95);
            text_endZ.Name = "text_endZ";
            text_endZ.Size = new Size(165, 45);
            text_endZ.TabIndex = 4;
            text_endZ.TextChanged += text_endZ_TextChanged;
            // 
            // text_endX
            // 
            text_endX.Location = new Point(69, 44);
            text_endX.Name = "text_endX";
            text_endX.Size = new Size(165, 45);
            text_endX.TabIndex = 3;
            text_endX.TextChanged += text_endX_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 98);
            label4.Name = "label4";
            label4.Size = new Size(57, 38);
            label4.TabIndex = 1;
            label4.Text = "z =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 47);
            label3.Name = "label3";
            label3.Size = new Size(57, 38);
            label3.TabIndex = 0;
            label3.Text = "x =";
            // 
            // box_set
            // 
            box_set.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            box_set.Controls.Add(label_angle_2);
            box_set.Controls.Add(label_angle_1);
            box_set.Controls.Add(label_crossPosition);
            box_set.Controls.Add(button2);
            box_set.Controls.Add(label_endPosition);
            box_set.Controls.Add(label_angle);
            box_set.Controls.Add(label_deviation);
            box_set.Controls.Add(button1);
            box_set.Controls.Add(label_interval);
            box_set.Controls.Add(comboBox3);
            box_set.Controls.Add(checkBox1);
            box_set.Controls.Add(text_buttonBlock);
            box_set.Controls.Add(comboBox2);
            box_set.Controls.Add(comboBox1);
            box_set.Controls.Add(text_iceBlock);
            box_set.Controls.Add(label_buttonBlock);
            box_set.Controls.Add(label_iceBlock);
            box_set.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            box_set.Location = new Point(258, 12);
            box_set.Name = "box_set";
            box_set.Size = new Size(600, 670);
            box_set.TabIndex = 2;
            box_set.TabStop = false;
            box_set.Text = "设置";
            // 
            // label_angle_2
            // 
            label_angle_2.AutoSize = true;
            label_angle_2.Location = new Point(6, 629);
            label_angle_2.Name = "label_angle_2";
            label_angle_2.Size = new Size(177, 38);
            label_angle_2.TabIndex = 16;
            label_angle_2.Text = "第2段角度：";
            // 
            // label_angle_1
            // 
            label_angle_1.AutoSize = true;
            label_angle_1.Location = new Point(6, 591);
            label_angle_1.Name = "label_angle_1";
            label_angle_1.Size = new Size(177, 38);
            label_angle_1.TabIndex = 15;
            label_angle_1.Text = "第1段角度：";
            // 
            // label_crossPosition
            // 
            label_crossPosition.AutoSize = true;
            label_crossPosition.Location = new Point(6, 553);
            label_crossPosition.Name = "label_crossPosition";
            label_crossPosition.Size = new Size(162, 38);
            label_crossPosition.TabIndex = 14;
            label_crossPosition.Text = "交点坐标：";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button2.Enabled = false;
            button2.Location = new Point(6, 504);
            button2.Name = "button2";
            button2.Size = new Size(588, 46);
            button2.TabIndex = 12;
            button2.Text = "生成分段式冰道";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label_endPosition
            // 
            label_endPosition.AutoSize = true;
            label_endPosition.Location = new Point(6, 463);
            label_endPosition.Name = "label_endPosition";
            label_endPosition.Size = new Size(162, 38);
            label_endPosition.TabIndex = 12;
            label_endPosition.Text = "终点坐标：";
            // 
            // label_angle
            // 
            label_angle.AutoSize = true;
            label_angle.Location = new Point(6, 425);
            label_angle.Name = "label_angle";
            label_angle.Size = new Size(104, 38);
            label_angle.TabIndex = 11;
            label_angle.Text = "角度：";
            // 
            // label_deviation
            // 
            label_deviation.AutoSize = true;
            label_deviation.Location = new Point(6, 387);
            label_deviation.Name = "label_deviation";
            label_deviation.Size = new Size(104, 38);
            label_deviation.TabIndex = 10;
            label_deviation.Text = "偏差：";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(6, 338);
            button1.Name = "button1";
            button1.Size = new Size(588, 46);
            button1.TabIndex = 11;
            button1.Text = "生成冰道";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label_interval
            // 
            label_interval.AutoSize = true;
            label_interval.Location = new Point(6, 241);
            label_interval.Name = "label_interval";
            label_interval.Size = new Size(133, 38);
            label_interval.TabIndex = 8;
            label_interval.Text = "方块间隔";
            // 
            // comboBox3
            // 
            comboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "0", "1" });
            comboBox3.Location = new Point(354, 238);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(240, 46);
            comboBox3.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(6, 290);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(377, 42);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "整数倍角度限制 (1.40625°)";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // text_buttonBlock
            // 
            text_buttonBlock.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            text_buttonBlock.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            text_buttonBlock.Location = new Point(6, 193);
            text_buttonBlock.Name = "text_buttonBlock";
            text_buttonBlock.ReadOnly = true;
            text_buttonBlock.Size = new Size(588, 39);
            text_buttonBlock.TabIndex = 8;
            text_buttonBlock.Text = "blockname[name0=value0,name1=value1]";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] 
            { 
                "石头按钮", "磨制黑石按钮", "石头压力板", "磨制黑石压力板", 
                "橡木按钮", "云杉木按钮", "白桦木按钮", "从林木按钮", "金合欢木按钮", "深色橡木按钮", 
                "红树木按钮", "樱花木按钮", "竹按钮", "绯红木按钮", "诡异木按钮",
                "橡木压力板", "云杉木压力板", "白桦木压力板", "从林木压力板", "金合欢木压力板", "深色橡木压力板",
                "红树木压力板", "樱花木压力板", "竹压力板", "绯红木压力板", "诡异木压力板",
                "<自定义>" 
            });
            comboBox2.Location = new Point(354, 141);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(240, 46);
            comboBox2.TabIndex = 7;
            comboBox2.IntegralHeight = false;
            comboBox2.MaxDropDownItems = 8;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "蓝冰", "浮冰", "冰", "<自定义>" });
            comboBox1.Location = new Point(354, 44);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(240, 46);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // text_iceBlock
            // 
            text_iceBlock.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            text_iceBlock.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            text_iceBlock.Location = new Point(6, 96);
            text_iceBlock.Name = "text_iceBlock";
            text_iceBlock.ReadOnly = true;
            text_iceBlock.Size = new Size(588, 39);
            text_iceBlock.TabIndex = 6;
            text_iceBlock.Text = "blockname[name0=value0,name1=value1]";
            // 
            // label_buttonBlock
            // 
            label_buttonBlock.AutoSize = true;
            label_buttonBlock.Location = new Point(6, 144);
            label_buttonBlock.Name = "label_buttonBlock";
            label_buttonBlock.Size = new Size(162, 38);
            label_buttonBlock.TabIndex = 1;
            label_buttonBlock.Text = "防刷怪方块";
            // 
            // label_iceBlock
            // 
            label_iceBlock.AutoSize = true;
            label_iceBlock.Location = new Point(6, 47);
            label_iceBlock.Name = "label_iceBlock";
            label_iceBlock.Size = new Size(133, 38);
            label_iceBlock.TabIndex = 0;
            label_iceBlock.Text = "冰块方块";
            // 
            // button_about
            // 
            button_about.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_about.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button_about.Location = new Point(12, 622);
            button_about.Name = "button_about";
            button_about.Size = new Size(240, 60);
            button_about.TabIndex = 15;
            button_about.Text = "关于";
            button_about.UseVisualStyleBackColor = true;
            button_about.Click += button_about_Click;
            // 
            // button_language
            // 
            button_language.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_language.Enabled = false;
            button_language.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button_language.Location = new Point(12, 556);
            button_language.Name = "button_language";
            button_language.Size = new Size(240, 60);
            button_language.TabIndex = 14;
            button_language.Text = "Language";
            button_language.UseVisualStyleBackColor = true;
            button_language.Visible = false;
            // 
            // button_saveLitematic
            // 
            button_saveLitematic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_saveLitematic.Enabled = false;
            button_saveLitematic.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button_saveLitematic.Location = new Point(12, 316);
            button_saveLitematic.Name = "button_saveLitematic";
            button_saveLitematic.Size = new Size(240, 234);
            button_saveLitematic.TabIndex = 13;
            button_saveLitematic.Text = "保存投影";
            button_saveLitematic.UseVisualStyleBackColor = true;
            button_saveLitematic.Click += button_saveLitematic_Click;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 694);
            Controls.Add(button_saveLitematic);
            Controls.Add(button_language);
            Controls.Add(button_about);
            Controls.Add(box_set);
            Controls.Add(box_endLocation);
            Controls.Add(box_beginLocation);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form";
            Text = "冰道助手";
            box_beginLocation.ResumeLayout(false);
            box_beginLocation.PerformLayout();
            box_endLocation.ResumeLayout(false);
            box_endLocation.PerformLayout();
            box_set.ResumeLayout(false);
            box_set.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox box_beginLocation;
        private Label label1;
        private TextBox text_beginZ;
        private Label label2;
        private TextBox text_beginX;
        private GroupBox box_endLocation;
        private Label label4;
        private Label label3;
        private GroupBox box_set;
        private Label label_iceBlock;
        private TextBox text_iceBlock;
        private Label label_buttonBlock;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private TextBox text_buttonBlock;
        private CheckBox checkBox1;
        private Label label_interval;
        private ComboBox comboBox3;
        private Button button1;
        private Label label_deviation;
        private Label label_angle;
        private Label label_angle_2;
        private Label label_angle_1;
        private Label label_crossPosition;
        private Button button2;
        private Label label_endPosition;
        private TextBox text_endX;
        private TextBox text_endZ;
        private Button button_about;
        private Button button_language;
        private Button button_saveLitematic;
    }
}