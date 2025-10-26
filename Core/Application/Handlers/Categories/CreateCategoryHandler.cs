using System.Threading;

using AudioWeb.Core.Application.Commands.Categories;
using AudioWeb.Core.Application.DTOs.Categories;
using AudioWeb.Core.Domain.Entities;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AudioWeb.Core.Application.Handlers.Categories
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken = default)
        {
			var category = _mapper.Map<Category>(request.createCategryDto);
            var createdCategory = await _categoryRepository.AddAsync(category);
            return _mapper.Map<CategoryDto>(createdCategory);
        }
    }
}
