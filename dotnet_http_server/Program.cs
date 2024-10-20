using Server;

namespace dotnet_http_server 
{
    public class Program
    {
        public static void Main(string[]args)
        {
            ServerHost host = new ServerHost(new ControllersHandler(typeof(Program).Assembly));
            host.Start();
        }
    }
}