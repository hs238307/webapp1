using Company.Project.Core.Data.DataAccess;
using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductDomainDbContext context) : base(context)
        {
        }
    }
}
