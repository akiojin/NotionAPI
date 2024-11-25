using System.Text.Json.Serialization;

namespace NotionAPI;

[Serializable]
public class Person
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
}

/// <summary>
/// The User object represents a user in a Notion workspace.
/// Users include full workspace members, guests, and integrations.
/// You can find more information about members and guests in this guide.
/// <see href="https://developers.notion.com/reference/user"/>
/// </summary>
[Serializable]
public class User
{
    /// <summary>
    /// Always "user"
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; } = string.Empty;

    /// <summary>
    /// Unique identifier for this user.
    /// </summary>
    [JsonPropertyName("id")]
    public string ID { get; set; } = string.Empty;

    /// <summary>
    /// Type of the user.
    /// Possible values are "person" and "bot".
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// User's name, as displayed in Notion.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Chosen avatar image.
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string AvatarURL { get; set; } = string.Empty;

    /// <summary>
    /// <see href="https://developers.notion.com/reference/user#people"/>
    /// </summary>
    [JsonPropertyName("person")]
    public Person Person { get; set; } = new ();
}

[Serializable]
public class SearchSort
{
    public const string Ascending = "ascending";
    public const string Descending = "descending";

    [JsonPropertyName("direction")]
    public string Direction { get; set; } = Ascending;

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
    public ExtenalObject External { get; set; } = new ();
}

[Serializable]
public class Icon
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("emoji")]
    public string Emoji { get; set; } = string.Empty;
}

/// <summary>
/// Pages, databases, and blocks are either located inside other pages,
/// databases, and blocks, or are located at the top level of a workspace.
/// This location is known as the "parent".
/// Parent information is represented by a consistent parent object throughout the API.
/// <see href="https://developers.notion.com/reference/parent-object"/>
/// </summary>
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

    [JsonPropertyName("block_id")]
    public string BlockID { get; set; } = string.Empty;
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
    public Text Text { get; set; } = new ();

    [JsonPropertyName("annotations")]
    public Annotations Annotations { get; set; } = new ();

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
    public Name Title { get; set; } = new ();
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
    public ObjectID CreatedBy { get; set; } = new ();

    [JsonPropertyName("last_edited_by")]
    public ObjectID LastEditedBy { get; set; } = new ();

    [JsonPropertyName("cover")]
    public Cover Cover { get; set; } = new ();

    [JsonPropertyName("icon")]
    public Icon Icon { get; set; } = new ();

    [JsonPropertyName("parent")]
    public Parent Parent { get; set; } = new ();

    [JsonPropertyName("archived")]
    public bool Archived { get; set; }

    [JsonPropertyName("in_trash")]
    public bool InTrash { get; set; }

    [JsonPropertyName("properties")]
    public Property Properties { get; set; } = new ();

    [JsonPropertyName("url")]
    public string URL { get; set; } = string.Empty;

    [JsonPropertyName("public _url")]
    public string PublicURL { get; set; } = string.Empty;
}
