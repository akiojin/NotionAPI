using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Notion;

public partial class NotionAPI
{
    public async ValueTask<SearchAPIResponse?> SearchAsync(SearchAPIRequest request)
    {
        var response = await httpClient.PostAsync("search", new StringContent(JsonSerializer.Serialize(request)));

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<SearchAPIResponse>(content);
    }

    /// <summary>
    /// Search by title
    /// </summary>
    /// <see href="https://developers.notion.com/reference/post-search"/>
    [Serializable]
    public class SearchAPIRequest
    {
        public const int Max_Page_Size = 100;

        [JsonPropertyName("query")]
        public string Query { get; set; } = string.Empty;

        [JsonPropertyName("filter")]
        public Filter Filter { get; set; } = new();

        [JsonPropertyName("sort")]
        public SearchSort Sort { get; set; } = new();

        [JsonPropertyName("start_cursor")]
        public string StartCursor { get; set; } = string.Empty;

        [JsonPropertyName("page_size")]
        [Range(1, Max_Page_Size)]
        public int PageSize { get; set; } = Max_Page_Size;
    }

    /// <summary>
    /// Search by title
    /// </summary>
    /// <see href="https://developers.notion.com/reference/post-search"/>
    [Serializable]
    public class SearchAPIResponse
    {
        [JsonPropertyName("object")]
        public string Object { get; set; } = string.Empty;

        [JsonPropertyName("results")]
        public List<SearchResult> Results { get; set; } = new List<SearchResult>();

        [JsonPropertyName("next_cursor")]
        public string NextCursor { get; set; } = string.Empty;

        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("page_or_database")]
        public object PageOrDatabase { get; set; }
    }
}
