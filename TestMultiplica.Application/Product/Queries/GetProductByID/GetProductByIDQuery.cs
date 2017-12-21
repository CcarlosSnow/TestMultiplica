using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMultiplica.Data;
using AutoMapper;

namespace TestMultiplica.Application.Product.Queries.GetProductByID
{
    public class GetProductByIDQuery : IGetProductByIDQuery
    {
        private TestMultiplicaEntities _Entities;

        public GetProductByIDQuery()
        {

        }
        public GetProductByIDModel Execute(int ID)
        {
            using (_Entities = new TestMultiplicaEntities())
            {
                var product = _Entities.Product.Find(ID);
                var productResult = Mapper.Map<GetProductByIDModel>(product);
                return productResult;
            }
        }
    }
}
