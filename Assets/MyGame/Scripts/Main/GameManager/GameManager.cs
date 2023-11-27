using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instaceGameManager;

    [Header("Core Settings Components")]
    [Space(5)]
    [Tooltip("Manager scenes lodings and animations fade")]
    [SerializeField] private ManagerLoading _managerLoading;
    [Tooltip("Manager settings scenne in gameplay")]
    [SerializeField] private ManagerSceneInGamePlay _managerSceneInGame;
    [Tooltip("Manager settings player Infos")]
    [SerializeField] private ManagerInfosPlayer _managerInfosPlayer;

    public ManagerLoading ManagerLoading { get { return _managerLoading; } set { _managerLoading = value; } }
    public ManagerSceneInGamePlay ManagerSceneInGame { get { return _managerSceneInGame; } set { _managerSceneInGame = value; } }
    public ManagerInfosPlayer ManagerInfosPlayer { get { return _managerInfosPlayer; } set { _managerInfosPlayer = value; } }


    private void Awake()
    {
        if (instaceGameManager == null)
        {
            instaceGameManager = this;
        }
        else
        {
            Destroy(this.gameObject);

        }
        DontDestroyOnLoad(this.gameObject);
    }

}
