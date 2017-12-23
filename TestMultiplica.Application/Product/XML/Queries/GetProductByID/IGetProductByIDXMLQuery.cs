using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultiplica.Application.Product.XML.Queries.GetProductByID
{
    public interface IGetProductByIDXMLQuery
    {
        GetProductByIDXMLModel Execute(int ID);
    }
}
