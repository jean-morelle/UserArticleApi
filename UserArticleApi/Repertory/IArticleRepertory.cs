using UserArticleApi.Models;

namespace UserArticleApi.Repertory
{
    public interface IArticleRepertory
    {
        IEnumerable<Article>GetArticles();

        Article GetArticle(int id);

        void Create(Article article);

        void Update(Article article);

        void Delete(int id);
    }
}
