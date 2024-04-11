using Company.Project.Core.AppServices;
using Company.Project.Core.ValueObjects;
using Company.Project.ProductDomain.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.AppServices
{
    public interface IProductAppService : IAppService
    {
        OperationResult<ProductDTO> Create(ProductDTO item);
        OperationResult<IEnumerable<ProductDTO>> GetAllProducts();
        //OperationResult<IEnumerable<ProductDTO>> InsertProduct();
    }
}
