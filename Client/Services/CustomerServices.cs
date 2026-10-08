using System;
using System.Collections.Generic;
using Client.Models;

namespace Client.Services;

public class CustomerServices
{
    public static List<Customer> ListAllCustomers()
    {
        return [
            new Customer{Name = "Hannes Alexandersson", Address = "Munkebäcksgatan 23 H", PhoneNumber = "0790112009"},
            new Customer{Name = "Arne Gustafsson", Address = "Storgatan 12", PhoneNumber = "0709557799"},
            new Customer{Name = "Rune Andersson", Address = "Avenyn 13", PhoneNumber = "0702017273"},
            new Customer{Name = "Ewa Josefsson", Address = "BoråsVägen 5", PhoneNumber = "0790561879"}
        ];
    }
}
