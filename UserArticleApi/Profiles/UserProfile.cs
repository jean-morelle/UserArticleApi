using AutoMapper;
using UserArticleApi.DTO;
using UserArticleApi.Models;

namespace UserArticleApi.Profiles
{
    public class UserProfile : Profile
    {
        //source => destination 

        public UserProfile()
        {
            CreateMap<UserCreateDto,User>();
           
        }
    }
}
