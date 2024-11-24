using Notion;

class Test
{
    readonly NotionAPI NotionAPI;

    public Test(NotionAPI notionAPI)
    {
        NotionAPI = notionAPI;
    }

    public async ValueTask AllTestsAsync()
    {
        await UserAPITestAsync();
        await SearchAPITestAsync();
    }

    async ValueTask UserAPITestAsync()
    {
        var response = await NotionAPI.UserAsync();

        ArgumentNullException.ThrowIfNull(response);

        foreach (var user in response.Results) {
            Console.WriteLine($"Name: {user.Name}, Email: {user.Person.Email}, Type: {user.Type}");
        }
    }

    async ValueTask SearchAPITestAsync()
    {
        var response = await NotionAPI.SearchAsync(new ());

        ArgumentNullException.ThrowIfNull(response);

        foreach (var result in response.Results) {
            if (result.Properties.Title.Title.Count > 0) {
                Console.WriteLine($"{result.Properties.Title.Title[0].PlainText}, URL: {result.URL}");
            }
        }
    }
}
