using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class DamageObject
{
    [Header("name of the animation to be triggered"),Space(5)]
    public string _nameAnimationAtack;
    [Header("whether you can use this attack or not")]
    public bool _activeAtcak = false;
    [Header("Attack damage value"), Space(5)]
    public int _damage;
    [Header("projectile to be fired"), Space(5)]
    public GameObject _prefabProjectile;
    [Header("effect to be triggered"), Space(5)]
    public GameObject _prefabEfectColision;
}
