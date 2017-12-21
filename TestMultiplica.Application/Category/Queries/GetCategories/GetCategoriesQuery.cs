using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TestMultiplica.Application.Category.Queries.GetCategories
{
    public class GetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly IMapper _Mapper;

        public GetCategoriesQuery(IMapper Mapper)
        {
            _Mapper = Mapper;
        }
        public IEnumerable<GetCategoriesModel> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
