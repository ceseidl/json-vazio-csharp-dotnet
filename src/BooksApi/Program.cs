var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Book> books =
[
    new Book { Title = "Clean Code", Price = 89.90m },
    new Book { Title = "The Pragmatic Programmer", Price = 120.00m },
];

app.MapGet("/books", () => books);

app.MapPost("/books", (Book book) =>
{
    books.Add(book);
    return Results.Created($"/books/{books.Count}", book);
});

app.Run();
