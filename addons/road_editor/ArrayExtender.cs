
using Godot;
using System;
using System.Linq;
using System.Collections.Generic;
public static class ArrayExtender
{
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> list, int chunkSize)
    {
        if (chunkSize <= 0)
        {
            throw new ArgumentException("chunkSize must be greater than 0.");
        }

        while (list.Any())
        {
            yield return list.Take(chunkSize);
            list = list.Skip(chunkSize);
        }
    }

    public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
    {
        for (var i = 0; i < (float)array.Length / size; i++)
        {
            yield return array.Skip(i * size).Take(size);
        }
    }

}