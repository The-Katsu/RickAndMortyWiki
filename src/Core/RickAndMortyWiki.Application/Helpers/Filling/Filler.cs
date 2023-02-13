namespace RickAndMortyWiki.Application.Helpers.Filling;

public static class Filler<T> where T : class
{
    public static void FillEmptyString(T t)
    {
        var props = typeof(T).GetProperties();
        foreach (var p in props)
        {
            var val = p.GetValue(t)?.ToString();
            if (string.IsNullOrEmpty(val)) p.SetValue(t, "unknown");
        }
    }
}