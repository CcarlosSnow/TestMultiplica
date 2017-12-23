using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestMultiplica.Util;

namespace TestMultiplica.Application.Category.XML.Queries.GetCategoryByID
{
    public class GetCategoryByIDXMLQuery : IGetCategoryByIDXMLQuery
    {
        private readonly IUtil _IUtil;
        private string XMLRoute;
        public GetCategoryByIDXMLQuery(IUtil IUtil)
        {
            _IUtil = IUtil;
            XMLRoute = _IUtil.XMLCategory();
        }
        public GetCategoryByIDXMLModel Execute(int ID)
        {
            XDocument DocumentXML = XDocument.Load(XMLRoute);
            XElement CategoriesElement = DocumentXML.Element("Categories");
            IEnumerable<XElement> Categories = CategoriesElement.Elements("Category");
            var CategoryResult = Categories.Select(x => new GetCategoryByIDXMLModel()
                { ID = int.Parse(x.Attribute("ID").Value), Description = x.Attribute("Description").Value }).Where(x => x.ID == ID).FirstOrDefault();
            return CategoryResult;
        }
    }
}
