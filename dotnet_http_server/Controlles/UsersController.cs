using Server;

namespace dotnet_http_server.Controllers {
    public record User(string Name, string Surname, string Login);

    public class UsersControlles : IController {
        public User[] Index(){
            return new []{
                new User("1", "2", "3"),
                new User("11", "22", "33"),
                new User("111", "222", "333")
            };
        }
    }

}