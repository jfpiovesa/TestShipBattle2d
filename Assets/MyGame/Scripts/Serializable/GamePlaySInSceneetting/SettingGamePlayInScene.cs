using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class SettingGamePlayInScene
{
    [Tooltip("60 seconds is equal to 1 minute"), Space(5)]
    [Range(60f, 180f)] public float gameSessionTime = 1;

    [Tooltip("interval to spawn enemies"), Space(5)]
    [Range(0.1f, 10f)] public float enemyAppearanceTime = 0.1f;
}
