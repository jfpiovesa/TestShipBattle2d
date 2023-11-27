using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShipSelected : MonoBehaviour
{
    [SerializeField] private Image imageShip;
    [SerializeField] private Button btn_selectedShip;
    [SerializeField] private ScriptObjectShipInfos shipInfos;
    public void SetUpInfoItem(ScriptObjectShipInfos InfosShipSet)
    {
        shipInfos = InfosShipSet;

        SetInformationShip();
    }
    void SetInformationShip()
    {
        imageShip.sprite = shipInfos.imageShip;
        btn_selectedShip.onClick.RemoveAllListeners();
        btn_selectedShip.onClick.AddListener(() => SetSelecteId());
    }
    void SetSelecteId()
    {
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.ManagerInfosPlayer.generalPlayerInformation.IdSelectedShip = shipInfos.IdShip;
        }
        SceneLoading sceneLoading = FindAnyObjectByType<SceneLoading>();
        if (gameManager != null)
        {
            sceneLoading.LoadingScene();
        }
    }
}