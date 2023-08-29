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
        [SerializeField] private int current = 0;

        public void addStage(Stage stage)
        {
            if(stages == null)
                stages = new List<Stage>();

            stages.Add(stage);
        }

        public bool goToNextStage()
        {
            if (current + 1>= stages.Count)
                return false;
            
            current++;

            getCurrentStage().GoToBeginning();
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