using System.Text.Json.Serialization;

namespace NotionAPI;

public partial class NotionAPI
{
    public async ValueTask<UsersAPIResponse?> UsersAsync()
        => await GetAsync<UsersAPIResponse>("users");

    [Serializable]
    public class UsersAPIResponse
    {
        [JsonPropertyName("object")]
        public string Object { get; set; } = string.Empty;

        [JsonPropertyName("results")]
        public List<User> Results { get; set; } = new List<User>();
    }
}
