using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Interfaces;

namespace Client.Services;

public class HttpService<T> : IHttpService<T> where T : class
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };
    public async Task<List<T>> Get(string resource)
    {
        var url = $"https://runstore-e099.restdb.io/rest/{resource}";

        // skapa en instance av Http client klassen
        using HttpClient client = new(); // we want this to be cleaned up when we are done with it. we need the garbage collector to close this, with "using". 

        client.BaseAddress = new Uri(url); // convert the url to uri
        client.DefaultRequestHeaders.Add("Cache-Control", "none");
        client.DefaultRequestHeaders.Add("x-apikey", "1b7483a98fd04f94728ae3454d83fd4eea118");

        //send the package
        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode) return [];

        var result = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];
        //return JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];
        return data;
    }

    public Task Post(string resourse, T data)
    {
        throw new NotImplementedException();
    }
}
