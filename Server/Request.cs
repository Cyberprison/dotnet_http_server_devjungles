using System.Net.Http;

namespace Server {

    //путь после домена
    //хттп метод
    //версия протокола
    internal record Request(string Path, HttpMethod Method);
}