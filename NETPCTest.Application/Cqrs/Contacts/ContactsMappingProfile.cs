using AutoMapper;
using NETPCTest.Application.Cqrs.Contacts.Commands;
using NETPCTest.Application.Cqrs.Contacts.Requests;
using NETPCTest.Application.Cqrs.Contacts.Responses;
using NETPCTest.Core.Entities;

namespace NETPCTest.Application.Cqrs.Contacts
{
    public class ContactsMappingProfile : Profile
    {/// <summary>
    /// mapping could be done better i think, some prop dont pop out as response for ex update.
    /// </summary>
        public ContactsMappingProfile()
        {
            CreateMap<Contact, ContactResponse>()
                .ForMember(x => x.CategoryName, x => x.MapFrom(c => c.Category.CategoryName))
                .ForMember(x => x.SubCategoryName, x => x.MapFrom(c => c.SubCategory.SubCategoryName));

            //create
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<CreateContactCommand, ContactResponse>();
            CreateMap<CreateContactRequest, CreateContactCommand>();
            //update
            CreateMap<UpdateContactCommand, Contact>();
            CreateMap<UpdateContactCommand, ContactResponse>();
            CreateMap<UpdateContactRequest, UpdateContactCommand>();
            //get
            CreateMap<Category, ContactResponse>()
                .ForMember(x => x.CategoryId, x => x.MapFrom(c => c.Id))
                .ForMember(x => x.CategoryName, x => x.MapFrom(c => c.CategoryName));
            CreateMap<SubCategory, ContactResponse>()
                .ForMember(x => x.SubCategoryId, x => x.MapFrom(c => c.Id))
                .ForMember(x => x.SubCategoryName, x => x.MapFrom(c => c.SubCategoryName));
        }
    }
}
