using MediatR;
using MyApp.Domain.DTOs.ResponseDTOs;

namespace MyApp.Application.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductPageDataResponse>;
    public record GetProductsQuery() : IRequest<ProductListPageDataResponse>;
}
