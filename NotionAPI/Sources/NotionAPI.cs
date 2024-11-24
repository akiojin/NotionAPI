using System.Text.Json;

namespace Notion;

public class NotionAPI
{
    readonly HttpClient httpClient;

    public NotionAPI(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async ValueTask<UsersAPIResponse?> UserAsync()
    {
        var response = await httpClient.GetAsync("users");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<UsersAPIResponse>(content);
    }

    public async ValueTask<SearchAPIResponse?> SearchAsync(SearchAPIRequest request)
    {
        var response = await httpClient.PostAsync("search", new StringContent(JsonSerializer.Serialize(request)));

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<SearchAPIResponse>(content);
    }
}
