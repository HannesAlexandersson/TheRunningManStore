using System;
using System.Collections.Generic;
using Client.Models;

namespace Client.Interfaces;
// interfaces sysfte är att sätta upp vilka metoder/egenskaper som behövs lose coupled components

public interface IProductService
{
    List<Product> List(); // vi defierar en regel som säger att om interfacet används så MÅSTE denna meetod implementeras
}
