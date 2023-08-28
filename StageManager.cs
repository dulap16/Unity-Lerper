using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.SCRIPTS.Start_Page
{
    [Serializable]
    public class StageManager
    {
        [SerializeField] private List<Stage> stages;
        [SerializeField] private int index;

        public void addStage(Stage stage)
        {
            if(stages == null)
                stages = new List<Stage>();

            stages.Add(stage);
        }

        public bool goToNextStage()
        {
            index++;
            if (index >= stages.Count)
                return false;
            return true;
        }

        public Stage getCurrentStage()
        {
            return getStageOfIndex(index);
        }

        public Stage getStageOfIndex(int i)
        {
            return stages[i];
        }
    }
}