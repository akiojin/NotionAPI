namespace NotionAPI;

public partial class NotionAPI
{
    readonly HttpClient httpClient;

    public NotionAPI(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
}
