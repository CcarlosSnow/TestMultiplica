using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultiplica.Application.Category.Queries.GetCategories
{
    interface IGetCategoriesQuery
    {
        IEnumerable<GetCategoriesModel> Execute();
    }
}
