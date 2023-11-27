using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagerInfosPlayer : MonoBehaviour
{

    [Header("list ships")]
    public List<ScriptObjectShipInfos> listScriptObjectShipInfos;
    [Space(5)]
    [Header("Information geral  player")]
    public  GeneralPlayerInformation generalPlayerInformation;

    void Start()
    {
        GetListScrptObjectsShipInfos();
    }

      void GetListScrptObjectsShipInfos()
    {

        try
        {
            listScriptObjectShipInfos.Clear();
            ScriptObjectShipInfos[] _ships = Resources.LoadAll<ScriptObjectShipInfos>("Ships/");
            if (listScriptObjectShipInfos == null || listScriptObjectShipInfos.GetHashCode() != _ships.GetHashCode())
            {
                foreach (ScriptObjectShipInfos ShipPlaye in _ships)
                {
                    listScriptObjectShipInfos.Add(ShipPlaye);
                }
                listScriptObjectShipInfos = listScriptObjectShipInfos.OrderBy(x => x.IdShip).ToList();
            }
        }
        catch (Exception e)
        {
#if UNITY_EDITOR
            Debug.Log($" load the list of ships \n ERROR: {e} ");
#endif
        }

    }
}
