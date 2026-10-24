using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Interfaces;

public interface IHttpService<T> where T : class
{// task betyder "vis ak göra en uppgift som vi inte kommer att vänta på

    Task Delete(string resource, string id);
    Task<List<T>> Get(string resource); // för att detta ska bli generiskt tar vi in en resurs externt. resourse resperesents allt ex products, customers, orders osv. det kanv ara vad som helts
                                        // send data apcket to restDB with POST
                                        // overloaded Get method
    Task<T> Get(string resource, string predicate); // return a single entitet, take an extra argumnet. 
    Task Post(string resourse, T data); // we send something of the type T 

    Task Put(string resource, T data, string _objectId);
}
