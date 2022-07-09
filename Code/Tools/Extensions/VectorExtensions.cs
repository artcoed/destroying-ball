using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 Random(this Vector3 a, Vector3 b)
    {
        var result = Vector3.zero;
        result.x = UnityEngine.Random.Range(a.x, b.x);
        result.y = UnityEngine.Random.Range(a.y, b.y);
        result.z = UnityEngine.Random.Range(a.z, b.z);
        return result;
    }
}
