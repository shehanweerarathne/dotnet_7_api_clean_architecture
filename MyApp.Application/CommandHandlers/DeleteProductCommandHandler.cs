using AutoMapper;
using MediatR;
using MyApp.Application.Commands;
using MyApp.Application.ResponseDTOs;
using MyApp.Domain.DTOs;
using MyApp.Infrastructure.Repositories.Interfaces;


namespace MyApp.Application.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductPageDataResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public async Task<ProductPageDataResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productDeleted = await _productRepository.DeleteProductAsync(request.Id);
            var categories = await _productRepository.GetCategoriesAsync();

            List<SelectDto>? selectDtos = categories.Select(c => new SelectDto { Value = c.Id, Label = c.Name }).ToList();
            ProductPageDataResponse productPageDataResponse = new ProductPageDataResponse
            {

                Categories = selectDtos
            };

            return productPageDataResponse;
        }
    }
}
