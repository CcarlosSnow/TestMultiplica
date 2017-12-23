using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestMultiplica.Util;
using TestMultiplica.Application.Category.XML.Queries.GetCategoryByID;

namespace TestMultiplica.Application.Product.XML.Queries.GetProducts
{
    public class GetProductsXMLQuery : IGetProductsXMLQuery
    {
        private readonly IUtil _IUtil;
        private readonly IGetCategoryByIDXMLQuery _IGetCategoryByIDXMLQuery;
        private string XMLRoute;

        public GetProductsXMLQuery(IUtil IUtil, IGetCategoryByIDXMLQuery IGetCategoryByIDXMLQuery)
        {
            _IUtil = IUtil;
            _IGetCategoryByIDXMLQuery = IGetCategoryByIDXMLQuery;
            XMLRoute = _IUtil.XMLProduct();
        }
        public List<GetProductsXMLModel> Execute()
        {
            XDocument DocumentXML = XDocument.Load(XMLRoute);
            XElement ProductsElement = DocumentXML.Element("Products");
            IEnumerable<XElement> Products = ProductsElement.Elements("Product");
            var ProductsResult = Products.Select(x => new GetProductsXMLModel()
            {
                ID = int.Parse(x.Attribute("ID").Value),
                Name = x.Attribute("Name").Value,
                Description = x.Attribute("Description").Value,
                Stock = decimal.Parse(x.Attribute("Stock").Value),
                CategoryID = int.Parse(x.Attribute("CategoryID").Value),
                CategoryName = _IGetCategoryByIDXMLQuery.Execute(int.Parse(x.Attribute("CategoryID").Value)).Description
            });
            return ProductsResult.ToList();
        }
    }
}
