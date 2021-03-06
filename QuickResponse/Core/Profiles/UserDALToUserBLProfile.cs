using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class UserDALToUserBLProfile:Profile
    {
        public const string ViewModel = "UserDALToUserPLProfile";

        public override string ProfileName => ViewModel;
        public UserDALToUserBLProfile()
        {
            var p = new Data.Models.User();
            this.CreateMap<Data.Models.User, User>();
        }
    }
}
