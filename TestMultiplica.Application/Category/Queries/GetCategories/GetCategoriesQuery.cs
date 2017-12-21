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
        private readonly IMapper _Mapper;
        private TestMultiplicaEntities _Entities;

        public GetCategoriesQuery(IMapper Mapper)
        {
            _Mapper = Mapper;
        }
        public List<GetCategoriesModel> Execute()
        {
            using (_Entities = new TestMultiplicaEntities())
            {
                var categories = _Entities.Category.ToList();
                var resultCategories = _Mapper.Map<List<Data.Category>, List<GetCategoriesModel>>(categories);
                return resultCategories;
            }
        }
    }
}
