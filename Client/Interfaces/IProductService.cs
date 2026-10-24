using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces;
// interfaces purpose is to set up rules for implementation. if someone want to use the interface they MUST implement these things

public interface IProductService
{
    Task Add(Product product);
    Task Delete(string id);
    Task<ProductRestDb> Find(string itemNumber);
    Task<List<Product>> List();
    Task Update(Product product, string _objectId);
}
