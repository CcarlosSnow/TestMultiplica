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
using TestMultiplica.Application.Product.XML.Queries.GetProducts;
using TestMultiplica.Application.Product.XML.Commands.CreateProduct;
using TestMultiplica.Application.Product.XML.Queries.GetProductByID;
using TestMultiplica.Application.Product.XML.Commands.UpdateProduct;
using TestMultiplica.Application.Product.XML.Commands.DeleteProduct;

namespace TestMultiplica.Services.Controllers
{
    public class ProductsXMLController : ApiController
    {
        private readonly IGetProductsXMLQuery _IGetProductsXMLQuery;
        private readonly ICreateProductXMLCommand _ICreateProductXMLCommand;
        private readonly IGetProductByIDXMLQuery _IGetProductByIDXMLQuery;
        private readonly IUpdateProductXMLCommand _IUpdateProductXMLCommand;
        private readonly IDeleteProductXMLCommand _IDeleteProductXMLCommand;

        public ProductsXMLController(
            IGetProductsXMLQuery IGetProductsXMLQuery,
            IGetProductByIDXMLQuery IGetProductByIDXMLQuery,
            ICreateProductXMLCommand ICreateProductXMLCommand,
            IUpdateProductXMLCommand IUpdateProductXMLCommand,
            IDeleteProductXMLCommand IDeleteProductXMLCommand
            )
        {
            _IGetProductsXMLQuery = IGetProductsXMLQuery;
            _IGetProductByIDXMLQuery = IGetProductByIDXMLQuery;
            _ICreateProductXMLCommand = ICreateProductXMLCommand;
            _IUpdateProductXMLCommand = IUpdateProductXMLCommand;
            _IDeleteProductXMLCommand = IDeleteProductXMLCommand;
        }
        // GET: api/ProductsXML
        public List<GetProductsXMLModel> GetProduct()
        {
            return _IGetProductsXMLQuery.Execute();
        }

        // GET: api/ProductsXML/5
        [ResponseType(typeof(GetProductByIDXMLModel))]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _IGetProductByIDXMLQuery.Execute(id);
            return Ok(product);
        }

        // PUT: api/ProductsXML/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, UpdateProductXMLCommandModel product)
        {
            var productResult = _IUpdateProductXMLCommand.Execute(id, product);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //    // POST: api/ProductsXML
        //    [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(CreateProductXMLCommandModel product)
        {
            var productResult = _ICreateProductXMLCommand.Execute(product);
            return Ok(productResult);
        }

        // DELETE: api/ProductsXML/5
        [ResponseType(typeof(DeleteProductXMLModel))]
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = _IDeleteProductXMLCommand.Execute(id);
            return Ok(product);
        }
    }
}