using System.Net;
using System.Net.Sockets;

namespace Infrastructure.Identity.Helpers
{
    public class IpHelper
    {
        public static string GetIpAddress()
        {
            // what's IPHostEntry:
            // The IPHostEntry class contains information about a host, such as its name and IP addresses.
            // what's the host:
            // The host is the local machine on which the code is running.

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }
    }
}
