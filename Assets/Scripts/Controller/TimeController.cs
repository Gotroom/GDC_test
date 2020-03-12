using UnityEngine;
using System;


namespace GDCTest
{
    public class TimeController : BaseController, IExecutable, IInitializable
    {
        public static Action TimerExpired;

        public float TimerRelation
        {
            get => (_gameTime != 0 ? _gameTime : Constants.START_TIME) / Constants.START_TIME;
        }

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
            _gameTime = Constants.START_TIME;
        }
    }
}