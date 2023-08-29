using Assets.SCRIPTS.Start_Page.Lerpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SCRIPTS.Start_Page
{
    public class ObjectToBeLerped : MonoBehaviour
    {
        private GameObject go;

        [SerializeField] private bool inheritInitialProperties = false; 
        [SerializeField] private StageManager stages;

        private Dictionary<Lerper, IEnumerator> coroutines;
        private Stage currentStage;

        public ObjectToBeLerped(GameObject _go)
        {
            go = _go;

            Debug.Log(go);
        }


        IEnumerator ApplyDelayToLerper(LerpedProperty lp)
        {
            yield return new WaitForSeconds(lp.lerper.delay);

            lp.lerper.Restart();
        }

        // Use this for initialization
        void Start()
        {
            if (go == null)
                go = gameObject;
            if(inheritInitPos && position)
                initPos = go.transform.localPosition;
            if (inheritInitColor && color)
                initColor = go.GetComponent<SpriteRenderer>().color;
            if (inheritInitRot && rotation)
                initRot = go.transform.localRotation;


            lerpedProperties = new List<LerpedProperty>();
            lerpedProperties.Add(new LerpedProperty(position, positionLerper));
            lerpedProperties.Add(new LerpedProperty(color, colorLerper));
            lerpedProperties.Add(new LerpedProperty(rotation, rotationLerper));
            lerpedProperties.Add(new LerpedProperry(scale, scaleLerper));
        }

        // Update is called once per frame
        void Update()
        {
            UpdateLerpingProperties();
            ModifyAccordingToLerp();
        }

        public void StartLerpingOneProperty(LerpedProperty lp)
        {
            lp.coroutine = ApplyDelayToLerper(lp);
            StartCoroutine(lp.coroutine);
        }

        public void StartLerpingAll()
        {
            foreach(LerpedProperty lp in lerpedProperties)
            {
                StartLerpingOneProperty(lp);
            }
        }

        public void ModifyAccordingToLerp()
        {
            if(position)
                go.transform.localPosition = Vector3.Lerp(initPos, finalPos, _posCurve.Evaluate(positionLerper.GetCurrent()));

            if (color)
                go.GetComponent<SpriteRenderer>().color = Color.Lerp(initColor, finalColor, _colorCurve.Evaluate(colorLerper.GetCurrent()));

            if (rotation)
                go.transform.localRotation = Quaternion.Lerp(initRot, finalRot, _rotCurve.Evaluate(rotationLerper.GetCurrent()));
        }

        public void StopOneProperty(LerpedProperty lp)
        {
            lp.lerper.StopLerping();
        }

        public void StopAll()
        {
            foreach (LerpedProperty lp in lerpedProperties)
            {
                StopOneProperty(lp);
            }
        }

        public void RestartOneProperty(LerpedProperty lp)
        {
            StopCoroutine(lp.coroutine);
            lp.lerper.GoToBeginning();
            StartLerpingOneProperty(lp);
        }

        public void RestartAll()
        {
            foreach (LerpedProperty lp in lerpedProperties)
            {
                RestartOneProperty(lp);
            }
        }

        public void UpdateLerpingProperties()
        {
            foreach(LerpedProperty lp in lerpedProperties)
            {
                lp.lerper.Lerp();
            }
        }
    }
}