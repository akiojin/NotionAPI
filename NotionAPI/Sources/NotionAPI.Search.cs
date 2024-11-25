namespace NotionAPI;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public partial class NotionAPI
{
    public async ValueTask<SearchAPIResponse?> SearchAsync(SearchAPIRequest request)
        => await PostAsync<SearchAPIRequest, SearchAPIResponse>("search", request);

    /// <summary>
    /// Search by title
    /// </summary>
    /// <see href="https://developers.notion.com/reference/post-search"/>
    [Serializable]
    public class SearchAPIRequest
    {
        public const int Max_Page_Size = 100;

        /// <summary>
        /// The text that the API compares page and database titles against.
        /// </summary>
        [JsonPropertyName("query")]
        public string Query { get; set; } = string.Empty;

        /// <summary>
        /// A set of criteria, direction and timestamp keys, that orders the results.
        /// The only supported timestamp value is "last_edited_time".
        /// Supported direction values are "ascending" and "descending".
        /// If sort is not provided, then the most recently edited results are returned first.
        /// </summary>
        [JsonPropertyName("sort")]
        public SearchSort Sort { get; set; } = new ();

        /// <summary>
        /// A set of criteria, value and property keys,
        /// that limits the results to either only pages or only databases.
        /// Possible value values are "page" or "database".
        /// The only supported property value is "object".
        /// </summary>
        [JsonPropertyName("filter")]
        public Filter Filter { get; set; } = new ();

        /// <summary>
        /// A cursor value returned in a previous response that If supplied,
        /// limits the response to results starting after the cursor.
        /// If not supplied, then the first page of results is returned.
        /// Refer to pagination for more details.
        /// </summary>
        [JsonPropertyName("start_cursor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StartCursor { get; set; }

        /// <summary>
        /// The number of items from the full list to include in the response.
        /// Maximum: 100.
        /// </summary>
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
        public List<SearchResult> Results { get; set; } = [];

        [JsonPropertyName("next_cursor")]
        public string NextCursor { get; set; } = string.Empty;

        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("page_or_database")]
        public object? PageOrDatabase { get; set; }
    }
}
