using AudioWeb.Core.Application.DTOs.Categories;
using MediatR;


namespace AudioWeb.Core.Application.Commands.Categories
{
    public record UpdateCategoryCommand(int categoryId, UpdateCategoryDto UpdateCategoryDto) : IRequest<CategoryDto>
    {
    }
}
