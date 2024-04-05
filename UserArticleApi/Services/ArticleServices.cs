using System.Reflection.Metadata.Ecma335;
using UserArticleApi.Models;
using UserArticleApi.Repertory;

namespace UserArticleApi.Services
{
    public class ArticleServices:IArticleServices
    {
        private readonly IArticleRepertory _articleRepertory;

        public ArticleServices(IArticleRepertory articleRepertory)
        {
            _articleRepertory = articleRepertory;
        }

        public void Create(Article article)
        {
           _articleRepertory.Create(article);
        }

        public void Delete(int id)
        {
           _articleRepertory.Delete(id);
        }

        public Article GetArticleById(int id)
        {
          return  _articleRepertory.GetArticle(id);
        }

        public IEnumerable<Article> GetArticles()
        {
          return _articleRepertory.GetArticles();
        }

        public void Update(Article article)
        {
            _articleRepertory.Update(article);
        }
    }
}
