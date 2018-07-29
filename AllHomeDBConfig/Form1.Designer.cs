namespace AllHomeDBConfig
{
    partial class Form1
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
            this.btn_generatedb = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_db_filepath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_gateway_name = new System.Windows.Forms.TextBox();
            this.tb_gateway_id = new System.Windows.Forms.TextBox();
            this.btn_register_gateway = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_aircon_lineshow = new System.Windows.Forms.TextBox();
            this.cb_aircon_lineshow = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_meter_jsy = new System.Windows.Forms.TextBox();
            this.cb_meter_jsy = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_cp_air_yilin = new System.Windows.Forms.TextBox();
            this.cb_ctrlpanel_aircon_yilin = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_cp_heater_yilin = new System.Windows.Forms.TextBox();
            this.cb_ctrlpanel_heater_yilin = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_vent_ewada_v1 = new System.Windows.Forms.TextBox();
            this.cb_vent_eavada_v1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_vent_ewada_v2 = new System.Windows.Forms.TextBox();
            this.cb_vent_eavada_v2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.btn_upload_controlpoints = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_selectfile = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_generatedb
            // 
            this.btn_generatedb.Location = new System.Drawing.Point(729, 21);
            this.btn_generatedb.Name = "btn_generatedb";
            this.btn_generatedb.Size = new System.Drawing.Size(75, 23);
            this.btn_generatedb.TabIndex = 7;
            this.btn_generatedb.Text = "生成";
            this.btn_generatedb.UseVisualStyleBackColor = true;
            this.btn_generatedb.Click += new System.EventHandler(this.btn_generatedb_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(345, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "生成数据库文件：";
            // 
            // tb_db_filepath
            // 
            this.tb_db_filepath.Location = new System.Drawing.Point(452, 55);
            this.tb_db_filepath.Name = "tb_db_filepath";
            this.tb_db_filepath.Size = new System.Drawing.Size(197, 21);
            this.tb_db_filepath.TabIndex = 13;
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
            // tb_gateway_name
            // 
            this.tb_gateway_name.Location = new System.Drawing.Point(105, 54);
            this.tb_gateway_name.Name = "tb_gateway_name";
            this.tb_gateway_name.Size = new System.Drawing.Size(155, 21);
            this.tb_gateway_name.TabIndex = 10;
            // 
            // tb_gateway_id
            // 
            this.tb_gateway_id.Location = new System.Drawing.Point(105, 23);
            this.tb_gateway_id.Name = "tb_gateway_id";
            this.tb_gateway_id.Size = new System.Drawing.Size(155, 21);
            this.tb_gateway_id.TabIndex = 8;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "数量：";
            // 
            // tb_aircon_lineshow
            // 
            this.tb_aircon_lineshow.Enabled = false;
            this.tb_aircon_lineshow.Location = new System.Drawing.Point(191, 19);
            this.tb_aircon_lineshow.Name = "tb_aircon_lineshow";
            this.tb_aircon_lineshow.Size = new System.Drawing.Size(39, 21);
            this.tb_aircon_lineshow.TabIndex = 2;
            this.tb_aircon_lineshow.Text = "1";
            // 
            // cb_aircon_lineshow
            // 
            this.cb_aircon_lineshow.AutoSize = true;
            this.cb_aircon_lineshow.Location = new System.Drawing.Point(23, 21);
            this.cb_aircon_lineshow.Name = "cb_aircon_lineshow";
            this.cb_aircon_lineshow.Size = new System.Drawing.Size(72, 16);
            this.cb_aircon_lineshow.TabIndex = 3;
            this.cb_aircon_lineshow.Text = "Lineshow";
            this.cb_aircon_lineshow.UseVisualStyleBackColor = true;
            this.cb_aircon_lineshow.CheckedChanged += new System.EventHandler(this.cb_aircon_lineshow_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cb_aircon_lineshow);
            this.groupBox5.Controls.Add(this.tb_aircon_lineshow);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(41, 392);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(259, 55);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "空气源";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "数量：";
            // 
            // tb_meter_jsy
            // 
            this.tb_meter_jsy.Enabled = false;
            this.tb_meter_jsy.Location = new System.Drawing.Point(191, 19);
            this.tb_meter_jsy.Name = "tb_meter_jsy";
            this.tb_meter_jsy.Size = new System.Drawing.Size(39, 21);
            this.tb_meter_jsy.TabIndex = 2;
            this.tb_meter_jsy.Text = "1";
            // 
            // cb_meter_jsy
            // 
            this.cb_meter_jsy.AutoSize = true;
            this.cb_meter_jsy.Location = new System.Drawing.Point(23, 21);
            this.cb_meter_jsy.Name = "cb_meter_jsy";
            this.cb_meter_jsy.Size = new System.Drawing.Size(60, 16);
            this.cb_meter_jsy.TabIndex = 3;
            this.cb_meter_jsy.Text = "健思研";
            this.cb_meter_jsy.UseVisualStyleBackColor = true;
            this.cb_meter_jsy.CheckedChanged += new System.EventHandler(this.cb_meter_jsy_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cb_meter_jsy);
            this.groupBox4.Controls.Add(this.tb_meter_jsy);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(41, 313);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(259, 60);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "电量计量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "数量：";
            // 
            // tb_cp_air_yilin
            // 
            this.tb_cp_air_yilin.Enabled = false;
            this.tb_cp_air_yilin.Location = new System.Drawing.Point(191, 19);
            this.tb_cp_air_yilin.Name = "tb_cp_air_yilin";
            this.tb_cp_air_yilin.Size = new System.Drawing.Size(39, 21);
            this.tb_cp_air_yilin.TabIndex = 2;
            this.tb_cp_air_yilin.Text = "1";
            // 
            // cb_ctrlpanel_aircon_yilin
            // 
            this.cb_ctrlpanel_aircon_yilin.AutoSize = true;
            this.cb_ctrlpanel_aircon_yilin.Location = new System.Drawing.Point(23, 21);
            this.cb_ctrlpanel_aircon_yilin.Name = "cb_ctrlpanel_aircon_yilin";
            this.cb_ctrlpanel_aircon_yilin.Size = new System.Drawing.Size(48, 16);
            this.cb_ctrlpanel_aircon_yilin.TabIndex = 3;
            this.cb_ctrlpanel_aircon_yilin.Text = "亿林";
            this.cb_ctrlpanel_aircon_yilin.UseVisualStyleBackColor = true;
            this.cb_ctrlpanel_aircon_yilin.CheckedChanged += new System.EventHandler(this.cb_ctrlpanel_aircon_yilin_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cb_ctrlpanel_aircon_yilin);
            this.groupBox3.Controls.Add(this.tb_cp_air_yilin);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(41, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 60);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "空调温控器";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "数量：";
            // 
            // tb_cp_heater_yilin
            // 
            this.tb_cp_heater_yilin.Enabled = false;
            this.tb_cp_heater_yilin.Location = new System.Drawing.Point(191, 19);
            this.tb_cp_heater_yilin.Name = "tb_cp_heater_yilin";
            this.tb_cp_heater_yilin.Size = new System.Drawing.Size(39, 21);
            this.tb_cp_heater_yilin.TabIndex = 2;
            this.tb_cp_heater_yilin.Text = "1";
            // 
            // cb_ctrlpanel_heater_yilin
            // 
            this.cb_ctrlpanel_heater_yilin.AutoSize = true;
            this.cb_ctrlpanel_heater_yilin.Location = new System.Drawing.Point(23, 21);
            this.cb_ctrlpanel_heater_yilin.Name = "cb_ctrlpanel_heater_yilin";
            this.cb_ctrlpanel_heater_yilin.Size = new System.Drawing.Size(48, 16);
            this.cb_ctrlpanel_heater_yilin.TabIndex = 3;
            this.cb_ctrlpanel_heater_yilin.Text = "亿林";
            this.cb_ctrlpanel_heater_yilin.UseVisualStyleBackColor = true;
            this.cb_ctrlpanel_heater_yilin.CheckedChanged += new System.EventHandler(this.cb_ctrlpanel_heater_yilin_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_ctrlpanel_heater_yilin);
            this.groupBox2.Controls.Add(this.tb_cp_heater_yilin);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(41, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 58);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "地暖温控器";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数量：";
            // 
            // tb_vent_ewada_v1
            // 
            this.tb_vent_ewada_v1.Enabled = false;
            this.tb_vent_ewada_v1.Location = new System.Drawing.Point(191, 19);
            this.tb_vent_ewada_v1.Name = "tb_vent_ewada_v1";
            this.tb_vent_ewada_v1.Size = new System.Drawing.Size(39, 21);
            this.tb_vent_ewada_v1.TabIndex = 2;
            this.tb_vent_ewada_v1.Text = "1";
            // 
            // cb_vent_eavada_v1
            // 
            this.cb_vent_eavada_v1.AutoSize = true;
            this.cb_vent_eavada_v1.Location = new System.Drawing.Point(23, 21);
            this.cb_vent_eavada_v1.Name = "cb_vent_eavada_v1";
            this.cb_vent_eavada_v1.Size = new System.Drawing.Size(72, 16);
            this.cb_vent_eavada_v1.TabIndex = 3;
            this.cb_vent_eavada_v1.Text = "EVADA V1";
            this.cb_vent_eavada_v1.UseVisualStyleBackColor = true;
            this.cb_vent_eavada_v1.CheckedChanged += new System.EventHandler(this.cb_vent_eavada_v1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "数量：";
            // 
            // tb_vent_ewada_v2
            // 
            this.tb_vent_ewada_v2.Enabled = false;
            this.tb_vent_ewada_v2.Location = new System.Drawing.Point(191, 53);
            this.tb_vent_ewada_v2.Name = "tb_vent_ewada_v2";
            this.tb_vent_ewada_v2.Size = new System.Drawing.Size(39, 21);
            this.tb_vent_ewada_v2.TabIndex = 5;
            this.tb_vent_ewada_v2.Text = "1";
            // 
            // cb_vent_eavada_v2
            // 
            this.cb_vent_eavada_v2.AutoSize = true;
            this.cb_vent_eavada_v2.Location = new System.Drawing.Point(23, 55);
            this.cb_vent_eavada_v2.Name = "cb_vent_eavada_v2";
            this.cb_vent_eavada_v2.Size = new System.Drawing.Size(72, 16);
            this.cb_vent_eavada_v2.TabIndex = 6;
            this.cb_vent_eavada_v2.Text = "EVADA V2";
            this.cb_vent_eavada_v2.UseVisualStyleBackColor = true;
            this.cb_vent_eavada_v2.CheckedChanged += new System.EventHandler(this.cb_vent_eavada_v2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_vent_eavada_v2);
            this.groupBox1.Controls.Add(this.tb_vent_ewada_v2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_vent_eavada_v1);
            this.groupBox1.Controls.Add(this.tb_vent_ewada_v1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(41, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新风";
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(347, 252);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(441, 215);
            this.tb_log.TabIndex = 14;
            // 
            // btn_upload_controlpoints
            // 
            this.btn_upload_controlpoints.Location = new System.Drawing.Point(662, 213);
            this.btn_upload_controlpoints.Name = "btn_upload_controlpoints";
            this.btn_upload_controlpoints.Size = new System.Drawing.Size(75, 23);
            this.btn_upload_controlpoints.TabIndex = 13;
            this.btn_upload_controlpoints.Text = "Go";
            this.btn_upload_controlpoints.UseVisualStyleBackColor = true;
            this.btn_upload_controlpoints.Click += new System.EventHandler(this.btn_upload_controlpoints_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "上传设备信息及控制点：";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.button2);
            this.groupBox12.Controls.Add(this.textBox7);
            this.groupBox12.Controls.Add(this.textBox8);
            this.groupBox12.Controls.Add(this.label18);
            this.groupBox12.Controls.Add(this.label19);
            this.groupBox12.Location = new System.Drawing.Point(347, 100);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(441, 90);
            this.groupBox12.TabIndex = 11;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "注册网关：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(315, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Go";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_register_gateway_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(105, 23);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(155, 21);
            this.textBox7.TabIndex = 8;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(105, 54);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(155, 21);
            this.textBox8.TabIndex = 10;
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 9;
            this.label19.Text = "网关名称：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(845, 468);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.btn_selectfile);
            this.tabPage1.Controls.Add(this.btn_generatedb);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(837, 442);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设备及数据配置";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(837, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "网关调试";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_selectfile
            // 
            this.btn_selectfile.Location = new System.Drawing.Point(646, 21);
            this.btn_selectfile.Name = "btn_selectfile";
            this.btn_selectfile.Size = new System.Drawing.Size(75, 23);
            this.btn_selectfile.TabIndex = 16;
            this.btn_selectfile.Text = "选择路径";
            this.btn_selectfile.UseVisualStyleBackColor = true;
            this.btn_selectfile.Click += new System.EventHandler(this.btn_selectfile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 492);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.tb_db_filepath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_upload_controlpoints);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "AllHome工具 v0.1";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_generatedb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_db_filepath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_gateway_name;
        private System.Windows.Forms.TextBox tb_gateway_id;
        private System.Windows.Forms.Button btn_register_gateway;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_aircon_lineshow;
        private System.Windows.Forms.CheckBox cb_aircon_lineshow;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_meter_jsy;
        private System.Windows.Forms.CheckBox cb_meter_jsy;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_cp_air_yilin;
        private System.Windows.Forms.CheckBox cb_ctrlpanel_aircon_yilin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_cp_heater_yilin;
        private System.Windows.Forms.CheckBox cb_ctrlpanel_heater_yilin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_vent_ewada_v1;
        private System.Windows.Forms.CheckBox cb_vent_eavada_v1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_vent_ewada_v2;
        private System.Windows.Forms.CheckBox cb_vent_eavada_v2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Button btn_upload_controlpoints;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_selectfile;
    }
}

