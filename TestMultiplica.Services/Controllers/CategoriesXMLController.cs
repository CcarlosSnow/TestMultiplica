using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestMultiplica.Data;
using TestMultiplica.Application.Category.XML.Queries.GetCategories;
using TestMultiplica.Application.Category.XML.Queries.GetCategoryByID;

namespace TestMultiplica.Services.Controllers
{
    public class CategoriesXMLController : ApiController
    {
        private readonly IGetCategoriesXMLQuery _IGetCategoriesQuery;
        private readonly IGetCategoryByIDXMLQuery _IGetCategoryByIDXMLQuery;
        public CategoriesXMLController(
            IGetCategoriesXMLQuery IGetCategoriesQuery,
            IGetCategoryByIDXMLQuery IGetCategoryByIDXMLQuery
            )
        {
            _IGetCategoriesQuery = IGetCategoriesQuery;
            _IGetCategoryByIDXMLQuery = IGetCategoryByIDXMLQuery;
        }

        // GET: api/CategoriesXML
        public List<GetCategoriesXMLModel> GetCategory()
        {
            return _IGetCategoriesQuery.Execute();
        }

        public GetCategoryByIDXMLModel GetCategory(int ID)
        {
            return _IGetCategoryByIDXMLQuery.Execute(ID);
        }
    }
}