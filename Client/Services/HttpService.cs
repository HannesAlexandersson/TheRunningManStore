using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Helpers;
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
        /* var url = $"https://runstore-e099.restdb.io/rest/{resource}";

        // skapa en instance av Http client klassen
        using HttpClient client = new(); // we want this to be cleaned up when we are done with it. we need the garbage collector to close this, with "using". 

        client.BaseAddress = new Uri(url); // convert the url to uri
        client.DefaultRequestHeaders.Add("Cache-Control", "none");
        client.DefaultRequestHeaders.Add("x-apikey", "1b7483a98fd04f94728ae3454d83fd4eea118"); */

        //send the package
        /*  var response = await client.GetAsync(url);

         if (!response.IsSuccessStatusCode) return [];

         var result = await response.Content.ReadAsStringAsync();
         var data = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];
         //return JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];
         return data; */

        using HttpClient client = RestDBClient.DBClient();
        var response = await client.GetAsync(resource);
        if (!response.IsSuccessStatusCode)
            return [];

        var result = await response.Content.ReadAsStringAsync();

        var data = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];

        return data;

    }

    public async Task<T> Get(string resource, string predicate)
    {
        try
        {
            var url = $"{resource}?q={predicate}"; // concat the baseurl with resource and the queryparameter
            using HttpClient client = RestDBClient.DBClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync(); // this could be null so we need to check null 
                if (string.IsNullOrWhiteSpace(result))
                {
                    throw new Exception("Nothing to GET with this itemnumber");
                }

                var data = JsonSerializer.Deserialize<List<T>>(result, _options)!;
                return data[0];
            }

            throw new Exception("Something happenend: " + response.StatusCode);
        }
        catch (Exception ex)
        {
            //throw the ex up in the stack
            throw new Exception(ex.Message);
        }
    }

    public async Task Post(string resourse, T data)
    {
        try
        { //use the new client class
            using HttpClient client = RestDBClient.DBClient();
            await client.PostAsJsonAsync<T>(resourse, data);
        }
        catch (Exception ex)
        { // throw ex  up in the stack
            throw new Exception(ex.Message);
        }
    }
}
