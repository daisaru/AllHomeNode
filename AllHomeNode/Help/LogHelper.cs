using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace AllHomeNode.Help
{
    //Type t = MethodBase.GetCurrentMethod().DeclaringType;
    
    /// <summary>
    /// 日志记录级别
    /// </summary>
    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }

    public class LogHelper
    {
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="logLevel">记录级别</param>
        /// <param name="t">当前类型</param>
        /// <param name="obj">需要记录为Json格式的对象</param>
        #region static void WriteLog(LogLevel logLevel, Type t, Object obj)
        public static void WriteLog(LogLevel logLevel, Type t, Object obj)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            string json = JsonHelper.ToJSON(obj);
            switch (logLevel)
            {
                case LogLevel.Debug: log.Debug("DEBUG:" + json); break;
                case LogLevel.Error: log.Error("ERROR:" + json); break;
                case LogLevel.Fatal: log.Fatal("FATAL:" + json); break;
                case LogLevel.Info: log.Info("INFO:" + json); break;
                case LogLevel.Warn: log.Warn("WARN:" + json); break;
                default: break;
            }
        }
        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="logLevel">记录级别</param>
        /// <param name="t">当前类型</param>
        /// <param name="ex">异常实例</param>
        #region static void WriteLog(LogLevel logLevel, Type t, Exception ex)
        public static void WriteLog(LogLevel logLevel, Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            switch (logLevel)
            {
                case LogLevel.Debug: log.Debug("DEBUG:", ex); break;
                case LogLevel.Error: log.Error("ERROR:", ex); break;
                case LogLevel.Fatal: log.Fatal("FATAL:", ex); break;
                case LogLevel.Info: log.Info("INFO:", ex); break;
                case LogLevel.Warn: log.Warn("WARN:", ex); break;
                default: break;
            }
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="logLevel">记录级别</param>
        /// <param name="t">当前类型</param>
        /// <param name="msg">异常信息</param>
        #region static void WriteLog(LogLevel logLevel, Type t, string msg)
        public static void WriteLog(LogLevel logLevel, Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            switch (logLevel)
            {
                case LogLevel.Debug: log.Debug("DEBUG:" + msg); break;
                case LogLevel.Error: log.Error("ERROR:" + msg); break;
                case LogLevel.Fatal: log.Fatal("FATAL:" + msg); break;
                case LogLevel.Info: log.Info("INFO:" + msg); break;
                case LogLevel.Warn: log.Warn("WARN:" + msg); break;
                default: break;
            }
        }

        #endregion
    }
}
