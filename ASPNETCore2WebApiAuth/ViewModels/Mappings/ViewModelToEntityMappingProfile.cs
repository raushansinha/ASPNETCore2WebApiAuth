using System;
using System.Collections.Generic;
using System.Linq;
using AngularASPNETCore2WebApiAuth.ViewModels;
using ASPNETCore2WebApiAuth.Models.Entities;
using AutoMapper;

namespace ASPNETCore2WebApiAuth.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
