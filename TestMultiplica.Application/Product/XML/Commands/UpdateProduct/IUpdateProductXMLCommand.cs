using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultiplica.Application.Product.XML.Commands.UpdateProduct
{
    public interface IUpdateProductXMLCommand
    {
        UpdateProductXMLModel Execute(int ID, UpdateProductXMLCommandModel Model);
    }
}
