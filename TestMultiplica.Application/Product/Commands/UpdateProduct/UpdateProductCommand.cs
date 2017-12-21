using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMultiplica.Data;
using System.Data.Entity;

namespace TestMultiplica.Application.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IUpdateProductCommand
    {
        private TestMultiplicaEntities _Entities;

        public UpdateProductCommand()
        {

        }
        public UpdateProductModel Execute(int ID, UpdateProductCommandModel Model)
        {
            using (_Entities = new TestMultiplicaEntities())
            {
                var product = _Entities.Product.Find(ID);
                Mapper.Map<UpdateProductCommandModel, Data.Product>(Model, product);
                _Entities.Product.Attach(product);
                _Entities.Entry(product).State = EntityState.Modified;
                _Entities.SaveChanges();

                var productResult = Mapper.Map<UpdateProductModel>(product);

                return productResult;
            }
        }
    }
}
