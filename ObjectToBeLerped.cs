using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SCRIPTS.Start_Page
{
    public class ObjectToBeLerped : MonoBehaviour
    {
        private GameObject go;
        // WHAT IS THE OBJECT LERPING
        [Header("Lerped Properties")]
        [SerializeField] private bool position = false;
        [SerializeField] private bool color = false;
        [SerializeField] private bool rotation = false;


        [Header("Position lerping")]
        [SerializeField] public bool inheritInitPos = true;
        [SerializeField] public Vector3 initPos;
        [SerializeField] public Vector3 finalPos;
        [SerializeField] private Lerper positionLerper; 
        [SerializeField] private AnimationCurve _posCurve;

        [Header("Color lerping")]
        [SerializeField] private bool inheritInitColor = true;
        [SerializeField] private Color initColor;
        [SerializeField] private Color finalColor;
        [SerializeField] private Lerper colorLerper;
        [SerializeField] private AnimationCurve _colorCurve;


        [Header("Rotation lerping")]
        [SerializeField] private bool inheritInitRot = true;
        [SerializeField] private Quaternion initRot;
        [SerializeField] private Quaternion finalRot;
        [SerializeField] private Lerper rotationLerper;
        [SerializeField] private AnimationCurve _rotCurve;

        public class LerpedProperty
        {
            public bool isLerped = false;
            public Lerper lerper;
            public IEnumerator coroutine;

            public LerpedProperty(bool b, Lerper l)
            {
                isLerped = b;
                lerper = l;
            }
        }

        private List<LerpedProperty> lerpedProperties;

    }
}