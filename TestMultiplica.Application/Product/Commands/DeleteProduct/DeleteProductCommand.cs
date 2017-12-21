using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMultiplica.Data;

namespace TestMultiplica.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IDeleteProductCommand
    {
        private TestMultiplicaEntities _Entities;

        public DeleteProductCommand()
        {

        }
        public DeleteProductModel Execute(int ID)
        {
            using (_Entities = new TestMultiplicaEntities())
            {
                var product = _Entities.Product.Find(ID);
                _Entities.Product.Remove(product);
                _Entities.Entry(product).State = EntityState.Deleted;
                _Entities.SaveChanges();

                var productResult = Mapper.Map<DeleteProductModel>(product);

                return productResult;
            }
        }
    }
}
