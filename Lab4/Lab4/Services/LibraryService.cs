using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Lab4.Services
{
    public interface ILibraryService
    {
        List<Book> GetBooks();
        List<User> GetUsers();
    }
    public class LibraryService : ILibraryService
    {
        public List<Book> GetBooks()
        {
            var books = File.ReadAllText("Data/books.json");
            return JsonConvert.DeserializeObject<List<Book>>(books);
        }

        public List<User> GetUsers()
        {
            var users = File.ReadAllText("Data/users.json");
            return JsonConvert.DeserializeObject<List<User>>(users);
        }
    }
}
