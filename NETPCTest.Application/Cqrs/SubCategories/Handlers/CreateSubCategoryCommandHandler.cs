using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NETPCTest.Application.Cqrs.SubCategories.Commands;
using NETPCTest.Application.Cqrs.SubCategories.Responses;
using NETPCTest.Core.Entities;
using NETPCTest.Core.Interfaces;

namespace NETPCTest.Application.Cqrs.SubCategories.Handlers
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand,SubCategoryResponse>
    {
        private readonly IGenericRepository<SubCategory> _repo;
        private readonly IMapper _mapper;

        public CreateSubCategoryCommandHandler(IGenericRepository<SubCategory> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<SubCategoryResponse> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToCreate = _mapper.Map<SubCategory>(request);
           var added = await _repo.AddAsync(categoryToCreate);
           return _mapper.Map<SubCategoryResponse>(added);

        }
    }
}
