using System.Text.Json;
using System.Text.Json.Serialization;

namespace Notion;

public partial class NotionAPI
{
    public async ValueTask<UsersAPIResponse?> UsersAsync()
    {
        var response = await httpClient.GetAsync("users");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<UsersAPIResponse>(content);
    }

    [Serializable]
    public class UsersAPIResponse
    {
        [JsonPropertyName("object")]
        public string Object { get; set; } = string.Empty;

        [JsonPropertyName("results")]
        public List<User> Results { get; set; } = new List<User>();
    }
}
