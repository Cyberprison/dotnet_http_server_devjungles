using System.IO;
using System;
using System.Net;

namespace Server {


    public class StaticFileHandler : IHandler {
        private readonly string _path;

        public StaticFileHandler(string path) {
            _path = path;
        }

        public void Handle(Stream networkStream, Request request) {
            using(var writer = new StreamWriter(networkStream))
            {   
                var filePath = Path.Combine(_path, request.Path.Substring(1));

                //мы не сможем отправить, пока всё не считаем клиентский поток

                if(!File.Exists(filePath)) {
                    //404
                    //http v
                    //status code
                    //status code name
                    ResponseWriter.WriteStatus(HttpStatusCode.NotFound, networkStream);
                }
                else {
                    ResponseWriter.WriteStatus(HttpStatusCode.OK, networkStream);
                    using(var fileStream = File.OpenRead(filePath)) {
                        fileStream.CopyTo(networkStream);
                    }
                }

                Console.WriteLine(filePath);

                //writer.WriteLine("hiiii");
            }
        }
    }

}