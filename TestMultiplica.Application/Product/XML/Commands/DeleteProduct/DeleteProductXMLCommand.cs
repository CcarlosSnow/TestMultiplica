using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestMultiplica.Util;

namespace TestMultiplica.Application.Product.XML.Commands.DeleteProduct
{
    public class DeleteProductXMLCommand : IDeleteProductXMLCommand
    {
        private readonly IUtil _IUtil;
        private string XMLRoute;
        public DeleteProductXMLCommand(IUtil IUtil)
        {
            _IUtil = IUtil;
            XMLRoute = _IUtil.XMLProduct();
        }
        public DeleteProductXMLModel Execute(int ID)
        {
            XDocument DocumentXML = XDocument.Load(XMLRoute);
            XElement ProductsElement = DocumentXML.Element("Products");
            IEnumerable<XElement> Products = ProductsElement.Elements("Product");
            var ProductResult = Products.Where(x => x.Attribute("ID").Value == ID.ToString()).FirstOrDefault();
            DeleteProductXMLModel Result = new DeleteProductXMLModel();
            Result.ID = int.Parse(ProductResult.Attribute("ID").Value);
            Result.Name = ProductResult.Attribute("Name").Value;
            Result.Description = ProductResult.Attribute("Description").Value;
            Result.Stock = decimal.Parse(ProductResult.Attribute("Stock").Value);
            Result.CategoryID = int.Parse(ProductResult.Attribute("CategoryID").Value);
            ProductResult.Remove();
            DocumentXML.Save(XMLRoute);
            return Result;
        }
    }
}
