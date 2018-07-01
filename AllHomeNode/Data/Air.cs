using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Data.Air
{
    public class Basic
    {
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 上海
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 上海
        /// </summary>
        public string parent_city { get; set; }
        /// <summary>
        /// 上海
        /// </summary>
        public string admin_area { get; set; }
        /// <summary>
        /// 中国
        /// </summary>
        public string cnty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tz { get; set; }
    }

    public class Update
    {
        /// <summary>
        /// 
        /// </summary>
        public string loc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string utc { get; set; }
    }

    public class Air_now_city
    {
        /// <summary>
        /// 
        /// </summary>
        public string aqi { get; set; }
        /// <summary>
        /// 优
        /// </summary>
        public string qlty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string main { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pm25 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pm10 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string no2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string so2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string co { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string o3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pub_time { get; set; }
    }

    public class Air_now_stationItem
    {
        /// <summary>
        /// 十五厂
        /// </summary>
        public string air_sta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string aqi { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string asid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string co { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string main { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string no2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string o3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pm10 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pm25 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pub_time { get; set; }
        /// <summary>
        /// 优
        /// </summary>
        public string qlty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string so2 { get; set; }
    }

    public class HeAir6Item
    {
        /// <summary>
        /// 
        /// </summary>
        public Basic basic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Update update { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Air_now_city air_now_city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Air_now_stationItem> air_now_station { get; set; }
    }
}
