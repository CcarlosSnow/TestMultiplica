using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.IO;
using TestMultiplica.Util.Models;

namespace TestMultiplica.Util
{
    public class Util : IUtil
    {
        public bool GenerateXMLSeed()
        {
            List<Category> SeedCategory = new List<Category>();
            if (!File.Exists(XMLCategory()))
            {
                SeedCategory.Add(new Category() { ID = 1, Description = "Category 1" });
                SeedCategory.Add(new Category() { ID = 2, Description = "Category 2" });
                SeedCategory.Add(new Category() { ID = 3, Description = "Category 3" });

                XDocument Doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", null),
                    new XElement("Categories",
                        from s in SeedCategory
                        select new XElement("Category", new XAttribute("ID", s.ID),
                        new XAttribute("Description", s.Description))));

                Doc.Save(XMLCategory());
            }

            List<Product> SeedProduct = new List<Product>();
            if (!File.Exists(XMLProduct()))
            {
                SeedProduct.Add(new Product() { ID = 1, Name = "Product 1", Description = "Product 1", Stock = 10, CategoryID = 1 });

                XDocument Doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", null),
                    new XElement("Products",
                        from s in SeedProduct
                        select new XElement("Product", new XAttribute("ID", s.ID),
                        new XAttribute("Name", s.Name),
                        new XAttribute("Description", s.Description),
                        new XAttribute("Stock", s.Stock),
                        new XAttribute("CategoryID", s.CategoryID))));

                Doc.Save(XMLProduct());
            }

            return true;
        }

        public string XMLCategory()
        {
            return ConfigurationManager.AppSettings["XMLRoute"] + ConfigurationManager.AppSettings["XMLCategory"];
        }

        public string XMLProduct()
        {
            return ConfigurationManager.AppSettings["XMLRoute"] + ConfigurationManager.AppSettings["XMLProduct"];
        }
    }
}
