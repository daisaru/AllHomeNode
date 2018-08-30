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
    public partial class MainForm : Form
    {
        private delegate void DlgAsynShowMsg(string s);

        public MainForm()
        {
            InitializeComponent();
            this.cb_count_vent_v2.SelectedIndex = 0;
            this.cb_count_cp_aircon.SelectedIndex = 0;
            this.cb_count_cp_heater.SelectedIndex = 0;
            this.cb_count_aircon.SelectedIndex = 0;
        }

        #region 界面逻辑

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

            // 填充控制点数据
            string idGateway = confHelper.InsertDeviceAndControlpoints("网关",
                                                                       Utility.DEV_TYPE_GATEWAY,
                                                                       Utility.MODEL_GATEWAY_JADECORE, 
                                                                       "0", 
                                                                       "0");

            ShowMsgWithString("填充网关数据成功。");

            if (rb_vent_eavada_v1.Checked)
            {
                int defaultAddr = 1;    // 1-4
                int count = int.Parse(cb_count_vent_v2.SelectedItem.ToString());
                for(int i = 0; i < count; i++)
                {
                    string id = confHelper.InsertDeviceAndControlpoints("新风1代", 
                                                                        Utility.DEV_TYPE_VENT, 
                                                                        Utility.MODEL_VENT_EAWADA_V1, 
                                                                        i.ToString(), 
                                                                        (defaultAddr + i).ToString());
                }
                ShowMsgWithString("填充新风1代设备数据成功。");
            }

            if(rb_vent_eavada_v2.Checked)
            {
                int defaultAddr = 1;    // 1-4
                int count = int.Parse(cb_count_vent_v2.SelectedItem.ToString());
                for(int i = 0; i < count; i++)
                {
                    string id = confHelper.InsertDeviceAndControlpoints("新风2代", 
                                                                        Utility.DEV_TYPE_VENT, 
                                                                        Utility.MODEL_VENT_EAWASA_V2,
                                                                        i.ToString(), 
                                                                        (defaultAddr + i).ToString());
                }
                ShowMsgWithString("填充新风2代设备数据成功。");
            }

            if(cb_ctrlpanel_aircon_yilin.Checked)
            {
                int defaultAddr = 5;   // 5-10
                int count = int.Parse(cb_count_cp_aircon.SelectedItem.ToString());
                for (int i = 0; i < count; i++)
                {
                    string id = confHelper.InsertDeviceAndControlpoints("空调温控器", 
                                                                        Utility.DEV_TYPE_CTRL_AIR, 
                                                                        Utility.MODEL_CTRL_AIR_YILIN,
                                                                        i.ToString(), 
                                                                        (defaultAddr + i).ToString());
                }
                ShowMsgWithString("填充空调温控器设备数据成功。");
            }

            if(cb_ctrlpanel_heater_yilin.Checked)
            {
                int defaultAddr = 11;  // 11-16
                int count = int.Parse(cb_count_cp_heater.SelectedItem.ToString());
                for (int i = 0; i < count; i++)
                {
                    string id = confHelper.InsertDeviceAndControlpoints("地暖温控器", 
                                                                        Utility.DEV_TYPE_CTRL_HEAT, 
                                                                        Utility.MODEL_CTRL_HEAT_YILIN,
                                                                        i.ToString(), 
                                                                        (defaultAddr + i).ToString());
                }
                ShowMsgWithString("填充地暖温控器数据成功。");
            }

            if(cb_meter_jsy.Checked)
            {
                int defaultAddr = 1;
                string id = confHelper.InsertDeviceAndControlpoints("电量计量", 
                                                                    Utility.DEV_TYPE_METER_POWER, 
                                                                    Utility.MODEL_METER_POWER_JSY,
                                                                    "0", 
                                                                    defaultAddr.ToString());
                ShowMsgWithString("填充电量计量数据成功。");
            }

            if(cb_aircon_lineshow.Checked)
            {
                int defaultAddr = 17;   // 17-18
                int count = int.Parse(cb_count_aircon.SelectedItem.ToString());
                for (int i = 0; i < count; i++)
                {
                    string id = confHelper.InsertDeviceAndControlpoints("空气源主机", 
                                                                        Utility.DEV_TYPE_AIRCON,
                                                                        Utility.MODEL_AIRCON_LINESHOW,
                                                                        i.ToString(), 
                                                                        (defaultAddr + i).ToString());
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

        #endregion

        #region WebAPIs

        private void btn_registe_gateway_Click(object sender, EventArgs e)
        {
            ShowMsgWithString("准备向服务器注册网关...");

            string gatewayId = this.tb_gwid.Text.Trim();
            string gatewayName = this.tb_gwname.Text.Trim();

            if(gatewayId == "" || gatewayName == "")
            {
                MessageBox.Show(this, "网关ID和网关名称不可以为空！", "注意",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        private void btn_searchDevice_Click(object sender, EventArgs e)
        {
            // 登陆
            string username = tb_username.Text.Trim();
            string password = tb_password.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show(this, "用户名及密码不可以为空！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginRspData loginRsp = HttpHelper.Instance().UserLogin(username, password);
            if(!loginRsp.Result.Equals("Success"))
            {
                MessageBox.Show(this, "密码错误，登陆失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 获取所有设备信息
            GetAllGatewayRspData deviceData = HttpHelper.Instance().GetAllGateways(username);
            foreach(UserGatewayData gateway in deviceData.Gateway)
            {
                string gwname = gateway.GatewayName;
                string gwid = gateway.GatewayId;
                string gwonline = gateway.OnineState;
                string privilege = gateway.Privilege;
                TreeNode node = treeview_devices.Nodes.Add(gwid, gwname + " " + privilege, " " + gwonline);

                GetControlPointsRspData cpDatas = HttpHelper.Instance().GetAllControlPoints(username, gwid);
                foreach(DeviceData device in cpDatas.Device)
                {
                    string devid = device.DeviceId;
                    string devname = device.Name;
                    string devtype = device.Type;
                    node.Nodes.Add(devid, devname + " " + devtype);
                }
            }
        }

        #endregion
    }

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
}
