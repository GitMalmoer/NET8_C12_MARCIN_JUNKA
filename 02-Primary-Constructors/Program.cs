

//Product p1 = new Product(1, "Game");

//Product p2 = new Product(1, "T-Shirt",
//    new List<decimal>() { 50, 49, 52, 54 });

//public class Product(int id, string name,
//    IEnumerable<decimal> prices)
//{
//    public Product(int id, string name) :
//        this(id, name, Enumerable.Empty<decimal>())
//    { }

//    public int Id => id;
//    public string Name { get; set; } = name.Trim();
//    public decimal AveragePrice => prices.Any() ?
//        prices.Average() : 0.0m;
//}
















//What will we get



// https://strawpoll.com/GeZAOd5V1nV









// 1. SampleClassWithPrimaryNChain
// 2. No errrors and the output will be: Default Account, Default Owner, country
// 3. No errrors and the output will be: accId1, owner1, country1
// 4. Error/Exception





using System.Diagnostics.Metrics;

SampleClassWithPrimaryNChain sampleClassNChain = new("accId1", "owner1", "country1");

Console.WriteLine(sampleClassNChain);

#region hide
public class SampleClass
{
    private readonly string _a;
    private readonly string _b;
    private readonly int _c;

    public SampleClass(string a, string b, int c)
    {
        _a = a;
        _b = b;
        _c = c;
    }
}


public class SampleClassWithPrimary(string accountId, string owner)
{

    public string AccountId { get; } = accountId;
    public string Owner { get; } = owner;

    public override string ToString() => $"Account ID: {AccountId}, Owner: {Owner}";
}

#endregion

public record SampleClassWithPrimaryNChain(string AccountId, string Owner)
{
    public string Country { get; } = string.Empty;

    public SampleClassWithPrimaryNChain(string accountId, string owner, string country) : this("Default Account", "Default Owner") // Chaining to base constructor
    {
        AccountId = accountId;
        Owner = owner;
        Country = country;
    }
    
}

















// explenation
// The record has two automatically generated properties: AccountId and Owner.
// is is an additional property named Country with only a getter (read-only property).






//public override string ToString() => $"Account ID: {AccountId}, Owner: {Owner}";