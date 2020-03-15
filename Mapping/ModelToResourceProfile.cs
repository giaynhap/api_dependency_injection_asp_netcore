using AutoMapper;
using apicore.Domain.Models;
using apicore.Domain.Resources;
namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Test, TestResource>();
        }
    }
}