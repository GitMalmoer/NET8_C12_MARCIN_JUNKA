

public static class ParsableExtension
{
    public static T Parse<T>(this string input,IFormatProvider? formatProvider = null) where T : IParsable<T>
    {
        return T.Parse(input, formatProvider);
    }

}

