using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class HealthShip : HealthBase
{

    [SerializeField] private LevelDamageInShip levelDamageInShip;

    private void Start()
    {
        levelDamageInShip = GetComponent<LevelDamageInShip>();   
        currenthealth = maxHealth;
        ChangerSprite();
    }
    public override void SubtractDamage( int amountDamage)
    {
        currenthealth = Mathf.Clamp(currenthealth - amountDamage, minHealth,maxHealth);
        ChangerSprite();
        if(currenthealth == 0)
        {
            if (!isDead)
            {
                isDead = true;
                Instantiate(particliIsDead, this.transform.position, Quaternion.identity);
                FindAnyObjectByType<ManagerSceneGamePlay>().FinishSetValueRequest();     
                StartCoroutine(RequesDalyPainelActive());
             
            }    
        }
    }

    IEnumerator RequesDalyPainelActive()
    {
        yield return new WaitForSeconds(2);
        FindAnyObjectByType<ManagerSceneGamePlay>().FinishEventRequest();
    }

    
    public override void AddHealth(int amountHealth)
    {
        currenthealth = Mathf.Clamp(currenthealth + amountHealth, minHealth, maxHealth);
        ChangerSprite();
    }
    void ChangerSprite()
    {      
        float porcentagem = ((float)currenthealth / (float)maxHealth) * 100f;
        levelDamageInShip.LevelDamagenShipForChangeSprite(porcentagem);
    }

}

