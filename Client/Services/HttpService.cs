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

public class HttpService<T> : IDisposable, IHttpService<T> where T : class
{

    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = string.Empty;
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };

    public HttpService()
    {
        _baseUrl = $"https://runstore-e099.restdb.io/rest/";
        _httpClient = new();
        _httpClient.BaseAddress = new Uri(_baseUrl);
        _httpClient.DefaultRequestHeaders.Add("Cache-Control", "none");
        _httpClient.DefaultRequestHeaders.Add("x-apikey", "1b7483a98fd04f94728ae3454d83fd4eea118");
    }

    public async Task Delete(string resource, string id)
    {
        try
        {
            //  using HttpClient client = RestDBClient.DBClient();

            var url = $"{resource}/{id}";

            // await client.DeleteAsync(url);
            await _httpClient.DeleteAsync(_baseUrl + url);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }

    public async Task<List<T>> Get(string resource)
    {
        //  using HttpClient client = RestDBClient.DBClient();
        // var response = await client.GetAsync(resource);
        var response = await _httpClient.GetAsync(resource);
        if (!response.IsSuccessStatusCode)
            return [];

        var result = await response.Content.ReadAsStringAsync();

        var dataList = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];

        return dataList;

    }

    public async Task<T> Get(string resource, string predicate)
    {
        try
        {
            var url = $"{resource}?q={predicate}"; // concat the baseurl with resource and the queryparameter
            using HttpClient client = RestDBClient.DBClient();
            // var response = await client.GetAsync(url);
            var response = await _httpClient.GetAsync(_baseUrl + url);
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
          //  using HttpClient client = RestDBClient.DBClient();
          //  await client.PostAsJsonAsync<T>(resourse, data);
            await _httpClient.PostAsJsonAsync<T>(resourse, data);
        }
        catch (Exception ex)
        { // throw ex  up in the stack
            throw new Exception(ex.Message);
        }
    }

    public async Task Put(string resource, T data, string objectId)
    {
        try
        {
            // using HttpClient client = RestDBClient.DBClient();

            var url = $"{resource}/{objectId}";

            // await client.PutAsJsonAsync<T>(url, data);
            await _httpClient.PutAsJsonAsync<T>(_baseUrl + url, data);
        }
        catch (HttpRequestException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
