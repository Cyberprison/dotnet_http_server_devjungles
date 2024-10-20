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
                using(var client = listner.AcceptTcpClient())
                using(var stream = client.GetStream())
                using(var reader = new StreamReader(stream))
                {    
                    //костыль, считывает запрос иконки и игнорирует её
                    var firstLine = reader.ReadLine();
                    for (string line = null; line != string.Empty; line = reader.ReadLine())
                        ;

                    var request = RequestParser.Parse(firstLine);
                    _handler.Handle(stream,request);
                }
            }
        }
    }
}