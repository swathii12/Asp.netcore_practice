using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;
using AutoMapper;

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
            CreateMap<ShoppingViewModel, ShoppingCart>();
        }
    }
}
