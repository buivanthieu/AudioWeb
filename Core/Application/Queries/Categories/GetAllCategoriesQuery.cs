using AudioWeb.Core.Application.DTOs.Categories;
using MediatR;


namespace AudioWeb.Core.Application.Queries.Categories
{
    public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
