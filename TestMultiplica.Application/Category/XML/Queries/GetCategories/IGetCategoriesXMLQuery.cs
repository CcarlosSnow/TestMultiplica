using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultiplica.Application.Category.XML.Queries.GetCategories
{
    public interface IGetCategoriesXMLQuery
    {
        List<GetCategoriesXMLModel> Execute();
    }
}
