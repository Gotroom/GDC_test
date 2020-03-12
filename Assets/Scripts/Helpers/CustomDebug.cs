using UnityEngine;

namespace GDCTest
{
    public class CustomDebug : MonoBehaviour
    {
        public static void Log(object message)
        {
            Debug.Log(message);
        }
    }
}

