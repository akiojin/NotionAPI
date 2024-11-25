namespace NotionAPI;

using Microsoft.Extensions.DependencyInjection;

public static class NotionAPIExtensions
{
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
    public static IServiceCollection AddNotionAPIService(this IServiceCollection services)
    {
        services.AddHttpClient<NotionAPIService>();

        return services;
    }
}
