using Company.Project.Core.Domain.Repository;
using Company.Project.ProductDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
    public interface IProductRepository:IRepository<Product>
    {
    }
}
