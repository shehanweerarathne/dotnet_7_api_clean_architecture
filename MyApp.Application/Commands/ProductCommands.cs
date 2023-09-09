using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Application.ResponseDTOs;
using MyApp.Domain.DTOs;

namespace MyApp.Application.Commands
{
    public record CreateProductCommand(ProductDto ProductDto) : IRequest<ProductPageDataResponse>;
    public record UpdateProductCommand(ProductDto ProductDto) : IRequest<ProductPageDataResponse>;
    public record DeleteProductCommand(int Id) : IRequest<ProductPageDataResponse>;
}
