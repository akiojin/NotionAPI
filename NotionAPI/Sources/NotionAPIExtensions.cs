using Microsoft.Extensions.DependencyInjection;

namespace NotionAPI;

public static class NotionAPIExtensions
{
    public static IServiceCollection AddNotionAPI(this IServiceCollection services, string name)
    {
        services
            .AddSingleton(sp => new NotionAPI(sp.GetRequiredService<IHttpClientFactory>().CreateClient(name)))
            .AddHttpClient(name, client => {
                client.BaseAddress = new Uri("https://api.notion.com/v1/");
                client.DefaultRequestHeaders.Add("Authorization", Environment.GetEnvironmentVariable("NOTION_API_SECRET"));
                client.DefaultRequestHeaders.Add("Notion-Version", "2022-06-28");
            });

        return services;
    }
}
