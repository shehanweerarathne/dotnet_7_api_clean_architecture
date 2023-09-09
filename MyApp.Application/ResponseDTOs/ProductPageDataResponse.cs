using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.DTOs;

namespace MyApp.Application.ResponseDTOs
{
    public class ProductPageDataResponse
    {
        public List<SelectDto>? Categories { get; set; }
        public ProductDto? Product { get; set; }
    }
}
