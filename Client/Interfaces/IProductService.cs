using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces;
// interfaces sysfte är att sätta upp vilka metoder/egenskaper som behövs lose coupled components

public interface IProductService
{
    Task<List<Product>> List(); // vi defierar en regel som säger att om interfacet används så MÅSTE denna meetod implementeras
}
