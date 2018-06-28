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
            HttpHelper.Instance().RegisterGateway("111111", "hello", "briantest");
        }
    }
}
