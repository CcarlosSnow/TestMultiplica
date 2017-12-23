using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestMultiplica.Util;

namespace TestMultiplica.Application.Product.XML.Queries.GetProductByID
{
    public class GetProductByIDXMLQuery : IGetProductByIDXMLQuery
    {
        private readonly IUtil _IUtil;
        private string XMLRoute;
        public GetProductByIDXMLQuery(IUtil IUtil)
        {
            _IUtil = IUtil;
            XMLRoute = _IUtil.XMLProduct();
        }

        public GetProductByIDXMLModel Execute(int ID)
        {
            XDocument DocumentXML = XDocument.Load(XMLRoute);
            XElement ProductsElement = DocumentXML.Element("Products");
            IEnumerable<XElement> Products = ProductsElement.Elements("Product");
            var ProductResult = Products.Select(x => new GetProductByIDXMLModel()
            {
                ID = int.Parse(x.Attribute("ID").Value),
                Name = x.Attribute("Name").Value,
                Description = x.Attribute("Description").Value,
                Stock = int.Parse(x.Attribute("Stock").Value),
                CategoryID = int.Parse(x.Attribute("CategoryID").Value)
            }).Where(x => x.ID == ID).FirstOrDefault();
            return ProductResult;
        }
    }
}
