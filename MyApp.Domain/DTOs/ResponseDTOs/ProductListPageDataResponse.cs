using MyApp.Domain.DTOs;

namespace MyApp.Domain.DTOs.ResponseDTOs;

public record ProductListPageDataResponse(List<ProductDto> products, List<SelectDto> categories);