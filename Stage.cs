using Assets.SCRIPTS.Start_Page.Lerpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SCRIPTS.Start_Page
{
    [Serializable]
    public class Stage
    {
        [SerializeField] public bool _inheritLast;
        [SerializeField] private Vector3Lerper positionLerper;
        [SerializeField] private Vector3Lerper scaleLerper;
        [SerializeField] private ColorLerper colorLerper;
        [SerializeField] private QuaternionLerper rotationLerper;

        [SerializeField] private List<Lerper> lerpers;
        public Dictionary<String, Lerper> lerperDict;

        public Stage()
        {
            _curves = new List<AnimationCurve>();
            for (int i = 0; i < 4; i++)
                _curves.Add(new AnimationCurve());
        }

        public void setInitPos(Vector3 pos)
        {
            initPos = pos;
        }

        public void setInherit(bool b)
        {
            _inheritLast = b;
        }
    }
}