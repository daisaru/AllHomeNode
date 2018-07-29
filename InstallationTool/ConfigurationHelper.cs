using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallationTool
{
    public class ConfigurationHelper
    {
        private static ConfigurationHelper _instance = null;

        private ConfigurationHelper()
        {

        }

        public static ConfigurationHelper Instance()
        {
            if(_instance == null)
            {
                _instance = new ConfigurationHelper();
            }

            return _instance;
        }
    }
}
