
using MyApp.Domain.DTOs;

namespace MyApp.Domain.DTOs.ResponseDTOs
{
    public class ProductPageDataResponse
    {
        public List<SelectDto>? Categories { get; set; }
        public ProductDto? Product { get; set; }
    }
}
