using System.ComponentModel.DataAnnotations;

namespace UserArticleApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; } 

        public string? Email { get; set; }

        //public ICollection<Article>Articles { get; set; }
    }
}
