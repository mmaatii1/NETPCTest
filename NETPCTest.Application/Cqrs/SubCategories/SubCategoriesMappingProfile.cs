using AutoMapper;
using NETPCTest.Application.Cqrs.SubCategories.Commands;
using NETPCTest.Application.Cqrs.SubCategories.Requests;
using NETPCTest.Application.Cqrs.SubCategories.Responses;
using NETPCTest.Core.Entities;

namespace NETPCTest.Application.Cqrs.SubCategories
{
    public class SubCategoriesMappingProfile : Profile
    {
        public SubCategoriesMappingProfile()
        {
            CreateMap<SubCategory, SubCategoryResponse>().ReverseMap();
            CreateMap<CreateSubCategoryCommand, SubCategory>();
            CreateMap<CreateSubCategoryRequest, CreateSubCategoryCommand>();
        }
    }
}
