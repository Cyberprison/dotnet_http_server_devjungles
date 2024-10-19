using System.IO;

namespace Server {
    public interface IHandler {
        void Handle(Stream stream);
    }
}