using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Data.Weather
{
    public class Basic
    {
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 北京
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 北京
        /// </summary>
        public string parent_city { get; set; }
        /// <summary>
        /// 北京
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

    public class Now
    {
        /// <summary>
        /// 
        /// </summary>
        public string cloud { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cond_code { get; set; }
        /// <summary>
        /// 多云
        /// </summary>
        public string cond_txt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pcpn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pres { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tmp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wind_deg { get; set; }
        /// <summary>
        /// 东风
        /// </summary>
        public string wind_dir { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wind_sc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wind_spd { get; set; }
    }

    public class HeWeather6
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
        public Now now { get; set; }
    }

    public class Weather
    {
        public List<HeWeather6> HeWeather6 { get; set; }
    }
}
