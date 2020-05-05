using AutoMapper;
using PersonalPage.Core;
using PersonalPage.Data.Entities;

namespace PersonalPage.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, ApplicationUser>().ConstructUsing(u => new ApplicationUser { Id = u.Id, UserName = u.UserName, PasswordHash = u.PasswordHash });
            CreateMap<ApplicationUser, User>().ConstructUsing(au => new User(au.UserName, au.Email,  au.Id, au.PasswordHash));
        }
    }
}
