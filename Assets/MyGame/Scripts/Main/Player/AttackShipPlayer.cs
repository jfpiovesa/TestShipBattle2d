using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShipPlayer : CharacterAtackBase
{

    private void Start()
    {
        DesactiveAllCannonSelected();
    }
    public void ChangerCannon()
    {
        attackSelected++;
        ActiveCannonSelected();
    }
    void ActiveCannonSelected()
    {
        if (attackSelected > shootersShip.Length - 1)
        {
            attackSelected = 0;
        }
        DesactiveAllCannonSelected();
        CannonAttack[] cannonAttack = shootersShip[attackSelected].GetComponentsInChildren<CannonAttack>();
        foreach (CannonAttack cannon in cannonAttack)
        {
            cannon.ActiveThisCanno(true);
        }
    }
    void DesactiveAllCannonSelected()
    {
        foreach (GameObject target in shootersShip)
        {
            CannonAttack[] cannonAttack = target.GetComponentsInChildren<CannonAttack>();
            foreach (CannonAttack cannon in cannonAttack)
            {
                cannon.ActiveThisCanno(false);
            }
        }
    }
    public void ShooterAtack()
    {
        CannonAttack[] cannonAttack = shootersShip[attackSelected].GetComponentsInChildren<CannonAttack>();
        foreach (CannonAttack cannon in cannonAttack)
        {
            cannon.GetComponent<CannonAttack>().StartShootCannol();
        }
    }

}
