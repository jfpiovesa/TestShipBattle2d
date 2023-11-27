using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDamageInShip : MonoBehaviour
{

    [SerializeField] private SpriteRenderer currentShipHull;
    [SerializeField] private SpriteRenderer currentShipLargeFlag;
    [SerializeField] private SpriteRenderer currentShipSailSmall;
    [SerializeField] private SpriteRenderer currentshipFlagSmallsTop;

    [Space(10)]
    [SerializeField] private Sprite[] shipHulls;
    [SerializeField] private Sprite[] shipLargeFlags;
    [SerializeField] private Sprite[] shipSailSmalls;
    [SerializeField] private Sprite deadShipFlagSmallsTop;

    [Space(10)]
    [SerializeField] private Color[] colorHealth;
    [SerializeField] private SpriteRenderer SprieteRendereCcolorHealth;

    private void Start()
    {
        SprieteRendereCcolorHealth.gameObject.SetActive(false);
    }
    public void LevelDamagenShipForChangeSprite(float damageLevelPercentage)
    {
        switch (damageLevelPercentage)
        {
            case >= 80:
                ChangeSprite(3);
                SprieteRendereCcolorHealth.color = colorHealth[3];

                break;
            case >= 50:
                ChangeSprite(2);
                SprieteRendereCcolorHealth.color = colorHealth[2];

                break;
            case >= 20:
                ChangeSprite(1);
                SprieteRendereCcolorHealth.color = colorHealth[1];
                break;
            case 0:
                ChangeSprite(0);
                SprieteRendereCcolorHealth.color = colorHealth[0];
                if (currentshipFlagSmallsTop.enabled || currentshipFlagSmallsTop.gameObject.activeInHierarchy)
                {
                    currentshipFlagSmallsTop.sprite = deadShipFlagSmallsTop;
                }
                break;
        }
        StopAllCoroutines();
        StartCoroutine(DisebleProgressBar(damageLevelPercentage));
    }
    IEnumerator DisebleProgressBar(float valuePercentage)
    {
        float timeSecond = 2f;
        SprieteRendereCcolorHealth.gameObject.SetActive(true);
        SprieteRendereCcolorHealth.gameObject.transform.localScale = Vector3.Lerp(SprieteRendereCcolorHealth.gameObject.transform.localScale, new Vector3(valuePercentage / 100f, SprieteRendereCcolorHealth.gameObject.transform.localScale.y, 0), 1f);
        yield return new WaitForSeconds(timeSecond);
        SprieteRendereCcolorHealth.gameObject.SetActive(false);
    }
    void ChangeSprite(int value)
    {
        if (currentShipHull.enabled || currentShipHull.gameObject.activeInHierarchy)
        {
            currentShipHull.sprite = shipHulls[value];
        }
        if (currentShipLargeFlag.enabled || currentShipLargeFlag.gameObject.activeInHierarchy)
        {
            currentShipLargeFlag.sprite = shipLargeFlags[value];
        }
        if (currentShipSailSmall.enabled || currentShipSailSmall.gameObject.activeInHierarchy)
        {
            currentShipSailSmall.sprite = shipSailSmalls[value];
        }
      
    }

}
