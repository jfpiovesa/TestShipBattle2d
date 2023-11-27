using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectedShip : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private ItemShipSelected prefab_itemShipSelected;


    public void SetupEnableMenuSlectedShio()
    {
        CreateListItemSeletedShip();
    }

    void CreateListItemSeletedShip()
    {

        foreach (Transform objects in content)
        {
            if (objects != null)
            {
                Destroy(objects.gameObject);
            }

        }

        foreach (ScriptObjectShipInfos ItemShip in GameManager.instaceGameManager.ManagerInfosPlayer.listScriptObjectShipInfos)
        {

            GameObject item = Instantiate(prefab_itemShipSelected.gameObject, content);
            item.GetComponent<ItemShipSelected>().SetUpInfoItem(ItemShip);
        }

    }

}
