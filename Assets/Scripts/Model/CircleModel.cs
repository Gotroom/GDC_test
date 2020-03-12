using UnityEngine;
using System;

namespace GDCTest
{
    public sealed class CircleModel : BaseObjectModel, IDestroyable, ISelectable, IInitializable
    {
        public event Action<CircleModel> Destroyed;
        public event Action<int> IncreaseScore;

        private const float X_AXIS_OFFSET = 0.1f;

        [Range(0.1f, 1.0f)]
        [SerializeField] private float _minSizeMultiplierRange = 0.1f;
        [Range(1.0f, 3.0f)]
        [SerializeField] private float _maxSizeMultiplierRange = 3.0f;
        [Range(1.0f, 3.0f)]
        [SerializeField] private float _minSpeed = 1.0f;
        [Range(3.0f, 6.0f)]
        [SerializeField] private float _maxSpeed = 3.0f;
        [SerializeField] private int _defaultPoints = 100;

        private Bounds _cameraBounds;
        private float _speed;
        private int _points;
        private bool _isInitialized;

        protected override void Awake()
        {
            base.Awake();
            _cameraBounds = CameraExtention.CameraBoundsToScreen(Camera.main);
            Initialize();
        }

        public void Initialize()
        {
            _isInitialized = false;

            Color = UnityEngine.Random.ColorHSV();
            Collider = GetComponent<CircleCollider2D>();
            var sizeMultiplier = UnityEngine.Random.Range(_minSizeMultiplierRange, _maxSizeMultiplierRange);
            transform.localScale = Vector3.one * sizeMultiplier;

            _speed = Mathf.Lerp(_maxSpeed, _minSpeed , sizeMultiplier / _maxSizeMultiplierRange);
            
            _points = (int)Mathf.Lerp(_defaultPoints, _defaultPoints / _defaultPoints, sizeMultiplier / _maxSizeMultiplierRange);

            _isInitialized = true;
        }

        public void Reinitialize(Vector3 position)
        {
            _isInitialized = false;
            transform.position = position;
            Initialize();
        }

        public void Tick()
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
            if (_isInitialized)
            {
               CheckBounds();
            }
        }

        private void CheckBounds()
        {
            var pos = transform.position;

            if (_cameraBounds.min.x > Collider.bounds.min.x)
            {
                pos.x += (_cameraBounds.min.x - Collider.bounds.min.x) + X_AXIS_OFFSET;
                transform.position = pos;
            }
            else if (_cameraBounds.max.x < Collider.bounds.max.x)
            {
                pos.x += (_cameraBounds.max.x - Collider.bounds.max.x) - X_AXIS_OFFSET;
                transform.position = pos;
            }
        }

        public void Destroy()
        {
            IncreaseScore?.Invoke(_points);
            Destroyed?.Invoke(this);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public string GetMessage()
        {
            return Name + " " + _points;
        }

        
    }
}