using UnityEngine;
using System.Collections;

namespace GDCTest
{
    public sealed class CircleModel : BaseObjectModel, IDestroyable, ISelectable
    {
        public float TimeToDestroy = 0.1f;

        public void Destroy()
        {
            Destroy(gameObject, 0.1f);
        }

        public string GetMessage()
        {
            return Name;
        }
    }
}