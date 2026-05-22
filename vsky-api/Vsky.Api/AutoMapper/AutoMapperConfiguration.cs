using AutoMapper;
using Vsky.Api.Models;
using Vsky.Models;

namespace Vsky.Api.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<ApplicationUser, UserModel>();
            CreateMap<UserModel, ApplicationUser>();

            CreateMap<Country, CountryModel>();
            CreateMap<CountryModel, Country>();

            CreateMap<StateProvince, StateProvinceModel>();
            CreateMap<StateProvinceModel, StateProvince>();

            CreateMap<DropDown, DropDownModel>();
            CreateMap<DropDownModel, DropDown>();

            CreateMap<DropDown, DropDownViewModel>();
            CreateMap<DropDown, DropDownViewModel>();

            CreateMap<ApplicationRole, RoleModel>();
            CreateMap<RoleModel, ApplicationRole>();

            CreateMap<Menu, MenuModel>();
            CreateMap<MenuModel, Menu>();

            CreateMap<MenuPermission, MenuPermissionModel>();
            CreateMap<MenuPermissionModel, MenuPermission>();

            CreateMap<PictureBinary, PictureBinaryModel>();
            CreateMap<PictureBinaryModel, PictureBinary>();

            CreateMap<ApplicationUserInfo, ApplicationUserInfoModel>();
            CreateMap<ApplicationUserInfoModel, ApplicationUserInfo>();

            CreateMap<ApplicationUserParent, ApplicationUserParentModel>();
            CreateMap<ApplicationUserParentModel, ApplicationUserParent>();

        }
    }
}