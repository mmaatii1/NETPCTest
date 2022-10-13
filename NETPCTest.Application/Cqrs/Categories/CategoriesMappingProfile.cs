using AutoMapper;
using NETPCTest.Application.Cqrs.Categories.Responses;
using NETPCTest.Core.Entities;

namespace NETPCTest.Application.Cqrs.Categories
{
    public class CategoriesMappingProfile : Profile
    {
        public CategoriesMappingProfile()
        {
            CreateMap<Category, CategoryResponse>();
        }
    }
}
