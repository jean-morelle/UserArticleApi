using UserArticleApi.Models;

namespace UserArticleApi.Services
{
    public interface IUserServices
    {

    IEnumerable<User> GetUsers();

        User GetById(int id);

       public  void Create(User utilisateur);

        void Update(User utilisateur);

        void Delete(int id);
    }
}
