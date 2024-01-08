using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CollectionExtension
{
    public static T GetRandom<T>(this ICollection<T> collection) {
        return collection.ToArray()[Random.Range(0, collection.Count)];
    }
}
