using System;
using System.Collections.Generic;
using Client.Models;

namespace Client.Services;

public class ProductServices
{
    public static List<Product> ListAllProducts()
    {
        return [
            new Product{ItemNumber = "1001", Name = "Gel 27", SupplierName = "Basics", Price = 2295},
             new Product{ItemNumber = "1002", Name = "Fabricator", SupplierName = "New Wave", Price = 9999}
        ];
    }
}
