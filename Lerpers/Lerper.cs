using System;
using System.Collections;
using UnityEngine;

namespace Assets.SCRIPTS.Start_Page
{
    [System.Serializable]
    public class Lerper
    {
        private float _current = 0;
        private float _target = 0;
        [SerializeField] [Range(0, 10)] public float speed;
        [SerializeField] [Range(0, 20)] public float delay;

        public void Lerp()
        {
            _current = Mathf.MoveTowards(_current, _target, speed * Time.deltaTime);
            if (_target - _current > -0.001f && _target - _current < 0.001f)
                _current = _target;
        }

        public float GetCurrent()
        {
            return _current;
        }

        public void StartLerping()
        {
            _target = 1;
        }

        public void StopLerping() {
            _current = _target;
        }

        public void GoToBeginning()
        {
            _current = 0;
            _target = 0;
        }

        public void Restart()
        {
            _current = 0;
            StartLerping();
        }
        public bool wasTargetReached()
        {
            return _current == _target;
        }
    }
}