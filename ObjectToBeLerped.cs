﻿using Assets.SCRIPTS.Start_Page.Lerpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SCRIPTS.Start_Page
{
    public class ObjectToBeLerped : MonoBehaviour
    {
        private GameObject go;

        [SerializeField] private StageManager stages;

        private Dictionary<Lerper, IEnumerator> coroutines;
        private Stage currentStage;

        public ObjectToBeLerped(GameObject _go)
        {
            go = _go;
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

            currentStage = stages.getCurrentStage();
            setInitialValues();

            coroutines = new Dictionary<Lerper, IEnumerator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (stages.getNumberOfStages() > 0)
            {
                UpdateLerpingProperties();
                ModifyAccordingToLerp();

                if (stages.advanceIfCase())
                {
                    ResetCurrentVariables();

                    MakeNextStageStartFromLast();

                    ResetCurrentVariables();
                    StartLerping();
                }
            }
        }

        public void StartLerping()
        {
            foreach (Lerper l in currentStage.lerperDict.Values)
            {
                l.GoToBeginning();
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

        public void Restart()
        {
            if (stages.getNumberOfStages() != 0)
            {
                foreach (Lerper l in currentStage.lerperDict.Values)
                {
                    StopCoroutine(coroutines[l]);
                }

                stages.Restart();
                ResetCurrentVariables();
                StartLerping();
            }
        }

        public void setInitialValues()
        {
            if (currentStage.willLerpProperty("position"))
                currentStage.changeOneInitialValue("position", go.transform.localPosition);

            if (currentStage.willLerpProperty("scale"))
                currentStage.changeOneInitialValue("scale", go.transform.localScale);

            if (currentStage.willLerpProperty("color"))
                currentStage.changeOneInitialValue("color", go.GetComponent<SpriteRenderer>());

            if (currentStage.willLerpProperty("rotation"))
                currentStage.changeOneInitialValue("rotation", go.transform.rotation);
        }

        public void UpdateLerpingProperties()
        {
            currentStage.LerpAll();
        }

        public void MakeStageInheritFromLast(Stage last, Stage next)
        {
            next.setLastIfCase(last.getLerper("position").finalVector3(), last.getLerper("scale").finalVector3(), last.getLerper("color").finalColor(), last.getLerper("rotation").finalQuaternion());
        }

        public void MakeNextStageStartFromLast()
        {
            MakeStageInheritFromLast(stages.getStageOfIndex(stages.getCurrentIndex() - 1), stages.getStageOfIndex(stages.getCurrentIndex()));
        }

        public void ModifyStage(int index, Stage s)
        {
            stages.setStage(index, s);
        }

        public StageManager getStageManager()
        {
            return stages;
        }
    }
}