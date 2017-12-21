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
using TestMultiplica.Application.Product.Queries.GetProducts;
using TestMultiplica.Application.Product.Queries.GetProductByID;
using TestMultiplica.Application.Product.Commands.CreateProduct;
using TestMultiplica.Application.Product.Commands.UpdateProduct;
using TestMultiplica.Application.Product.Commands.DeleteProduct;

namespace TestMultiplica.Services.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IGetProductsQuery _IGetProductsQuery;
        private readonly IGetProductByIDQuery _IGetProductByIDQuery;
        private readonly ICreateProductCommand _ICreateProductCommand;
        private readonly IUpdateProductCommand _IUpdateProductCommand;
        private readonly IDeleteProductCommand _IDeleteProductCommand;
        public ProductsController(IGetProductsQuery IGetProductsQuery,
            IGetProductByIDQuery IGetProductByIDQuery,
            ICreateProductCommand ICreateProductCommand,
            IUpdateProductCommand IUpdateProductCommand,
            IDeleteProductCommand IDeleteProductCommand)
        {
            _IGetProductsQuery = IGetProductsQuery;
            _IGetProductByIDQuery = IGetProductByIDQuery;
            _ICreateProductCommand = ICreateProductCommand;
            _IUpdateProductCommand = IUpdateProductCommand;
            _IDeleteProductCommand = IDeleteProductCommand;
        }
        // GET: api/Products
        public List<GetProductsModel> GetProduct()
        {
            return _IGetProductsQuery.Execute();
        }

        // GET: api/Products/5
        [ResponseType(typeof(GetProductByIDModel))]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _IGetProductByIDQuery.Execute(id);
            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, UpdateProductCommandModel product)
        {
            var productResult = _IUpdateProductCommand.Execute(id, product);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(CreateProductModel))]
        public IHttpActionResult PostProduct(CreateProductCommandModel product)
        {
            var productResult = _ICreateProductCommand.Execute(product);

            return Created(Request.RequestUri, productResult);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = _IDeleteProductCommand.Execute(id);
            return Ok(product);
        }
    }
}