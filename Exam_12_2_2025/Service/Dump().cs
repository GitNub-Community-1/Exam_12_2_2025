public static class Dump__
{
    public static void Dump<T>(this IEnumerable<T> source, string title = "Dump: ")
    {
        Console.WriteLine($"======== {title} ========");
        int cnt = 1;
        foreach (var item in source)
        {
            if (item == null)
            {
                Console.WriteLine($"[{cnt++}] null");
                continue;
            }

            var type = item.GetType();
            if (type.Name.Contains("AnonymousType"))
            {
                var props = type.GetProperties();
                var values = props.Select(p => $"{p.Name} = {p.GetValue(item)}");
                Console.WriteLine($"[{cnt++}] {{ {string.Join(" | ", values)} }}");
            }
            else
            {
                Console.WriteLine($"[{cnt++}] {item}");
            }
        }
        Console.WriteLine();
    }
}