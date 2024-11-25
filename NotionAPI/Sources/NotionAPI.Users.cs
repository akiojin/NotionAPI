using System.Text.Json.Serialization;

namespace NotionAPI;

public partial class NotionAPIService
{
    /// <summary>
    /// Returns a paginated list of Users for the workspace.
    /// The response may contain fewer than page_size of results.
    /// Guests are not included in the response.
    /// </summary>
    /// <param name="startCursor">
    /// If supplied, this endpoint will return a page of results starting after the cursor provided.
    /// If not supplied, this endpoint will return the first page of results.
    /// </param>
    /// <param name="pageSize">
    /// The number of items from the full list desired in the response.
    /// Maximum: 100
    /// </param>
    /// <returns></returns>
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
