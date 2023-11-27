using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IDamageObject<DamageObject>
{

    public bool canMoveShip { get; set; } = true;
    public virtual void Hit(DamageObject DO)
    {

    }
}
