using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestMultiplica.Data;

namespace TestMultiplica.Application.Category.Queries.GetCategories
{
    public class GetCategoriesQuery : IGetCategoriesQuery
    {
        private TestMultiplicaEntities _Entities;

        public GetCategoriesQuery()
        {

        }
        public List<GetCategoriesModel> Execute()
        {
            using (_Entities = new TestMultiplicaEntities())
            {
                var categories = _Entities.Category.ToList();
                var resultCategories = Mapper.Map<List<GetCategoriesModel>>(categories);
                return resultCategories;
            }
        }
    }
}
