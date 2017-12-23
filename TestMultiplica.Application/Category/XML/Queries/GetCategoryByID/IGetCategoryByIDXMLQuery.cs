using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultiplica.Application.Category.XML.Queries.GetCategoryByID
{
    public interface IGetCategoryByIDXMLQuery
    {
        GetCategoryByIDXMLModel Execute(int ID);
    }
}
