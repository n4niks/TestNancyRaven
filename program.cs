using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Sockets;

namespace Kemwell.NancyFx
{
    //http://www.kristofclaes.be/blog/2011/08/23/hosting-nancy-from-a-console-application/
    public class program
    {
        private static List<Uri> GetUriParams(int port)
        {
            List<Uri> list = new List<Uri>();
            string hostName = Dns.GetHostName();
            string uriString1 = string.Format("http://{0}:{1}", (object)Dns.GetHostName(), (object)port);
            list.Add(new Uri(uriString1));
            foreach (IPAddress ipAddress in Dns.GetHostEntry(hostName).AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    byte[] addressBytes = ipAddress.GetAddressBytes();
                    string uriString2 = string.Format("http://{0}.{1}.{2}.{3}:{4}", (object)addressBytes[0], (object)addressBytes[1], (object)addressBytes[2], (object)addressBytes[3], (object)port);
                    list.Add(new Uri(uriString2));
                }
            }
            return list;
        }

        private static void Main(string[] args)
        {
            //try {
              
            
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.StackTrace);
            //}

            NancyHost nancyHost = new NancyHost(new Uri(ConfigurationManager.AppSettings.Get("api-uri")));
            nancyHost.Start();
            Console.ReadLine();
            nancyHost.Stop();
        }
    }
}
