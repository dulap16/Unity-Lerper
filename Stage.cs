using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SCRIPTS.Start_Page
{
    [Serializable]
    public class Stage
    {
        [SerializeField] [Range(0, 10)] private float _delay, _speed;
        [SerializeField] private bool _inheritLast;
        [SerializeField] private Vector3 initPos, finalPos;
        [SerializeField] private Vector3 initScale, finalScale;
        [SerializeField] private Color initColor, finalColor;
        [SerializeField] private Quaternion initRot, finalRot;
        [SerializeField] private List<AnimationCurve> _curves; // 1 - pos, 2 -scale, 3 - color, 4 - rotation
    }
}