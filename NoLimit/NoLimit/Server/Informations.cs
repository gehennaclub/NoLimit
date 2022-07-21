using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace NoLimit.Server
{
    public class Informations
    {
        public static string ip()
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString("https://api.ipify.org/");
            }
        }
    }
}
