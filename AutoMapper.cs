using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Asp.netcore_practice
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<MovieGetByIdViewModel, Movie>();
            CreateMap<Movie,MovieGetByIdViewModel>();
            CreateMap<ShoppingCartItem, ShoppingCartItemViewModel>();
            CreateMap<ShoppingCartItemViewModel, ShoppingCartItem>();
            CreateMap<RoleViewModel, IdentityRole>();
            CreateMap<Actor, ActorViewModel>();
            CreateMap<Cinema, CinemaViewModel>();
            CreateMap<Producer, ProducerViewModel>();
            CreateMap<Movie, MovieViewModel>();


        }
    }
}
