using UnityEngine;

namespace First2DGame
{
    public static class Utils
    {
        public static Vector3 Change(this Vector3 org, object x = null, object y = null, object z = null)
        {
            return new Vector3((float?)x ?? org.x, (float?)y ?? org.y, (float?)z ?? org.z);
        }

        public static Vector2 Change(this Vector2 org, object x = null, object y = null)
        {
            return new Vector2((float?)x ?? org.x, (float?)y ?? org.y);
        }
    }
}