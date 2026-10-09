using System;
using System.Collections.Generic;

namespace Client.Interfaces;

public interface IStorage<T> where T : class // The type we use MUST be a class
{
    List<T> Read(string path);
    void Write(string path, List<T> data);
}
