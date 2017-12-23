using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestMultiplica.Util;

namespace TestMultiplica.Application.Product.XML.Commands.UpdateProduct
{
    public class UpdateProductXMLCommand : IUpdateProductXMLCommand
    {
        private readonly IUtil _IUtil;
        private string XMLRoute;

        public UpdateProductXMLCommand(IUtil IUtil)
        {
            _IUtil = IUtil;
            XMLRoute = _IUtil.XMLProduct();
        }

        public UpdateProductXMLModel Execute(int ID, UpdateProductXMLCommandModel Model)
        {
            XDocument DocumentXML = XDocument.Load(XMLRoute);
            XElement ProductsElement = DocumentXML.Element("Products");
            IEnumerable<XElement> Products = ProductsElement.Elements("Product");
            var ProductResult = Products.Where(x => x.Attribute("ID").Value == ID.ToString()).FirstOrDefault();
            ProductResult.Attribute("Name").SetValue(Model.Name);
            ProductResult.Attribute("Description").SetValue(Model.Description);
            ProductResult.Attribute("Stock").SetValue(Model.Stock);
            ProductResult.Attribute("CategoryID").SetValue(Model.CategoryID);
            DocumentXML.Save(XMLRoute);
            UpdateProductXMLModel Result = new UpdateProductXMLModel();
            Result = Mapper.Map<UpdateProductXMLModel>(Model);
            return Result;
        }
    }
}
