using System.ComponentModel.DataAnnotations;

namespace UserArticleApi.DTO
{
    public class UserCreateDto
    {
        public string? Name { get; set; }

        public string? Gmail { get; set; }
    }
}
