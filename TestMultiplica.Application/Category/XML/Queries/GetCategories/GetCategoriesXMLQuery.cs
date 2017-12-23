using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestMultiplica.Data;
using System.Xml.Linq;
using System.IO;
using TestMultiplica.Util;

namespace TestMultiplica.Application.Category.XML.Queries.GetCategories
{
    public class GetCategoriesXMLQuery : IGetCategoriesXMLQuery
    {
        private readonly IUtil _IUtil;
        private string XMLRoute;
        public GetCategoriesXMLQuery(IUtil IUtil)
        {
            _IUtil = IUtil;
            XMLRoute = _IUtil.XMLCategory();
        }
        public List<GetCategoriesXMLModel> Execute()
        {
            XDocument DocumentXML = XDocument.Load(XMLRoute);
            XElement CategoriesElement = DocumentXML.Element("Categories");
            IEnumerable<XElement> Categories = CategoriesElement.Elements("Category");
            var CategoriesResult = Categories.Select(x => new GetCategoriesXMLModel() { ID = int.Parse(x.Attribute("ID").Value), Description = x.Attribute("Description").Value });
            return CategoriesResult.ToList();
        }
    }
}
