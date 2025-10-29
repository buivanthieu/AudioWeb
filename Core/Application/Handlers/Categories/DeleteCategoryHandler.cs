using System.Threading;
using MediatR;

using AudioWeb.Core.Application.Commands.Categories;
using AudioWeb.Core.Domain.Interfaces;
using AutoMapper;

namespace AudioWeb.Core.Application.Handlers.Categories
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public DeleteCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
			var category = await _categoryRepository.GetByIdAsync(request.categoryId);
            if (category == null)
            {
                return false;
            }
            var result = await _categoryRepository.DeleteAsync(request.categoryId);
            return result;
        }
    }
}
