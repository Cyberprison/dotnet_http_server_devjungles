using System.Net.Http;

namespace Server {

    //путь после домена
    //хттп метод
    //версия протокола
    public record Request(string Path, HttpMethod Method);
}