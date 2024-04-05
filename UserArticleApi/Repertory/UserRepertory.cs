using Microsoft.AspNetCore.Mvc;
using UserArticleApi.Data;
using UserArticleApi.Models;

namespace UserArticleApi.Repertory
{
    public class UserRepertory:IUserRepertory
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepertory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(User utilisateur)
        {
            _dbContext.users.Add(utilisateur);
           
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.users.Remove(GetById(id));
            _dbContext.SaveChanges();
        }

        public User GetById(int id)
        {
            var GetUserId = _dbContext.users.Find(id);
            //if (GetUserId == null)
            //{
            //    throw new Exception("Null");
            //}

            return GetUserId;
        }

        public IEnumerable<User> GetUsers()
        {
           var GetUserAll =_dbContext.users;
           
            return GetUserAll;
        }

        public void Update(User utilisateur)
        {
            _dbContext.users.Update(utilisateur);
            _dbContext.SaveChanges();
        }
    }
}
