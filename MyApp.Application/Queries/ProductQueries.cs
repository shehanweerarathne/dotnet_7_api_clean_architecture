using MediatR;
using MyApp.Application.ResponseDTOs;

namespace MyApp.Application.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductPageDataResponse>;
    public record GetProductsQuery() : IRequest<ProductListPageDataResponse>;
}
