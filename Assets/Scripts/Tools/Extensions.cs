using UnityEngine;

namespace Tools
{
    public static class Extensions
    {
        public static Vector3 AddZ(this Vector3 vector, float z)
        {
            vector.z = z;
            return vector;
        }
    }
}