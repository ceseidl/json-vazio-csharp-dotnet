using System.Text.Json;

public class BookJsonTests
{
    [Fact]
    public void Book_turns_into_json_with_its_title()
    {
        var book = new Book { Title = "Clean Code", Price = 89.90m };

        var json = JsonSerializer.Serialize(book, JsonSerializerOptions.Web);

        Assert.Contains("\"title\":\"Clean Code\"", json);
    }

    [Fact]
    public void Json_from_another_api_fills_the_title()
    {
        var json = """{"title":"Refactoring","price":99.50}""";

        var book = JsonSerializer.Deserialize<Book>(json, JsonSerializerOptions.Web);

        Assert.Equal("Refactoring", book!.Title);
    }
}
