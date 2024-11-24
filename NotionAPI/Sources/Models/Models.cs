using System.Text.Json.Serialization;

namespace Notion;

[Serializable]
public class Person
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
}

[Serializable]
public class User
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string ID { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("avatar_url")]
    public string AvatarURL { get; set; } = string.Empty;

    [JsonPropertyName("person")]
    public Person Person { get; set; } = new Person();
}

[Serializable]
public class SearchSort
{
    public const string Ascending = "ascending";
    public const string Descending = "descending";

    [JsonPropertyName("direction")]
    public string Direction { get; set; } = string.Empty;

    [JsonPropertyName("timestamp")]
    public string Timestamp => "last_edited_time";
}

[Serializable]
public class Filter
{
    public const string Page = "page";
    public const string Database = "database";

    [JsonPropertyName("property")]
    public string Property => "object";

    [JsonPropertyName("value")]
    public string Value { get; set; } = Page;
}

[Serializable]
public class ObjectID
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string ID { get; set; } = string.Empty;
}

[Serializable]
public class ExtenalObject
{
    [JsonPropertyName("url")]
    public string URL { get; set; } = string.Empty;
}

[Serializable]
public class Cover
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("external")]
    public ExtenalObject External { get; set; } = new();
}

[Serializable]
public class Icon
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("emoji")]
    public string Emoji { get; set; } = string.Empty;
}

[Serializable]
public class Parent
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("database_id")]
    public string DatabaseID { get; set; } = string.Empty;

    [JsonPropertyName("page_id")]
    public string PageID { get; set; } = string.Empty;

    [JsonPropertyName("workspace")]
    public bool Workspace { get; set; }
}

[Serializable]
public class Text
{
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    [JsonPropertyName("link")]
    public string Link { get; set; } = string.Empty;
}

[Serializable]
public class Annotations
{
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    [JsonPropertyName("italic")]
    public bool Italic { get; set; }

    [JsonPropertyName("strikethrough")]
    public bool Strikethrough { get; set; }

    [JsonPropertyName("underline")]
    public bool Underline { get; set; }

    [JsonPropertyName("code")]
    public bool Code { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;
}

[Serializable]
public class Title
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("text")]
    public Text Text { get; set; } = new();

    [JsonPropertyName("annotations")]
    public Annotations Annotations { get; set; } = new();

    [JsonPropertyName("plain_text")]
    public string PlainText { get; set; } = string.Empty;

    [JsonPropertyName("href")]
    public string Href { get; set; } = string.Empty;
}

[Serializable]
public class Name
{
    [JsonPropertyName("id")]
    public string ID { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public List<Title> Title { get; set; } = [];
}

[Serializable]
public class Property
{
    [JsonPropertyName("title")]
    public Name Title { get; set; } = new();
}

[Serializable]
public class SearchResult
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string ID { get; set; } = string.Empty;

    [JsonPropertyName("created_time")]
    public DateTime CreatedTime { get; set; }

    [JsonPropertyName("last_edited_time")]
    public DateTime LastEditedTime { get; set; }

    [JsonPropertyName("created_by")]
    public ObjectID CreatedBy { get; set; } = new();

    [JsonPropertyName("last_edited_by")]
    public ObjectID LastEditedBy { get; set; } = new();

    [JsonPropertyName("cover")]
    public Cover Cover { get; set; } = new();

    [JsonPropertyName("icon")]
    public Icon Icon { get; set; } = new();

    [JsonPropertyName("parent")]
    public Parent Parent { get; set; } = new();

    [JsonPropertyName("archived")]
    public bool Archived { get; set; }

    [JsonPropertyName("in_trash")]
    public bool InTrash { get; set; }

    [JsonPropertyName("properties")]
    public Property Properties { get; set; } = new();

    [JsonPropertyName("url")]
    public string URL { get; set; } = string.Empty;

    [JsonPropertyName("public _url")]
    public string PublicURL { get; set; } = string.Empty;
}
