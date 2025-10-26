using MediatR;

namespace AudioWeb.Core.Application.Commands.Categories
{
    public record DeleteCategoryCommand(int categoryId) : IRequest<bool>
    {
    }
}
