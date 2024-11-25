namespace NotionAPI;

using System.Text.Json;
using System.Text;

public partial class NotionAPI(HttpClient httpClient)
{
    public const string BaseURL = "https://api.notion.com/v1/";
    public const string Version = "2022-06-28";

    readonly HttpClient httpClient = httpClient;

    async ValueTask<TResponse?> ProcessResponse<TResponse>(Func<ValueTask<HttpResponseMessage>> process)
    {
        var response = await process();

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TResponse>(content);
    }

    async ValueTask<TResponse?> GetAsync<TResponse>(string endpoint)
        => await ProcessResponse<TResponse>(async () => await httpClient.GetAsync(endpoint));

    async ValueTask<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        // 明示的に application/json を指定しないと、
        // start_cursor が正常に認識されず、同じカーソル位置が返される。
        // 指定しなかった場合、それ以外のパラメーターは正常なので、恐らくバグ。
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await ProcessResponse<TResponse>(async () => await httpClient.PostAsync(endpoint, content));
    }
}
