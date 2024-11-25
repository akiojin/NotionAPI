namespace NotionAPI;

using Microsoft.Extensions.DependencyInjection;

public static class NotionAPIExtensions
{
    static string NotionAPISecret => Environment.GetEnvironmentVariable("NOTION_API_SECRET") ?? throw new InvalidOperationException("NOTION_API_SECRET is not set.");

    public static IServiceCollection AddNotionAPI(this IServiceCollection services, string name)
    {
        services
            .AddSingleton(sp => new NotionAPI(sp.GetRequiredService<IHttpClientFactory>().CreateClient(name)))
            .AddHttpClient(name, client => {
                client.BaseAddress = new Uri("https://api.notion.com/v1/");
                client.DefaultRequestHeaders.Add("Authorization", NotionAPISecret);
                client.DefaultRequestHeaders.Add("Notion-Version", "2022-06-28");
            });

        return services;
    }
}
