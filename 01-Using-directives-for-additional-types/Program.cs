
//C# 12 Using directives for additional types

// AKA ALIAS ANY TYPE

using Point3D = (int X, int Y, int Z);
using intArray = int[]; // Array types.
using Point = (int x, int y);  // Tuple type

using Numbers = int[];

using Strings = System.Collections.Generic.List<string>;

using IsDefined = bool?;

using Person = (string FirstName, string L);

using MyBankAccount = (string name, string lastname, int myBalance);




#region bankAcc

var bankAcc = new MyBankAccount()
{
    name = "Marcin",
    lastname = "Junka",
    myBalance = 200,
};
var bankAcc2 = new MyBankAccount()
{
    name = "Marcin",
    lastname = "Junka",
    myBalance = 200,
};
MyBankAccount Withdraw(ref MyBankAccount bankDetails)
{
    bankDetails.myBalance -= 100;
    return bankDetails;
}

MyBankAccount Withdraw2(MyBankAccount bankDetails)
{
    bankDetails.myBalance -= 100;
    return bankDetails;
}

Withdraw(ref bankAcc);
Withdraw2(bankAcc2);
Console.WriteLine(bankAcc);
Console.WriteLine(bankAcc2);




#endregion



// 1. error/exception
// 2. Nothing will show
// 3. no error / myBalance will be: 100
// 4. no error / mybalance will be: 200














// what will we get

//https://strawpoll.com/kjn185OVjyQ

































//Console.WriteLine(Withdraw(bankAcc));











//void Calculate(Point3D[] points)
//{ }

//void Write(Dictionary<Numbers, Strings> d)
//{ }

//void Check(IsDefined d, Person p)
//{ }


//public class Product
//    (int id, string name, IEnumerable<decimal> prices)
//{
//    public Product(int id, string name)
//        : this(id, name, Enumerable.Empty<decimal>()) { }

//    public int Id => id;

//    public string Name { get; set; }
//        = name.Trim();

//    public decimal AveragePrice
//        => prices.Any() ? prices.Average() : 4.0m;
//}