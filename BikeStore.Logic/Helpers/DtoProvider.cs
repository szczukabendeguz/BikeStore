using AutoMapper;
using BikeStore.Data;
using BikeStore.Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;
using BikeStore.Entities;
using BikeStore.Entities.Dtos.BikeModel;
using BikeStore.Entities.Dtos.BikeBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Logic.Helpers
{
    public class DtoProvider
    {
        UserManager<AppUser> userManager;

        public Mapper Mapper { get; }

        public DtoProvider(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BikeBrand, BikeBrandShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.AverageAskingPrice = src.Models?.Count > 0 ? src.Models.Average(r => r.AskingPrice) : 0;
                });

                cfg.CreateMap<AppUser, UserViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.IsAdmin = userManager.IsInRoleAsync(src, "Admin").Result;
                });


                cfg.CreateMap<BikeBrand, BikeBrandViewDto>();
                cfg.CreateMap<BikeBrandCreateUpdateDto, BikeBrand>();
                cfg.CreateMap<BikeModelCreateDto, BikeModel>();
                cfg.CreateMap<BikeModel, BikeModelViewDto>()
                .AfterMap((src, dest) =>
                {
                    var user = userManager.Users.First(u => u.Id == src.UserId);
                    dest.UserFullName = user.LastName! + " " + user.FirstName;
                });
            });

            Mapper = new Mapper(config);
        }
    }
}
