using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAtackBase : MonoBehaviour
{
    [Header("Settings Attack")]

    [Space(10)]
    public int attackSelected = 0;

    [Space(10)]
    public GameObject[] shootersShip;

}
