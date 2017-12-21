using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultiplica.Application.Category.Queries.GetCategories
{
    public interface IGetCategoriesQuery
    {
        List<GetCategoriesModel> Execute();
    }
}
