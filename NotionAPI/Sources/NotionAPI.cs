using System.Text.Json;

namespace Notion;

public partial class NotionAPI
{
    readonly HttpClient httpClient;

    public NotionAPI(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
}
