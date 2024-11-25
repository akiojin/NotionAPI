using System.Text.Json.Serialization;

namespace NotionAPI;

public partial class NotionAPI
{
    public async ValueTask<UsersAPIResponse?> UsersAsync(string? startCursor = null, int pageSize = 100)
    {
        var queryParameters = new List<string>();

        if (!string.IsNullOrWhiteSpace(startCursor)) {
            queryParameters.Add($"start_cursor={Uri.EscapeDataString(startCursor)}");
        }
        
        if (pageSize != 100) {
            queryParameters.Add($"page_size={pageSize}");
        }

        var query = queryParameters.Count > 0 ? "?" + string.Join("&", queryParameters) : string.Empty;
        var endpoint = $"users{query}";

        return await GetAsync<UsersAPIResponse>(endpoint);
    }

    [Serializable]
    public class UsersAPIResponse
    {
        [JsonPropertyName("object")]
        public string Object { get; set; } = string.Empty;

        [JsonPropertyName("results")]
        public List<User> Results { get; set; } = [];
    }
}
