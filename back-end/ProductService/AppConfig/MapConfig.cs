using AutoMapper;
using ProductService.Models;
using ProductService.Protos;

namespace ProductService.AppConfig
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<ProductModel, Product>().ReverseMap().ForAllMembers(options => options.Condition((src, dest, srcValue) => srcValue != null)); 
        }
    }
}
