using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyShip : CharacterAtackBase
{
    public EnemyShipType EnemyShipType = EnemyShipType.Shooter;

    public float raycastDistance = 1f; 
    public bool LeftPlayer = false;
    public bool righttPlayer = false;
    public bool frontPlayer = false;
    public bool obstacule = false;

    public DamageObject damageObjectContacteShipChaser;
    private void Start()
    {
        DesactiveAllCannonSelected();
    }

    private void Update()
    {

        if (EnemyShipType == EnemyShipType.Chaser) return;
        frontPlayer = CheckPlayerIfViewCannons(0);
        LeftPlayer = CheckPlayerIfViewCannons(1);
        righttPlayer = CheckPlayerIfViewCannons(2);
  
    }
    void DesactiveAllCannonSelected()
    {
        if (EnemyShipType == EnemyShipType.Chaser) return;

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
        if (EnemyShipType == EnemyShipType.Chaser) return;
        CannonAttack[] cannonAttack = shootersShip[attackSelected].GetComponentsInChildren<CannonAttack>();
        foreach (CannonAttack cannon in cannonAttack)
        {
            cannon.GetComponent<CannonAttack>().StartShootCannol();
        }
    }
    bool CheckPlayerIfViewCannons(int value)
    {

        bool check = false;

        Vector2 direction = (Vector2)shootersShip[value].transform.up;


        var hits = Physics2D.RaycastAll(shootersShip[value].transform.position, direction, raycastDistance);

        obstacule = false;
        check = false;

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag("Player"))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            if (!hits[i].collider.CompareTag("Player") || !hits[i].collider.CompareTag("Enemy") || !hits[i].collider.CompareTag("ColisionWallPlayer"))
            {
                obstacule = true;
            }
            else
            {

                obstacule = false;
            }
        }
        if (check)
        {
            Debug.DrawRay(shootersShip[value].transform.position, direction * raycastDistance, Color.green);
            attackSelected = value;         
        }
        else
        {
            Debug.DrawRay(shootersShip[value].transform.position, direction * raycastDistance, Color.red);

        }
        return check;
    }
}
