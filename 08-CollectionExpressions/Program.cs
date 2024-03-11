
    #region net6syntax
    //int[] agesArray = { 8, 74, 25, 16, 67 };
    //List<int> agesList = new() { 8, 74, 25, 16, 67 };

    //PrintAges(agesArray);
    //PrintAges(agesList);
    //PrintAges(new List<int>());
    #endregion


    // Use the spread operator to concatenate
    int[] array1 = [1, 2, 3, 4, 5];
    int[] array2 = [6, 7, 8, 9, 10];
    int[] array3 = [11, 12, 13, 14, 15];
    int[] fullArray = [..array1, ..array2, ..array3, 99, 100]; // contents is [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 99, 100]


    // new initialization no need to use '{}'
    List<int> agesListNew = [8, 74, 25, 16, 67];
    List<string> agesListNew2 = ["test", "25", "16", "67"];

var asd = new List<int>();

PrintAges(fullArray);
    PrintAges(agesListNew);
PrintAges(asd); // passing empty array


static void PrintAges(IEnumerable<int> ages)
{
    Console.WriteLine($"You passed in {ages.Count()} ages");
}