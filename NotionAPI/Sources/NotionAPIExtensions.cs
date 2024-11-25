namespace NotionAPI;

using Microsoft.Extensions.DependencyInjection;

public static class NotionAPIExtensions
{
    static string NotionAPISecret => Environment.GetEnvironmentVariable("NOTION_API_SECRET") ??
        throw new InvalidOperationException("NOTION_API_SECRET is not set.");

    /// <summary>
    /// HTTP クライアントを登録する。
    /// このメソッドを使用するためには、環境変数の <c>NOTION_API_SECRET</c> に Notion API のシークレットを設定する必要がある。
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="httpClientName">
    /// HTTP クライアントに設定する名前。
    /// NotionAPI では、内部でこの名前が設定された HTTP クライアントを使用する。
    /// </param>
    /// <returns></returns>
    public static IServiceCollection AddNotionAPI(this IServiceCollection services, string httpClientName)
    {
        services
            .AddSingleton(serviceProvider => new NotionAPI(serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient(httpClientName)))
            .AddHttpClient(httpClientName, client => {
                client.BaseAddress = new Uri(NotionAPI.BaseURL);
                client.DefaultRequestHeaders.Add("Authorization", NotionAPISecret);
                client.DefaultRequestHeaders.Add("Notion-Version", NotionAPI.Version);
            });

        return services;
    }
}
