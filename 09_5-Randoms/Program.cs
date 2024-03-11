









// old way
List<string> fruits = new List<string> { "Apple", "Banana", "Cherry", "Date" };

Random rand = new Random();

string randomFruit = fruits[rand.Next(fruits.Count)];

Console.WriteLine("Random Fruit old way: " + randomFruit);

// new way
List<string> fruitsArray = ["Apple", "Banana", "Cherry", "Date" ];

string[] selectedFruits = Random.Shared.GetItems(fruitsArray.ToArray(), 2);

Console.WriteLine("Random Fruits new way: " + string.Join(", ", selectedFruits));


// old way shuffle
List<int> numbers = Enumerable.Range(1, 5).ToList();

for (int i = numbers.Count - 1; i > 0; i--)
{
    int j = rand.Next(i + 1);

    int temp = numbers[i];

    numbers[i] = numbers[j];

    numbers[j] = temp;
}


foreach (int number in numbers)
{
    Console.WriteLine("Numbers old way:" + number);
}



// New way Random shuffle
int[] numbersNewWay = { 1, 2, 3, 4, 5 };

Random.Shared.Shuffle(numbersNewWay);

foreach (int number in numbersNewWay)
{
    Console.WriteLine(number);
}