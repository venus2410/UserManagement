using _67RoleBaseSecurity.DataModel;
using _67RoleBaseSecurity.Models;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _67RoleBaseSecurity
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void Init() 
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<User, UserModel>()
                        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
                    cfg.CreateMap<UserModel, User>()
                        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
                    cfg.CreateMap<Role, RoleViewModel>().ReverseMap();
                    //for update user
                    cfg.CreateMap<User, User>().ForMember(dest => dest.Password, opt => opt.Ignore());

                }                
                
                );
            Mapper= config.CreateMapper();
        }
    }
}