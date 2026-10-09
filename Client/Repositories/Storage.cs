using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Client.Interfaces;
using System.Text.Encodings.Web;

namespace Client.Repositories;

public class Storage<T> : IStorage<T> where T : class
{
    private static readonly JsonSerializerOptions options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase, //set to camelcase
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // allow chars that doesnt is supported by .net
        PropertyNameCaseInsensitive = true
    };

    public List<T> Read(string path)
    {
        try
        {
            string data = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(data) || !string.IsNullOrWhiteSpace(data))
            {
                return JsonSerializer.Deserialize<List<T>>(data, options)!;
            }
            else
            {
                return [];
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Write(string path, List<T> data)
    {
        try
        {
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}
