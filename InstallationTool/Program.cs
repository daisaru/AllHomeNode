﻿using InstallationTool.DB;
using InstallationTool.Front;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<RoomData> roomInfos = DBUtil.Instance().GetControlPoints();
            string deviceSignature = DateTime.Now.ToString();

            //GatewayRegisterRspData registerRet =
            //    HttpHelper.Instance().RegisterGateway(deviceId, deviceName, deviceSignature);

            //List<DeviceData> datas = DBUtil.Instance().GetControlPoints();
            //GatewayUploadCtrlPointsRspData uploadRet =
            //    HttpHelper.Instance().UploadControllPoints(deviceId, datas, deviceSignature);

        }
    }
}
