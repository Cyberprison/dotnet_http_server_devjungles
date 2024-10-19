using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class ServerHost
    {
        private readonly IHandler _handler;
        public ServerHost(IHandler handler) {
            _handler = handler;
        }
        public void Start()
        {
            TcpListener listner= new TcpListener(IPAddress.Any, 80); 
            listner.Start();

            while(true)
            {
                var client = listner.AcceptTcpClient(); 
                using(var stream = client.GetStream())
                {    
                    _handler.Handle(stream);
                }
            }
        }
    }
}