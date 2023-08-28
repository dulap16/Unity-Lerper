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
    }
}