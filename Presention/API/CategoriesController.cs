using AudioWeb.Core.Application.Commands.Categories;
using AudioWeb.Core.Application.DTOs.Categories;
using AudioWeb.Core.Application.Queries.Categories;

using AudioWeb.Shared.DTOs;
using AudioWeb.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AudioWeb.Presention.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<BaseListResponse<CategoryListDto>>> GetAllCategories()
        {
            try
            {
                var query = new GetAllCategoriesQuery();
                var result = await _mediator.Send(query);
                return this.SuccessListResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestListResponse<CategoryListDto>(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<BaseResponse<CategoryDto>>> GetCategoryById(int id)
        {
            try
            {
                var query = new GetCategoryByIdQuery(id);
                var result = await _mediator.Send(query);
                return this.SuccessResponse(result);
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<CategoryDto>(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResponse<CategoryDto>>> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Category created successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<CategoryDto>(ex.Message);
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteCategory([FromQuery] int id)
        {
            try
            {
                var command = new DeleteCategoryCommand(id);
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Category deleted successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<bool>(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<BaseResponse<CategoryDto>>> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return this.SuccessResponse(result, "Category updated successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<CategoryDto>(ex.Message);
            }
        }
    }
 }
