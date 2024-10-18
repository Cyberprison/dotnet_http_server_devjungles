using Server;

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace dotnet_http_server 
{
    public class Program
    {
        public static void Main(string[]args)
        {
            ServerHost host = new ServerHost();
            host.Start();
        }
    }
}