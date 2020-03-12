using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

namespace GDCTest
{
    public class CirclesController : BaseController, IInitializable, IExecutable
    {
        public static Action<int> IncreaseScore;

        private const float Y_AXIS_OFFSET = 3.0f;

        private readonly HashSet<CircleModel> _circlesHash = new HashSet<CircleModel>();
        private Bounds _cameraBounds;

        private readonly int _initianCircleCount = 5;
        private readonly int _maxCircleCount = 500;

        public void Initialize()
        {
            _circlesHash.Clear();
            _cameraBounds = CameraExtention.CameraBoundsToScreen(Camera.main);
            for (int i = 0; i < _initianCircleCount; i++)
            {
                CreateCircle();
            }
        }

        public void Execute()
        {
            if (!IsActive)
            {
                return;
            }

            for (var i = 0; i < _circlesHash.Count; i++)
            {
                var circle = _circlesHash.ElementAt(i);
                circle.Tick();
                if (circle.GetPosition().y > _cameraBounds.max.y + Y_AXIS_OFFSET)
                    MoveCircleToStart(circle);
            }
        }

        public Vector3 GetStartPoint()
        {
            var yPosition = _cameraBounds.min.y - Y_AXIS_OFFSET;
            var xPosition = UnityEngine.Random.Range(_cameraBounds.min.x, _cameraBounds.max.x);
            return new Vector3(xPosition, yPosition);
        }

        private void CreateCircle()
        {
            var circle = UnityEngine.Object.Instantiate(ServiceLocatorMonoBehaviour.GetService<Reference>().Circle,
                    GetStartPoint(), Quaternion.identity);

            //CheckBounds(circle);
            AddCircle(circle);
        }

        private void AddCircle(CircleModel circle)
        {
            if (!_circlesHash.Contains(circle))
            {
                circle.Destroyed += AddAndMoveCircleToStart;
                circle.IncreaseScore += OnIncreaseScore;
                _circlesHash.Add(circle);
            }
        }

        private void AddAndMoveCircleToStart(CircleModel circle)
        {
            if (_circlesHash.Count < _maxCircleCount)
            {
                CreateCircle();
            }
            MoveCircleToStart(circle);
        }

        private void MoveCircleToStart(CircleModel circle)
        {
            circle.Reinitialize(GetStartPoint());
            //CheckBounds(circle);
        }

        

        private void OnIncreaseScore(int points)
        {
            IncreaseScore?.Invoke(points);
        }
    }
}
