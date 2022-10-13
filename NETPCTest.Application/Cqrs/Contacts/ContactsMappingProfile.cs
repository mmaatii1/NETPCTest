using AutoMapper;
using NETPCTest.Application.Cqrs.Contacts.Commands;
using NETPCTest.Application.Cqrs.Contacts.Requests;
using NETPCTest.Application.Cqrs.Contacts.Responses;
using NETPCTest.Core.Entities;

namespace NETPCTest.Application.Cqrs.Contacts
{
    public class ContactsMappingProfile : Profile
    {
        public ContactsMappingProfile()
        {
            //create
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<Contact, ContactResponse>();
            CreateMap<CreateContactRequest, CreateContactCommand>();
            //update
            CreateMap<UpdateContactCommand, Contact>();
            CreateMap<UpdateContactCommand, ContactResponse>();
            CreateMap<UpdateContactRequest, UpdateContactCommand>();
            //delete
            CreateMap<Contact, ContactResponse>();
            //get
            CreateMap<Contact, ContactResponse>();
            CreateMap<Category, ContactResponse>();
            CreateMap<SubCategory, ContactResponse>();
        }
    }
}
