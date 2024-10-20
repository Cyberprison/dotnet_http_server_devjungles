using System.Net.Http;

namespace Server {

    internal static class RequestParser {
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
}
