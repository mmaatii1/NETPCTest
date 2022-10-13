using MediatR;
using NETPCTest.Core.Interfaces;
using AutoMapper;
using NETPCTest.Application.Cqrs.Contacts.Commands;
using NETPCTest.Application.Cqrs.Contacts.Responses;
using NETPCTest.Core.Entities;
using NETPCTest.Core.Exceptions;

namespace NETPCTest.Application.Cqrs.Contacts.Handlers
{
    /// <summary>
    /// I dont have to do any validation here,
    /// some of it is in repo implementation and some will be handled in pipeline.
    /// In all of the crud im using my repo interface which is
    /// injected by DI container, the same for mapper.
    /// And yeah, im mapping from entity in Db to Response - like DTO.
    /// I will not write anymore summary on crud methods as they would be the same.
    /// Oh and, im not implementatin cancelation token but it can be used
    /// to cancel operation if user for ex. presses refresh mutiple times
    /// </summary>
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactResponse>
    {
        private readonly IGenericRepository<Contact> _contactRepo;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<SubCategory> _subCategoryRepo;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IGenericRepository<Contact> repo, IGenericRepository<Category> categoryRepo,
            IGenericRepository<SubCategory> subCategoryRepo,
            IMapper mapper)
        {
            _mapper = mapper;
            _contactRepo = repo;
            _categoryRepo = categoryRepo;
            _subCategoryRepo = subCategoryRepo;
        }

        public async Task<ContactResponse> Handle(CreateContactCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepo.GetByIdAsync(command.CategoryId);
            SubCategory? subCategory = null;
            if (command.SubCategoryId != null)
            {
                subCategory = await _subCategoryRepo.GetByIdAsync((int)command.SubCategoryId);
            }

            var contact = _mapper.Map<Contact>(command);
            contact.Category = category;
            contact.SubCategory = subCategory;
            try
            {
                var createdEntity = await _contactRepo.AddAsync(contact);
                return _mapper.Map<ContactResponse>(createdEntity);
            }
            catch (Exception e)
            {
                //yeah.. this is simplyfication ;d i could do it better but have little time
                throw new EmailExists(command.Email);
            }
        }
    }
}
