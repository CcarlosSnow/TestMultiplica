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
using TestMultiplica.Application.Category.Queries.GetCategories;

namespace TestMultiplica.Services.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly IGetCategoriesQuery _IGetCategoriesQuery;
        public CategoriesController(IGetCategoriesQuery IGetCategoriesQuery)
        {
            _IGetCategoriesQuery = IGetCategoriesQuery;
        }
        // GET: api/Categories
        public List<GetCategoriesModel> GetCategory()
        {
            return _IGetCategoriesQuery.Execute();
        }
    }
}