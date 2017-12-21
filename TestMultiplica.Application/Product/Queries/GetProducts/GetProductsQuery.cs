using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMultiplica.Data;
using TestMultiplica.Application.Category.Queries.GetCategories;

namespace TestMultiplica.Application.Product.Queries.GetProducts
{
    public class GetProductsQuery : IGetProductsQuery
    {
        private TestMultiplicaEntities _Entities;
        private readonly IGetCategoriesQuery _IGetCategoriesQuery;

        public GetProductsQuery(IGetCategoriesQuery IGetCategoriesQuery)
        {
            _IGetCategoriesQuery = IGetCategoriesQuery;
        }
        public List<GetProductsModel> Execute()
        {
            using (_Entities = new TestMultiplicaEntities())
            {
                var products = _Entities.Product.ToList();
                var resultProducts = Mapper.Map<List<GetProductsModel>>(products);

                return GetCategoryDescription(resultProducts);
            }
        }

        private List<GetProductsModel> GetCategoryDescription(List<GetProductsModel> products)
        {
            var categories = _IGetCategoriesQuery.Execute();
            var categoriesDictionary = categories == null ? new Dictionary<int, string>() : categories.ToDictionary(x => x.ID, x => x.Description);

            foreach (var item in products)
            {
                item.CategoryName = categoriesDictionary[item.CategoryID];
            }

            return products;
        }
    }
}
