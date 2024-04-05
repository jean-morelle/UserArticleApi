using UserArticleApi.Models;

namespace UserArticleApi.Services
{
    public interface IArticleServices
    {
        IEnumerable<Article> GetArticles();

        Article GetArticleById(int id);

        void Create(Article article);

        void Delete(int id);

        void Update(Article article);
    }
}
