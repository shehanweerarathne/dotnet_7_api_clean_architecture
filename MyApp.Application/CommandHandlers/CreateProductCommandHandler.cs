using AutoMapper;
using MediatR;
using MyApp.Application.Commands;
using MyApp.Application.ResponseDTOs;
using MyApp.Domain.DTOs;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Repositories.Interfaces;


namespace MyApp.Application.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductPageDataResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        public async Task<ProductPageDataResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDto);
            var productCreated = await _productRepository.CreateProductAsync(product);
            var categories = await _productRepository.GetCategoriesAsync();
            var productDto = _mapper.Map<ProductDto>(productCreated);
            List<SelectDto>? selectDtos = categories.Select(c => new SelectDto { Value = c.Id, Label = c.Name }).ToList();
            ProductPageDataResponse productPageDataResponse = new ProductPageDataResponse
            {
                Product = productDto,
                Categories = selectDtos
            };
            return productPageDataResponse;
        }
    }
}
