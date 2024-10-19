using System.IO;
using System.Net.Http;
using System;

namespace Server {
    
    //путь после домена
    //хттп метод
    //версия протокола
    internal record Request(string Path, HttpMethod Method);

    internal static class RequestParse {
        //парсит запрос, куки, адрес и др
        public static Request Parse (string header) {
            var split = header.Split(" ");
            return new Request(split[1], GetMethod(split[0]));
        }  

        private static HttpMethod GetMethod(string method) {
            if (method == "GET") {
                return HttpMethod.Get;
            }
            return HttpMethod.Post;
        }
    }

    public class StaticFileHandler : IHandler {
        private readonly string _path;

        public StaticFileHandler(string path) {
            _path = path;
        }

        public void Handle(Stream networkStream) {
            using(var reader = new StreamReader(networkStream)) 
            using(var writer = new StreamWriter(networkStream))
            {   
                //костыль, считывает запрос иконки и игнорирует её
                var firstLine = reader.ReadLine();
                for (string line = null; line != string.Empty; line = reader.ReadLine())
                    ;

                var request = RequestParse.Parse(firstLine);

                var filePath = Path.Combine(_path, request.Path.Substring(1));
                Console.WriteLine(filePath);

                //мы не сможем отправить, пока всё не считаем клиентский поток

                if(!File.Exists(filePath)){
                    //404
                }
                else {
                    using(var fileStream = File.OpenRead(filePath)){
                        fileStream.CopyTo(networkStream);
                    }
                }

                //writer.WriteLine("hiiii");
            }
        }
    }

}