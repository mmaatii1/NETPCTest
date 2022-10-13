using AutoMapper;
using MediatR;
using NETPCTest.Application.Cqrs.Categories.Queries;
using NETPCTest.Application.Cqrs.Categories.Responses;
using NETPCTest.Core.Entities;
using NETPCTest.Core.Interfaces;

namespace NETPCTest.Application.Cqrs.Categories.Handlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery,IEnumerable<CategoryResponse>>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private IMapper _mapper;
        public GetAllCategoriesQueryHandler(IGenericRepository<Category> repo,IMapper mapper)
        {
            _categoryRepository = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryResponse>>(categories);
        }
    }
}
