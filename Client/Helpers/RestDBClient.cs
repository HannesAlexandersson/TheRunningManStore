using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Client.Helpers;

public class RestDBClient
{
    public static HttpClient DBClient()
    {
        HttpClient client = new()
        {
            BaseAddress = new Uri("https://runstore-e099.restdb.io/rest/")
        };

        client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
        client.DefaultRequestHeaders.Add("x-apikey", "1b7483a98fd04f94728ae3454d83fd4eea118");

        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        return client;
    }
}
