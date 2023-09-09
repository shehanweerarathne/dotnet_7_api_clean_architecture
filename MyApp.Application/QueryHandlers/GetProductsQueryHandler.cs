using AutoMapper;
using MediatR;
using MyApp.Application.Queries;
using MyApp.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Application.ResponseDTOs;
using MyApp.Domain.DTOs;

namespace MyApp.Application.QueryHandlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductListPageDataResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        public async Task<ProductListPageDataResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            
            List<ProductDto> productDtos =  _mapper.Map<List<ProductDto>>(await _productRepository.GetProductsAsync());
            List<CategoryDto> categoryDtos = _mapper.Map<List<CategoryDto>>(await _productRepository.GetCategoriesAsync());
            // map categoryDtos to SelectDtos
            List<SelectDto> selectDtos = categoryDtos.Select(c => new SelectDto { Value = c.Id, Label = c.Name }).ToList();
           
            return new ProductListPageDataResponse(productDtos, selectDtos);
        }
      
    }
}
