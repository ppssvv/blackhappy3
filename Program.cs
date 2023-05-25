﻿using Common.Resources.Proto;
using Common;
using System.Net.NetworkInformation;

namespace PemukulPaku
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello!");
            GetPlayerTokenRsp getPlayerTokenRsp = new()
            {
                Msg = "Hello!"
            };
            new Thread(HttpServer.Program.Main).Start();

            Global.config.Gameserver.Host = NetworkInterface.GetAllNetworkInterfaces().Where(i => i.NetworkInterfaceType != NetworkInterfaceType.Loopback && i.OperationalStatus == OperationalStatus.Up).First().GetIPProperties().UnicastAddresses.Where(a => a.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First().Address.ToString();
            Console.WriteLine(Global.config.Gameserver.Host);

            Console.ReadKey(true);
        }
    }
}