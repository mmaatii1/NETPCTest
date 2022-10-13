using AutoMapper;
using MediatR;
using NETPCTest.Application.Cqrs.SubCategories.Queries;
using NETPCTest.Application.Cqrs.SubCategories.Responses;
using NETPCTest.Core.Entities;
using NETPCTest.Core.Interfaces;

namespace NETPCTest.Application.Cqrs.SubCategories.Handlers
{
    public class GetAllSubCategoriesQueryHandler : IRequestHandler<GetAllSubCategoriesQuery, IEnumerable<SubCategoryResponse>>
    {
        private readonly IGenericRepository<SubCategory> _categoryRepository;
        private IMapper _mapper;
        public GetAllSubCategoriesQueryHandler(IGenericRepository<SubCategory> repo, IMapper mapper)
        {
            _categoryRepository = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SubCategoryResponse>> Handle(GetAllSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            var subCategories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubCategoryResponse>>(subCategories);
        }
    }
}
