using AutoMapper;
using MediatR;
using MyApp.Application.Commands;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Application.ResponseDTOs;
using MyApp.Domain.DTOs;

namespace MyApp.Application.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductPageDataResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public async Task<ProductPageDataResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDto);
            var productUpdated = await _productRepository.UpdateProductAsync(product);
            var categories = await _productRepository.GetCategoriesAsync();
            var productDto = _mapper.Map<ProductDto>(productUpdated);
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
