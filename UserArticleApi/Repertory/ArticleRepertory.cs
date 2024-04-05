using UserArticleApi.Data;
using UserArticleApi.Models;

namespace UserArticleApi.Repertory
{
    public class ArticleRepertory:IArticleRepertory
    {
        private readonly ApplicationDbContext _dbContext;

        public ArticleRepertory( ApplicationDbContext dbContext)
        {
                _dbContext =dbContext;
        }

        public void Create(Article article)
        {
            _dbContext.articles.Add(article);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.articles.Remove(GetArticle(id));
            _dbContext.SaveChanges();
        }

        public Article GetArticle(int id)
        {
            var GetArticleById = _dbContext.articles.Find(id);
            return GetArticleById;
        }

        public IEnumerable<Article> GetArticles()
        {
          var  GetArticleAll = _dbContext.articles;
            return GetArticleAll;
        }

        public void Update(Article article)
        {
            _dbContext.articles.Update(article);
            _dbContext.SaveChanges();
        }
    }
}
