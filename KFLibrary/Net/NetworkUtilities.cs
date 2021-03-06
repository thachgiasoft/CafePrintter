//<auto-generated />

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace KFLibrary.Net
{
    public class NetworkUtilities
    {
        public static string GetLocalIPv4()
        {
            try
            {
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    return "";
                }

                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                var ipAddress = host
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                if (ipAddress == null)
                {
                    return "";
                }

                return ipAddress.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string GetPublicIPv4()
        {
            try
            {
                String direction = "";
                WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
                using (WebResponse response = request.GetResponse())
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    direction = stream.ReadToEnd();
                }

                //Search for the ip in the html
                int first = direction.IndexOf("Address: ") + 9;
                int last = direction.LastIndexOf("</body>");
                direction = direction.Substring(first, last - first);

                return direction;
            }
            catch
            {
                return "";
            }
        }
    }
}
