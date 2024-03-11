using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

var s = new Example() { Address = "test required",Base64Text = "test required"};

public class Example
{

    [Base64String] 
    public required string Base64Text { get; set; } // ('test required' == 'dGVzdCByZXF1aXJlZA==') https://www.base64encode.org/

    [AllowedValues(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
    public int Score { get; set; }

    [DeniedValues(-1, 0)]
    public int Age { get; set; }

    [Length(3, 30)]
    public required string Address { get; set; }    // The 'required' modifier is available beginning with C# 11. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/required

    //[Required(DisallowAllDefaultValues = true)]
    public Guid Id { get; set; }
}