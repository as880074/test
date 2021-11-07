using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.Lib.Models.Repository;
using Demo.Lib.Models.Services;

namespace Demo.Lib.Infrastructure.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            this.CreateMap<User, UserModel>().ReverseMap();
            this.CreateMap<UserDetailDto, UserDetailModel>().ReverseMap();
        }
    }
}
