using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllHomeDBConfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_selectfile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "SQLite数据文件(*.db)|*.db";//设置文件类型
            sfd.FileName = "allhome";//设置默认文件名
            sfd.DefaultExt = "db";//设置默认格式（可以不设）
            sfd.AddExtension = true;//设置自动在文件名中添加扩展名
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tb_db_filepath.Text = sfd.FileName;
            }
        }

        private void btn_generatedb_Click(object sender, EventArgs e)
        {
            if(tb_db_filepath.Text == "")
            {
                MessageBox.Show(this, "请先手动输入或选择要保存数据库文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ConfigurationHelper confHelper = ConfigurationHelper.Instance();
            confHelper.GenerateDatabase(tb_db_filepath.Text);
        }

        private void btn_register_gateway_Click(object sender, EventArgs e)
        {

        }

        private void btn_upload_controlpoints_Click(object sender, EventArgs e)
        {

        }

        private void cb_vent_eavada_v1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = sender as CheckBox;
            if(obj.Checked)
            {
                tb_vent_ewada_v1.Enabled = true;
                tb_vent_ewada_v1.Text = "1";
            }
            else
            {
                tb_vent_ewada_v1.Enabled = false;
                tb_vent_ewada_v1.Text = "1";
            }
        }

        private void cb_vent_eavada_v2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = sender as CheckBox;
            if (obj.Checked)
            {
                tb_vent_ewada_v2.Enabled = true;
                tb_vent_ewada_v2.Text = "1";
            }
            else
            {
                tb_vent_ewada_v2.Enabled = false;
                tb_vent_ewada_v2.Text = "1";
            }
        }

        private void cb_ctrlpanel_heater_yilin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = sender as CheckBox;
            if (obj.Checked)
            {
                tb_cp_heater_yilin.Enabled = true;
                tb_cp_heater_yilin.Text = "1";
            }
            else
            {
                tb_cp_heater_yilin.Enabled = false;
                tb_cp_heater_yilin.Text = "1";
            }
        }

        private void cb_ctrlpanel_aircon_yilin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = sender as CheckBox;
            if (obj.Checked)
            {
                tb_cp_air_yilin.Enabled = true;
                tb_cp_air_yilin.Text = "1";
            }
            else
            {
                tb_cp_air_yilin.Enabled = false;
                tb_cp_air_yilin.Text = "1";
            }
        }

        private void cb_meter_jsy_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = sender as CheckBox;
            if (obj.Checked)
            {
                tb_meter_jsy.Enabled = true;
                tb_meter_jsy.Text = "1";
            }
            else
            {
                tb_meter_jsy.Enabled = false;
                tb_meter_jsy.Text = "1";
            }
        }

        private void cb_aircon_lineshow_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = sender as CheckBox;
            if (obj.Checked)
            {
                tb_aircon_lineshow.Enabled = true;
                tb_aircon_lineshow.Text = "1";
            }
            else
            {
                tb_aircon_lineshow.Enabled = false;
                tb_aircon_lineshow.Text = "1";
            }
        }


    }
}
