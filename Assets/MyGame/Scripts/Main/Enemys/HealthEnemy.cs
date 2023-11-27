using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : HealthBase
{

    [SerializeField] private LevelDamageInShip levelDamageInShip;

    private void Start()
    {
        levelDamageInShip = GetComponent<LevelDamageInShip>();
        currenthealth = maxHealth;
        ChangerSprite();
    }
    public override void SubtractDamage(int amountDamage)
    {
        currenthealth = Mathf.Clamp(currenthealth - amountDamage, minHealth, maxHealth);
        ChangerSprite();
        if (currenthealth == 0)
        {
            if (!isDead)
            {
                isDead = true;
                StaicAddedPointsWhenDestroyingAShip.AddPoint(1); 
            }
            DestoyThisGameObject(0);
        }
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

    void DestoyThisGameObject(float timeDalay)
    {
        Destroy(this.gameObject, timeDalay);
    }
}
