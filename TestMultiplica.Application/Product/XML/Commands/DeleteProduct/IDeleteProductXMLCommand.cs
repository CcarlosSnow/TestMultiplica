using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultiplica.Application.Product.XML.Commands.DeleteProduct
{
    public interface IDeleteProductXMLCommand
    {
        DeleteProductXMLModel Execute(int ID);
    }
}
