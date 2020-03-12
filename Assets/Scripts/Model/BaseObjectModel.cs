using UnityEngine;

namespace GDCTest
{
    public abstract class BaseObjectModel : MonoBehaviour
    {
        private int _layer;
        private bool _isVisible;
        private Color _color;

        public CircleCollider2D Collider { get; set; }
        public Transform Transform { get; private set; }

        public string Name
        {
            get => gameObject.name;
            set => gameObject.name = value;
        }

        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                AskColor(transform, value);
            }
        }

        private void AskColor(Transform obj, Color value)
        {
            if (obj.gameObject.TryGetComponent<Renderer>(out var component))
            {
                foreach (var material in component.materials)
                {
                    material.color = value;
                }
            }
            if (obj.childCount <= 0)
            {
                return;
            }
            foreach (Transform transform in obj)
            {
                AskColor(transform, value);
            }
        }

        protected virtual void Awake()
        {
            Collider = GetComponent<CircleCollider2D>();
            Transform = transform;
        }
    }
}

