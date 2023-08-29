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
            lerpers = new List<Lerper>();

            positionLerper = new Vector3Lerper();
            scaleLerper = new Vector3Lerper();
            colorLerper = new ColorLerper();
            rotationLerper = new QuaternionLerper();
            lerpers.Add(positionLerper);
            lerpers.Add(scaleLerper);
            lerpers.Add(colorLerper);
            lerpers.Add(rotationLerper);

            lerperDict = new Dictionary<String, Lerper>();
            lerperDict.Add("position", positionLerper);
            lerperDict.Add("scale", scaleLerper);
            lerperDict.Add("color", colorLerper);
            lerperDict.Add("rotation", rotationLerper);
        }
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