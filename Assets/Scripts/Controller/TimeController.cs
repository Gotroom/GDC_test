using UnityEngine;
using System;


namespace GDCTest
{
    public class TimeController : BaseController, IExecutable, IInitializable
    {
        public static Action TimerExpired;

        private float _gameTime;

        public void Execute()
        {
            _gameTime -= Time.deltaTime;
            if (_gameTime <= 0.0f)
            {
                _gameTime = 0.0f;
                TimerExpired?.Invoke();
            }
            UiInterface.TimerText.Text = _gameTime;
            
        }

        public void Initialize()
        {
            _gameTime = 60.0f;
        }
    }
}