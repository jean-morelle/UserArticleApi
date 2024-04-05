using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UserArticleApi.Models;

namespace UserArticleApi.DTO
{
    public class ArticleCreateDto
    {

        public string? Title { get; set; }

        public string? Content { get; set; }

        public int UserId { get; set; }
    }
}
