﻿using Assets.SCRIPTS.Start_Page.Lerpers;
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

        IEnumerator ApplyDelayToCurrentStage(Lerper l, float delay)
        {
            yield return new WaitForSeconds(delay);

            l.StartLerping();
        }

        // Use this for initialization
        void Start()
        {
            if (go == null)
                go = gameObject;

            if(inheritInitialProperties)
                stages.setInitValues(go.transform.localPosition, go.transform.localScale, go.GetComponent<SpriteRenderer>().color, go.transform.rotation);

            currentStage = stages.getCurrentStage();

            coroutines = new Dictionary<Lerper, IEnumerator>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateLerpingProperties();
            ModifyAccordingToLerp();

            if (stages.advanceIfCase())
            {
                ResetCurrentVariables();

                if(currentStage._inheritLast)
                    MakeNextStageStartFromLastPosition();

                ResetCurrentVariables();
                StartLerping();
            }
        }

        public void StartLerping()
        {
            foreach (Lerper l in currentStage.lerperDict.Values)
            {
                coroutines[l] = ApplyDelayToCurrentStage(l, l.delay);
                StartCoroutine(coroutines[l]);
            }
        }

        public void ModifyAccordingToLerp()
        {
            if (currentStage.willLerpProperty("position"))
                go.transform.localPosition = ((Vector3Lerper)currentStage.getLerper("position")).getCurrentValue();

            if (currentStage.willLerpProperty("scale"))
                go.transform.localScale = ((Vector3Lerper)currentStage.getLerper("scale")).getCurrentValue();

            if (currentStage.willLerpProperty("color"))
                go.GetComponent<SpriteRenderer>().color = ((ColorLerper)currentStage.getLerper("color")).getCurrentValue();

            if (currentStage.willLerpProperty("rotation"))
                go.transform.rotation = ((QuaternionLerper)currentStage.getLerper("rotation")).getCurrentValue();
        }

        public void StopAll()
        {
            currentStage.StopAll();
        }

        public void ResetCurrentVariables()
        {
            currentStage = stages.getCurrentStage();
        }

        public void RestartAll()
        {
            foreach (Lerper l in currentStage.lerperDict.Values)
            {
                StopCoroutine(coroutines[l]);
            }

            stages.setCurrent(0);
            ResetCurrentVariables();
            StartLerping();
        }

        public void UpdateLerpingProperties()
        {
            currentStage.LerpAll();
        }
        }
    }
}