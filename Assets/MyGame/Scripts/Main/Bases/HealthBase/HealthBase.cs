using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class HealthBase : MonoBehaviour
{
    public int currenthealth = 0;
    public int minHealth = 0;
    public int maxHealth = 10;
    public bool isDead = false;

    public virtual void SubtractDamage(int amountDamage)
    {

    }
    public virtual void AddHealth(int amountHealth)
    {

    }
}
