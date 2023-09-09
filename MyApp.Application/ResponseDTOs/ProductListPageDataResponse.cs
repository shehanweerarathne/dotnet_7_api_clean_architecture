using MyApp.Domain.DTOs;

namespace MyApp.Application.ResponseDTOs;

public record ProductListPageDataResponse(List<ProductDto> products, List<SelectDto> categories);