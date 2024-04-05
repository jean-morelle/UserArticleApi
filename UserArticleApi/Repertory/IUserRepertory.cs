using UserArticleApi.Models;

namespace UserArticleApi.Repertory
{
    public interface IUserRepertory
    {
        IEnumerable<User> GetUsers();

        User GetById(int id);

        void  Create (User utilisateur);

        void Update (User utilisateur);
        void  Delete (int id);

    }
}
