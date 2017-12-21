using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultiplica.Application.Product.Commands.UpdateProduct
{
    public interface IUpdateProductCommand
    {
        UpdateProductModel Execute(int ID, UpdateProductCommandModel Model);
    }
}
