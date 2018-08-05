namespace AllHomeDBConfig
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_register_gateway = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.tb_db_filepath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_gwname = new System.Windows.Forms.TextBox();
            this.tb_gwid = new System.Windows.Forms.TextBox();
            this.btn_registe_gateway = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_aircon_lineshow = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cb_count_aircon = new System.Windows.Forms.ComboBox();
            this.cb_meter_jsy = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_ctrlpanel_heater_yilin = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_ctrlpanel_aircon_yilin = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_count_cp_aircon = new System.Windows.Forms.ComboBox();
            this.cb_count_cp_heater = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_vent_eavada_v1 = new System.Windows.Forms.CheckBox();
            this.cb_vent_eavada_v2 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_count_vent_v2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_count_vent_v1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_generate_db = new System.Windows.Forms.Button();
            this.btn_select_file = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox12.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 7;
            // 
            // btn_register_gateway
            // 
            this.btn_register_gateway.Location = new System.Drawing.Point(315, 36);
            this.btn_register_gateway.Name = "btn_register_gateway";
            this.btn_register_gateway.Size = new System.Drawing.Size(75, 23);
            this.btn_register_gateway.TabIndex = 12;
            this.btn_register_gateway.Text = "Go";
            this.btn_register_gateway.UseVisualStyleBackColor = true;
            this.btn_register_gateway.Click += new System.EventHandler(this.btn_register_gateway_Click);
            // 
            // tb_log
            // 
            this.tb_log.BackColor = System.Drawing.SystemColors.Window;
            this.tb_log.Location = new System.Drawing.Point(354, 172);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(471, 270);
            this.tb_log.TabIndex = 14;
            // 
            // tb_db_filepath
            // 
            this.tb_db_filepath.Location = new System.Drawing.Point(459, 21);
            this.tb_db_filepath.Name = "tb_db_filepath";
            this.tb_db_filepath.Size = new System.Drawing.Size(197, 21);
            this.tb_db_filepath.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(352, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "生成数据库文件：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 9;
            this.label19.Text = "网关名称：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 7;
            this.label18.Text = "网关编号：";
            // 
            // tb_gwname
            // 
            this.tb_gwname.Location = new System.Drawing.Point(105, 54);
            this.tb_gwname.Name = "tb_gwname";
            this.tb_gwname.Size = new System.Drawing.Size(155, 21);
            this.tb_gwname.TabIndex = 10;
            // 
            // tb_gwid
            // 
            this.tb_gwid.Location = new System.Drawing.Point(105, 23);
            this.tb_gwid.Name = "tb_gwid";
            this.tb_gwid.Size = new System.Drawing.Size(155, 21);
            this.tb_gwid.TabIndex = 8;
            // 
            // btn_registe_gateway
            // 
            this.btn_registe_gateway.Location = new System.Drawing.Point(315, 36);
            this.btn_registe_gateway.Name = "btn_registe_gateway";
            this.btn_registe_gateway.Size = new System.Drawing.Size(75, 23);
            this.btn_registe_gateway.TabIndex = 12;
            this.btn_registe_gateway.Text = "注册";
            this.btn_registe_gateway.UseVisualStyleBackColor = true;
            this.btn_registe_gateway.Click += new System.EventHandler(this.btn_register_gateway_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btn_registe_gateway);
            this.groupBox12.Controls.Add(this.tb_gwid);
            this.groupBox12.Controls.Add(this.tb_gwname);
            this.groupBox12.Controls.Add(this.label18);
            this.groupBox12.Controls.Add(this.label19);
            this.groupBox12.Location = new System.Drawing.Point(354, 58);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(471, 90);
            this.groupBox12.TabIndex = 11;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "注册网关：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "数量：";
            // 
            // cb_aircon_lineshow
            // 
            this.cb_aircon_lineshow.AutoSize = true;
            this.cb_aircon_lineshow.Checked = true;
            this.cb_aircon_lineshow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_aircon_lineshow.Location = new System.Drawing.Point(23, 21);
            this.cb_aircon_lineshow.Name = "cb_aircon_lineshow";
            this.cb_aircon_lineshow.Size = new System.Drawing.Size(72, 16);
            this.cb_aircon_lineshow.TabIndex = 3;
            this.cb_aircon_lineshow.Text = "Lineshow";
            this.cb_aircon_lineshow.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(203, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "Modbus地址范围：17(0x11),18(0x12)";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cb_count_aircon);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.cb_aircon_lineshow);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(20, 338);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(259, 75);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "空气源";
            // 
            // cb_count_aircon
            // 
            this.cb_count_aircon.FormattingEnabled = true;
            this.cb_count_aircon.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cb_count_aircon.Location = new System.Drawing.Point(191, 19);
            this.cb_count_aircon.Name = "cb_count_aircon";
            this.cb_count_aircon.Size = new System.Drawing.Size(39, 20);
            this.cb_count_aircon.TabIndex = 9;
            // 
            // cb_meter_jsy
            // 
            this.cb_meter_jsy.AutoSize = true;
            this.cb_meter_jsy.Checked = true;
            this.cb_meter_jsy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_meter_jsy.Location = new System.Drawing.Point(23, 21);
            this.cb_meter_jsy.Name = "cb_meter_jsy";
            this.cb_meter_jsy.Size = new System.Drawing.Size(60, 16);
            this.cb_meter_jsy.TabIndex = 3;
            this.cb_meter_jsy.Text = "健思研";
            this.cb_meter_jsy.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "485地址：默认1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cb_meter_jsy);
            this.groupBox4.Location = new System.Drawing.Point(20, 259);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(259, 73);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "电量计量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "数量：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "数量：";
            // 
            // cb_ctrlpanel_heater_yilin
            // 
            this.cb_ctrlpanel_heater_yilin.AutoSize = true;
            this.cb_ctrlpanel_heater_yilin.Location = new System.Drawing.Point(23, 22);
            this.cb_ctrlpanel_heater_yilin.Name = "cb_ctrlpanel_heater_yilin";
            this.cb_ctrlpanel_heater_yilin.Size = new System.Drawing.Size(72, 16);
            this.cb_ctrlpanel_heater_yilin.TabIndex = 3;
            this.cb_ctrlpanel_heater_yilin.Text = "亿林地暖";
            this.cb_ctrlpanel_heater_yilin.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 12);
            this.label14.TabIndex = 10;
            this.label14.Text = "Modbus地址范围：5-10";
            // 
            // cb_ctrlpanel_aircon_yilin
            // 
            this.cb_ctrlpanel_aircon_yilin.AutoSize = true;
            this.cb_ctrlpanel_aircon_yilin.Location = new System.Drawing.Point(23, 69);
            this.cb_ctrlpanel_aircon_yilin.Name = "cb_ctrlpanel_aircon_yilin";
            this.cb_ctrlpanel_aircon_yilin.Size = new System.Drawing.Size(72, 16);
            this.cb_ctrlpanel_aircon_yilin.TabIndex = 3;
            this.cb_ctrlpanel_aircon_yilin.Text = "亿林空调";
            this.cb_ctrlpanel_aircon_yilin.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_count_cp_aircon);
            this.groupBox2.Controls.Add(this.cb_count_cp_heater);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cb_ctrlpanel_aircon_yilin);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cb_ctrlpanel_heater_yilin);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(20, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 125);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "地暖及空调温控器";
            // 
            // cb_count_cp_aircon
            // 
            this.cb_count_cp_aircon.FormattingEnabled = true;
            this.cb_count_cp_aircon.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cb_count_cp_aircon.Location = new System.Drawing.Point(191, 67);
            this.cb_count_cp_aircon.Name = "cb_count_cp_aircon";
            this.cb_count_cp_aircon.Size = new System.Drawing.Size(39, 20);
            this.cb_count_cp_aircon.TabIndex = 13;
            // 
            // cb_count_cp_heater
            // 
            this.cb_count_cp_heater.FormattingEnabled = true;
            this.cb_count_cp_heater.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cb_count_cp_heater.Location = new System.Drawing.Point(191, 20);
            this.cb_count_cp_heater.Name = "cb_count_cp_heater";
            this.cb_count_cp_heater.Size = new System.Drawing.Size(39, 20);
            this.cb_count_cp_heater.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 12);
            this.label15.TabIndex = 11;
            this.label15.Text = "Modbus地址范围：11-16";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数量：";
            // 
            // cb_vent_eavada_v1
            // 
            this.cb_vent_eavada_v1.AutoSize = true;
            this.cb_vent_eavada_v1.Checked = true;
            this.cb_vent_eavada_v1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_vent_eavada_v1.Location = new System.Drawing.Point(23, 20);
            this.cb_vent_eavada_v1.Name = "cb_vent_eavada_v1";
            this.cb_vent_eavada_v1.Size = new System.Drawing.Size(72, 16);
            this.cb_vent_eavada_v1.TabIndex = 3;
            this.cb_vent_eavada_v1.Text = "EVADA V1";
            this.cb_vent_eavada_v1.UseVisualStyleBackColor = true;
            // 
            // cb_vent_eavada_v2
            // 
            this.cb_vent_eavada_v2.AutoSize = true;
            this.cb_vent_eavada_v2.Location = new System.Drawing.Point(23, 67);
            this.cb_vent_eavada_v2.Name = "cb_vent_eavada_v2";
            this.cb_vent_eavada_v2.Size = new System.Drawing.Size(72, 16);
            this.cb_vent_eavada_v2.TabIndex = 6;
            this.cb_vent_eavada_v2.Text = "EVADA V2";
            this.cb_vent_eavada_v2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "Modbus地址范围：1,2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cb_count_vent_v2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_count_vent_v1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cb_vent_eavada_v2);
            this.groupBox1.Controls.Add(this.cb_vent_eavada_v1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新风";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Modbus地址范围：3,4";
            // 
            // cb_count_vent_v2
            // 
            this.cb_count_vent_v2.FormattingEnabled = true;
            this.cb_count_vent_v2.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cb_count_vent_v2.Location = new System.Drawing.Point(191, 65);
            this.cb_count_vent_v2.Name = "cb_count_vent_v2";
            this.cb_count_vent_v2.Size = new System.Drawing.Size(39, 20);
            this.cb_count_vent_v2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "数量：";
            // 
            // cb_count_vent_v1
            // 
            this.cb_count_vent_v1.FormattingEnabled = true;
            this.cb_count_vent_v1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cb_count_vent_v1.Location = new System.Drawing.Point(191, 18);
            this.cb_count_vent_v1.Name = "cb_count_vent_v1";
            this.cb_count_vent_v1.Size = new System.Drawing.Size(39, 20);
            this.cb_count_vent_v1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 474);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_generate_db);
            this.tabPage1.Controls.Add(this.btn_select_file);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.tb_db_filepath);
            this.tabPage1.Controls.Add(this.groupBox12);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.tb_log);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(838, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "网关数据库配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_generate_db
            // 
            this.btn_generate_db.Location = new System.Drawing.Point(750, 18);
            this.btn_generate_db.Name = "btn_generate_db";
            this.btn_generate_db.Size = new System.Drawing.Size(75, 23);
            this.btn_generate_db.TabIndex = 16;
            this.btn_generate_db.Text = "生成";
            this.btn_generate_db.UseVisualStyleBackColor = true;
            this.btn_generate_db.Click += new System.EventHandler(this.btn_generate_db_Click);
            // 
            // btn_select_file
            // 
            this.btn_select_file.Location = new System.Drawing.Point(669, 18);
            this.btn_select_file.Name = "btn_select_file";
            this.btn_select_file.Size = new System.Drawing.Size(75, 23);
            this.btn_select_file.TabIndex = 15;
            this.btn_select_file.Text = "选择路径";
            this.btn_select_file.UseVisualStyleBackColor = true;
            this.btn_select_file.Click += new System.EventHandler(this.btn_select_file_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(838, 448);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 492);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "AllHome工具 v0.1";
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_register_gateway;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.TextBox tb_db_filepath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_gwname;
        private System.Windows.Forms.TextBox tb_gwid;
        private System.Windows.Forms.Button btn_registe_gateway;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cb_aircon_lineshow;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cb_meter_jsy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_ctrlpanel_heater_yilin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cb_ctrlpanel_aircon_yilin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_vent_eavada_v1;
        private System.Windows.Forms.CheckBox cb_vent_eavada_v2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_generate_db;
        private System.Windows.Forms.Button btn_select_file;
        private System.Windows.Forms.ComboBox cb_count_vent_v1;
        private System.Windows.Forms.ComboBox cb_count_aircon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_count_vent_v2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cb_count_cp_aircon;
        private System.Windows.Forms.ComboBox cb_count_cp_heater;
    }
}

