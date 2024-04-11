using Company.Project.ProductDomain.Repository;
using Company.Project.ProductDomain.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Configuration
{ /// <summary>
  /// Unit of work service
  /// </summary>
    public static class ExtensionUnitOfWorkService
    {
        /// <summary>
        /// Registers the repositories.
        /// </summary>
        /// <param name="service">The service collection.</param>
		public static void RegisterRepositories(this IServiceCollection service)
        {
            service.AddSingleton<IProductRepository, ProductRepository>();
            service.AddSingleton<IProductUnitOfWork, ProductUnitOfWork>();
        }
    }
}
