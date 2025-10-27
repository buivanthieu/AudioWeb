using System.Threading;
using MediatR;

using AudioWeb.Core.Application.Commands.Categories;
using AudioWeb.Core.Application.DTOs.Categories;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;
using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Application.Handlers.Categories
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken = default)
        {
			var category = await _categoryRepository.GetByIdAsync(request.categoryId);
            if (category == null)
            {
                throw new ArgumentException($"Category with ID {request.categoryId} not found.");
            }
            _mapper.Map(request.UpdateCategoryDto, category);
            var updatedCategory = await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<CategoryDto>(updatedCategory);
        }
    }
}
