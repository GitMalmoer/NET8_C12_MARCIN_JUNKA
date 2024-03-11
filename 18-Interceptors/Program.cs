    using System.Runtime.CompilerServices;

Example ex = new Example();
ex.MyMethod("Check");
ex.MyMethod("Check");
ex.MyMethod("Check");
ex.MyMethod("Check");
ex.MyMethod("Check");

// HAD TO ADD 		<InterceptorsPreviewNamespaces>$(InterceptorsPreviewNamespaces);testnamespace</InterceptorsPreviewNamespaces> INTO PROPERTY GROUP
namespace testnamespace
{
    public static class Code
{
        [InterceptsLocation("C:\\Users\\juami\\Downloads\\WhatIsNewInCsharp12AndNET8-master\\18-Interceptors\\Program.cs", line: 4, column: 4)]
        [InterceptsLocation("C:\\Users\\juami\\Downloads\\WhatIsNewInCsharp12AndNET8-master\\18-Interceptors\\Program.cs", line: 5, column: 4)]
    public static void MyInterceptorMethod(this Example ex, string param)
    {
        Console.WriteLine($"MyInterceptorMethod {param}");
    }
}

}

public class Example
{
    public void MyMethod(string param)
    {
        Console.WriteLine($"MyMethod {param}");
    }
}


namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    sealed class InterceptsLocationAttribute(string filePath, int line, int column) : Attribute
    {
    }
}

//https://andrewlock.net/exploring-the-dotnet-8-preview-changing-method-calls-with-interceptors/

// intercept definition:
// to take, seize, or halt (someone or something on the way from one place to another); 
// cut off from an intended destination


// As the name implies, Interceptors allow developers to target specific method invocations and intercept them with a new implementation.