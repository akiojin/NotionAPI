namespace NotionAPI.Tests;

class Test
{
    readonly NotionAPI NotionAPI;

    public Test(NotionAPI notionAPI)
    {
        NotionAPI = notionAPI;
    }

    public async ValueTask AllTestsAsync()
    {
        try {
            await UserAPITestAsync();
            await SearchAPITestAsync();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        } finally {
            Console.WriteLine("All tests completed");
        }
    }

    async ValueTask UserAPITestAsync()
    {
        var response = await NotionAPI.UsersAsync();

        ArgumentNullException.ThrowIfNull(response);

        foreach (var user in response.Results) {
            Console.WriteLine($"Name: {user.Name}, Email: {user.Person.Email}, Type: {user.Type}");
        }
    }

    async ValueTask SearchAPITestAsync()
    {
        string? cursor = null;

        do {
            var response = await NotionAPI.SearchAsync(new () {
                StartCursor = cursor,
            });

            ArgumentNullException.ThrowIfNull(response);

            foreach (var result in response.Results) {
                if (result.Properties.Title.Title.Count > 0) {
                    Console.WriteLine($"{result.Properties.Title.Title[0].PlainText}, URL: {result.URL}");
                }
            }

            cursor = response.NextCursor;
        } while (!string.IsNullOrEmpty(cursor));
    }
}
