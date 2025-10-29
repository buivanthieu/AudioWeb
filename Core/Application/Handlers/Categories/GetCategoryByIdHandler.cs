using System.Threading;
using MediatR;

using AudioWeb.Core.Application.Queries.Categories;
using AudioWeb.Core.Application.DTOs.Categories;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Categories
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryByIdHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
			var category = await _categoryRepository.GetByIdAsync(request.categoryId);
            if (category == null)
            {
                throw new ArgumentException($"category id is {request.categoryId} is not found");
            }
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
