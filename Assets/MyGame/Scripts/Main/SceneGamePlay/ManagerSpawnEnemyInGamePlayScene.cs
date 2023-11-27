using UnityEngine;
using System.Collections;


public class ManagerSpawnEnemyInGamePlayScene : MonoBehaviour
{

    SettingGamePlayInScene settingGamePlayInScene;

    [Header("Enemys Prefabs"), Space(5)]
    [SerializeField] private EnemyShip preFab_EnemyShotter;
    [SerializeField] private EnemyShip preFab_EnemyChase;

    [Header("Spawn Ponts List"), Space(5)]
    [SerializeField] private Transform[] poinsSpawnEnemys;

    [Header("Patrols Points List"), Space(5)]
    [SerializeField] private Transform[] poinsPatrol;

    [Header("Settings Enemy Spawn"), Space(5)]
    [SerializeField] private float enemyAppearanceTime = 0;
    [SerializeField] private bool canSpawEnemy = false;
    [SerializeField] private int spawmShootingShipQuantityForSpawnChaseShip = 3;

    int checkSpawmShootingShipQuantityForSpawnChaseShip = 0;
    [SerializeField] public Transform isPlayer;
    private void Start()
    {
        settingGamePlayInScene = GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene;
        enemyAppearanceTime = settingGamePlayInScene.enemyAppearanceTime;

    }
    public void StartSpawnEnemys()
    {
        canSpawEnemy = true;
        checkSpawmShootingShipQuantityForSpawnChaseShip = spawmShootingShipQuantityForSpawnChaseShip;
        StartCoroutine(SpawnEnemysRequest());
    }
    public void StopSpawnEnemy()
    {
        StopAllCoroutines();
        canSpawEnemy = false;
        EnemyShip[] allEnemysInScene = FindObjectsOfType<EnemyShip>();
        foreach(EnemyShip enemyShip in allEnemysInScene)
        {
            enemyShip.canMoveShip = false;
        }
    }
    IEnumerator SpawnEnemysRequest()
    {
        yield return new WaitForSeconds(enemyAppearanceTime);
        if(canSpawEnemy)
        {
            LogictSpawnEnemys();
        }
        StartCoroutine(SpawnEnemysRequest());
    }

    void LogictSpawnEnemys()
    {

        checkSpawmShootingShipQuantityForSpawnChaseShip--;
        if (checkSpawmShootingShipQuantityForSpawnChaseShip <= 0)
        {
            checkSpawmShootingShipQuantityForSpawnChaseShip = spawmShootingShipQuantityForSpawnChaseShip;

            int valueRadom = Random.Range(0, poinsSpawnEnemys.Length);
            GameObject ShipEnemy = Instantiate(preFab_EnemyChase.gameObject,poinsSpawnEnemys[valueRadom].position,Quaternion.identity);
            ShipEnemy.GetComponent<EnemyShip>().SetupInfoEnemys(poinsPatrol, isPlayer);
        }
        else
        {

            int valueRadom = Random.Range(0, poinsSpawnEnemys.Length);
            GameObject ShipEnemy = Instantiate(preFab_EnemyShotter.gameObject, poinsSpawnEnemys[valueRadom].position, Quaternion.identity);
            ShipEnemy.GetComponent<EnemyShip>().SetupInfoEnemys(poinsPatrol,isPlayer);
        }
    }
}
