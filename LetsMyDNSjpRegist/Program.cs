using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using LetsMyDNSjp;

namespace LetsMyDNSRegist
{
    class Program
    {
        static void Main(string[] args)
        {
            string loc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Dictionary<string, string> dic = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader(loc + "\\config"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("#"))
                        continue;

                    string[] rec = line.Split(':');
                    dic[rec[0].Trim()] = rec[1].Trim();
                }
            }

            MyDNSJP myDns = new MyDNSJP();

            myDns.MYDNSJP_MASTERID = dic["MYDNSJP_MASTERID"];
            myDns.MYDNSJP_MASTERPWD = dic["MYDNSJP_MASTERPWD"];
            myDns.MYDNSJP_DOMAIN = dic["MYDNSJP_DOMAIN"];

            myDns.CERTBOT_DOMAIN = args[0];
            myDns.CERTBOT_VALIDATION = args[2];

            myDns.REGISTAsync();

            int idx = 0;
            foreach (var s in args)
                Console.WriteLine($"arg{idx++} : {s}");

        }
    }
}
