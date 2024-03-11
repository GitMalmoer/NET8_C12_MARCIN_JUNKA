using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Hello, World!");



var numberAsText = "123";

// old way
var oldWayInt = int.Parse(numberAsText);
var oldWayDouble = double.Parse(numberAsText);


// new way with static ParsableExtensions.cs
var numberAsInt = numberAsText.Parse<int>();
var numberAsDouble = numberAsText.Parse<double>();
var numberAsDecimal = numberAsText.Parse<decimal>();

// we can create now custom Point3D class which will implement IParseable which allows us to create custom parse logics.



var point3DAsText = "300,11-100,33-200,66";
var point3dAsDecimals = Point3D<double>.Parse(point3DAsText);

Console.WriteLine(point3dAsDecimals);
//Console.WriteLine(point3dAsDecimals);
//Console.WriteLine(point3dAsDecimals);






























var coordinatesAsText1 = "563-211";
var coordinatesAsText2 = "563,76-211,22";

var coordinates = Coordinates.Parse(coordinatesAsText1);
var coordinatesAsDoubles = Coordinates<double>.Parse(coordinatesAsText2);

var coordinatesAsSpan1 = "563-211".AsSpan();
var coordinatesAsSpan2 = "563,76-211,22".AsSpan();

var coordinates2 = Coordinates.Parse(coordinatesAsSpan1);
var coordinatesAsDoubles2 = Coordinates<double>.Parse(coordinatesAsSpan2);

//Console.WriteLine(coordinates.Longitude);
//Console.WriteLine(coordinates.Latitude);
//Console.WriteLine(coordinates2.Latitude);
//Console.WriteLine(coordinates2.Longitude);
//Console.WriteLine(coordinatesAsDoubles.Latitude);
//Console.WriteLine(coordinatesAsDoubles.Longitude);
//Console.WriteLine(coordinatesAsDoubles2.Latitude);
//Console.WriteLine(coordinatesAsDoubles2.Longitude);



