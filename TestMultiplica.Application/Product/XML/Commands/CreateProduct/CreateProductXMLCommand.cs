using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestMultiplica.Util;

namespace TestMultiplica.Application.Product.XML.Commands.CreateProduct
{
    public class CreateProductXMLCommand : ICreateProductXMLCommand
    {
        private readonly IUtil _IUtil;
        private string XMLRoute;

        public CreateProductXMLCommand(IUtil IUtil)
        {
            _IUtil = IUtil;
            XMLRoute = _IUtil.XMLProduct();
        }
        public CreateProductXMLModel Execute(CreateProductXMLCommandModel Model)
        {
            XDocument DocumentXML = XDocument.Load(XMLRoute);
            XElement ProductsElement = DocumentXML.Element("Products");
            XElement Products = ProductsElement.Elements("Product").Last();
            int LastProductID = int.Parse(Products.Attribute("ID").Value);
            LastProductID += 1;
            ProductsElement.Add(new XElement("Product", 
                new XAttribute("ID", LastProductID),
                new XAttribute("Name", Model.Name),
                new XAttribute("Description", Model.Description),
                new XAttribute("Stock", Model.Stock),
                new XAttribute("CategoryID", Model.CategoryID)));
            DocumentXML.Save(XMLRoute);
            CreateProductXMLModel Result = new CreateProductXMLModel();
            Result = Mapper.Map<CreateProductXMLModel>(Model);
            Result.ID = LastProductID;
            return Result;
        }
    }
}
