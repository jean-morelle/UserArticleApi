using UserArticleApi.Models;
using UserArticleApi.Repertory;

namespace UserArticleApi.Services
{
    public class UserServices:IUserServices
    {
        private readonly IUserRepertory _userRepertory;

        public UserServices(IUserRepertory userRepertory)
        {
            _userRepertory = userRepertory;
        }

        public void Create(User utilisateur)
        {
           _userRepertory.Create(utilisateur);
        }

        public void Delete(int id)
        {
            _userRepertory.Delete(id);
            
        }

        public User GetById(int id)
        {
            return _userRepertory.GetById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            var GetAllUser = _userRepertory.GetUsers();
            return GetAllUser;
        }

        public void Update(User utilisateur)
        {
            _userRepertory.Update(utilisateur);
        }
    }
}
