using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public interface IHandler {
        void Handle(Stream stream);
    }

    public class StaticFileHandler : IHandler {
        public void Handle(Stream stream) {
            using(var reader = new StreamReader(stream)) 
            using(var writer = new StreamWriter(stream))
            {   
                for (string line = null; line != string.Empty; line = reader.ReadLine())
                {
                    Console.WriteLine(line);
                }
                writer.WriteLine("hiiii");
            }
        }
    }

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
                    using(var reader = new StreamReader(stream)) 
                    using(var writer = new StreamWriter(stream))
                    {    
                        _handler.Handle(stream);
                    }
                }
            }
        }
    }
}