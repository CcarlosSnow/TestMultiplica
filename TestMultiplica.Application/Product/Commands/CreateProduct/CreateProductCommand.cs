using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMultiplica.Data;
using AutoMapper;

namespace TestMultiplica.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : ICreateProductCommand
    {
        private TestMultiplicaEntities _Entities;
        public CreateProductCommand()
        {

        }
        public CreateProductModel Execute(CreateProductCommandModel Product)
        {
            using (_Entities = new TestMultiplicaEntities())
            {
                var product = Mapper.Map<Data.Product>(Product);
                _Entities.Product.Add(product);
                _Entities.SaveChanges();

                var productResult = Mapper.Map<CreateProductModel>(product);

                return productResult;
            }
        }
    }
}
