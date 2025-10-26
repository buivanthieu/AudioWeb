using AudioWeb.Core.Application.DTOs.Categories;
using MediatR;


namespace AudioWeb.Core.Application.Commands.Categories
{
    public record CreateCategoryCommand(CreateCategoryDto createCategryDto) : IRequest<CategoryDto>
    {
    }
}
