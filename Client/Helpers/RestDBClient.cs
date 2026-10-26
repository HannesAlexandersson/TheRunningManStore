using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Client.Helpers;

public class RestDBClient
{
    public static HttpClient DBClient()
    {
        var config = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
        var baseurl = config.GetSection("Settings:BaseUrl").Value!;
        var key = config.GetSection("Settings:ApiKey").Value!;
        HttpClient client = new()
        {
            BaseAddress = new Uri(baseurl)
        };

        client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
        client.DefaultRequestHeaders.Add("x-apikey", key);

        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        return client;
    }
}
