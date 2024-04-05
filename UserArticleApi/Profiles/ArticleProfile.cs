using AutoMapper;
using UserArticleApi.DTO;
using UserArticleApi.Models;

namespace UserArticleApi.Profiles
{
    public class ArticleProfile :Profile
    {
        public ArticleProfile()
        {
            //--Source => Destination
            CreateMap<ArticleCreateDto,Article>();
        }
    }
}
