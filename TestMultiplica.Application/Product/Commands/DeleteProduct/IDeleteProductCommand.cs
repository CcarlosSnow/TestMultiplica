using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultiplica.Application.Product.Commands.DeleteProduct
{
    public interface IDeleteProductCommand
    {
        DeleteProductModel Execute(int ID);
    }
}
