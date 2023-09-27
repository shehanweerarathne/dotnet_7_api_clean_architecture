using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using MyApp.Application.Queries;
using MyApp.Domain.DTOs;
using MyApp.Domain.DTOs.ResponseDTOs;

namespace MyApp.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{

    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        // ProductDto? productDto = await _productService.GetProductByIdAsync(id);
        ProductPageDataResponse? productPageDataResponse = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(productPageDataResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync([FromQuery] string? searchTerm)
    {
        //List<ProductDto>? productDtos = await _productService.GetProductsAsync();
        ProductListPageDataResponse response = await _mediator.Send(new GetProductsQuery(searchTerm));
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductDto productDto)
    {
        var result = await _mediator.Send(new CreateProductCommand(productDto));
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync(ProductDto productDto)
    {
        var result = await _mediator.Send(new UpdateProductCommand(productDto));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> UploadImages([FromForm] List<IFormFile> images)
    {
        try
        {
            List<string> relativePaths = new List<string>();
            foreach (var image in images)
            {
                if (image.Length > 0)
                {
                    // Generate a unique folder name using UUID
                    var folderName = Guid.NewGuid().ToString();
                    string relativePath = Path.Combine( "wwwroot", "images", folderName);
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

                    // Create the unique folder if it doesn't exist
                    Directory.CreateDirectory(imagePath);

                    var fileName = Path.GetFileName(image.FileName);
                    var filePath = Path.Combine(imagePath, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                        relativePaths.Add(Path.Combine(relativePath, fileName));
                    }
                }
            }

            return Ok(new
            {
                isSuccess = true,
                data = relativePaths
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                isSuccess = false,
                error = ex.Message
            });
        }
    }
}