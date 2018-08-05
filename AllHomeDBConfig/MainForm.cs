using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InstallationTool.DB;
using InstallationTool.Front;

namespace AllHomeDBConfig
{
    public class LogsEventArgs : EventArgs
    {
        private string _args = string.Empty;
        public LogsEventArgs(string args)
        {
            _args = args;
        }
        public string Args
        {
            get { return _args; }
        }
    }

    public partial class MainForm : Form
    {
        private delegate void DlgAsynShowMsg(string s);

        public MainForm()
        {
            InitializeComponent();
            this.cb_count_vent_v1.SelectedIndex = 0;
            this.cb_count_vent_v2.SelectedIndex = 0;
            this.cb_count_cp_aircon.SelectedIndex = 0;
            this.cb_count_cp_heater.SelectedIndex = 0;
            this.cb_count_aircon.SelectedIndex = 0;
        }

        private void btn_register_gateway_Click(object sender, EventArgs e)
        {
            ShowMsgWithString("准备向服务器注册网关...");

            string gatewayId = this.tb_gwid.Text.Trim();
            string gatewayName = this.tb_gwname.Text.Trim();
            string deviceSignature = DateTime.Now.ToString();

            string dbFilePath = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "SQLite数据库文件|*.db";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dbFilePath = openFileDialog.FileName;
                ShowMsgWithString("数据库文件路径：" + dbFilePath);
            }
            else
            {
                return;
            }

            ShowMsgWithString("网关ID：" + gatewayId);
            ShowMsgWithString("网关名称：" + gatewayName);
            GatewayRegisterRspData registerRet =
                HttpHelper.Instance().RegisterGateway(gatewayId, gatewayName, deviceSignature);

            ShowMsgWithString("网关注册成功！");
            ShowMsgWithString("准备提交设备控制点：");

            List<DeviceData> datas = DBUtil.Instance().GetControlPoints(dbFilePath);
            GatewayUploadCtrlPointsRspData uploadRet =
                HttpHelper.Instance().UploadControllPoints(gatewayId, datas, deviceSignature);

            ShowMsgWithString("设备控制点提交成功。");
            ShowMsgWithString("网关注册工作全部完成！");
        }

        private void btn_select_file_Click(object sender, EventArgs e)
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

            ShowMsgWithString("数据保存路径：" + tb_db_filepath);
        }

        private void btn_generate_db_Click(object sender, EventArgs e)
        {
            if (tb_db_filepath.Text == "")
            {
                MessageBox.Show(this, "请先手动输入或选择要保存数据库文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 生成数据库文件
            ConfigurationHelper confHelper = ConfigurationHelper.Instance();
            confHelper.GenerateDatabase(tb_db_filepath.Text);

            ShowMsgWithString("生成数据库文件成功。");

            // 生成数据库表
            confHelper.GenerateDBTables(tb_db_filepath.Text);

            ShowMsgWithString("生成数据表成功。");

            // 填充填充数据
            string idGateway = confHelper.InsertDeviceAndControlpoints("网关", Utility.DEV_TYPE_GATEWAY, "0", "0");

            ShowMsgWithString("填充网关数据成功。");

            if (cb_vent_eavada_v1.Checked)
            {
                int defaultAddr = 1;    // 1-2
                int count = int.Parse(cb_count_vent_v1.SelectedItem.ToString());
                for(int i = 0; i < count; i++)
                {
                    string id = confHelper.InsertDeviceAndControlpoints("新风1代", Utility.DEV_TYPE_VENT, i.ToString(), (defaultAddr + i).ToString());
                }
                ShowMsgWithString("填充新风1代设备数据成功。");
            }

            if(cb_vent_eavada_v2.Checked)
            {
                int defaultAddr = 3;    // 3-4
                int count = int.Parse(cb_count_vent_v2.SelectedItem.ToString());
                for(int i = 0; i < count; i++)
                {
                    string id = confHelper.InsertDeviceAndControlpoints("新风2代", Utility.DEV_TYPE_VENT, i.ToString(), (defaultAddr + i).ToString());
                }
                ShowMsgWithString("填充新风2代设备数据成功。");
            }

            if(cb_ctrlpanel_aircon_yilin.Checked)
            {
                int defaultAddr = 5;   // 5-10
                int count = int.Parse(cb_count_cp_aircon.SelectedItem.ToString());
                for (int i = 0; i < count; i++)
                {
                    string id = confHelper.InsertDeviceAndControlpoints("空调温控器", Utility.DEV_TYPE_CTRL_AIR, i.ToString(), (defaultAddr + i).ToString());
                }
                ShowMsgWithString("填充空调温控器设备数据成功。");
            }

            if(cb_ctrlpanel_heater_yilin.Checked)
            {
                int defaultAddr = 11;  // 11-16
                int count = int.Parse(cb_count_cp_heater.SelectedItem.ToString());
                for (int i = 0; i < count; i++)
                {
                    string id = confHelper.InsertDeviceAndControlpoints("地暖温控器", Utility.DEV_TYPE_CTRL_HEAT, i.ToString(), (defaultAddr + i).ToString());
                }
                ShowMsgWithString("填充地暖温控器数据成功。");
            }

            if(cb_meter_jsy.Checked)
            {
                int defaultAddr = 1;
                string id = confHelper.InsertDeviceAndControlpoints("电量计量", Utility.DEV_TYPE_METER_POWER, "0", defaultAddr.ToString());
                ShowMsgWithString("填充电量计量数据成功。");
            }

            if(cb_aircon_lineshow.Checked)
            {
                int defaultAddr = 17;   // 17-18
                int count = int.Parse(cb_count_aircon.SelectedItem.ToString());
                for (int i = 0; i < count; i++)
                {
                    string id = confHelper.InsertDeviceAndControlpoints("空气源主机", Utility.DEV_TYPE_AIRCON, i.ToString(), (defaultAddr + i).ToString());
                }
                ShowMsgWithString("填充空气源数据成功。");
            }

            ShowMsgWithString("生成工作全部完成！");
        }

        private void ShowMsgWithString(string msg)
        {
            LogsEventArgs args = new LogsEventArgs(msg);
            ShowMsg(this, args);
        }

        private void ShowMsg(object sender, LogsEventArgs args)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new DlgAsynShowMsg(delegate (string s)
                {
                    if (tb_log.TextLength >= 30000)
                    {
                        tb_log.Clear();
                    }
                    tb_log.AppendText(s + "\r\n");
 
                }), args.Args);
            }
            else
            {
                if (tb_log.TextLength >= 30000)
                {
                    tb_log.Clear();
                }
                tb_log.AppendText(args.Args + "\r\n");
            }
        }
    }
}
