using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerObject : MonoBehaviour
{
    [SerializeField] private Transform[] poinsSpawnPlayer;
    public void SpawnPlayer()
    {
        int valueRadom = Random.Range(0, poinsSpawnPlayer.Length);
        int id = GameManager.instaceGameManager.ManagerInfosPlayer.generalPlayerInformation.IdSelectedShip;
        GameObject prefab = GameManager.instaceGameManager.ManagerInfosPlayer.listScriptObjectShipInfos.Find(x => x.IdShip.Equals(id)).prefabShip;
        Instantiate(prefab,poinsSpawnPlayer[valueRadom].position,Quaternion.identity);

    }
}
