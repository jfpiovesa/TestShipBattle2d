using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Cinemachine;

public class ManagerSceneGamePlay : MonoBehaviour
{

    SettingGamePlayInScene settingGamePlayInScene;
    [SerializeField] private ManagerSpawnEnemyInGamePlayScene managerSpawnEnemyInGamePlayScene;

    [Header(" Seesion Settings ")]
    [SerializeField] bool canStartSession = false;
    [SerializeField] float timeSeesion = 1;

    [Header("Time Session text  ")]
    [SerializeField] private TMP_Text textTimeSeesion;
    [Header(" Scoore text")]
    [SerializeField] private TMP_Text textPoints;
    [Header(" Point and Game text")]
    [SerializeField] private TMP_Text textPointAndGame;

    [Space(5)]
    [SerializeField] private int scooreInSession = 0;

    [Header("Finish Session "), Space(5)]
    public UnityEvent eventFinishGameSession;

    [Header("Character"), Space(5)]
    [SerializeField] private CharacterBase isPlayer;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;




    private void Awake()
    {
        StaicAddedPointsWhenDestroyingAShip.addPoint += AddPointInScoore;
        StaticSetPlayer.actionCharacter += SetPlayer;
    }
    private void Start()
    {
        settingGamePlayInScene = GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene;
        timeSeesion = settingGamePlayInScene.gameSessionTime;
        textPoints.text = scooreInSession.ToString();
        textPointAndGame.text = scooreInSession.ToString();

    }

    private void Update()
    {

        if (canStartSession)
        {
            StartSessionUpdateTime();

        }

    }
    public void StartSession()
    {
        canStartSession = true;
        managerSpawnEnemyInGamePlayScene.StartSpawnEnemys();
    }
    void StartSessionUpdateTime()
    {

        timeSeesion -= Time.deltaTime;

        System.TimeSpan tempoFormatado = System.TimeSpan.FromSeconds((double)timeSeesion);

        int minutos = tempoFormatado.Minutes;
        int segundos = tempoFormatado.Seconds;

        textTimeSeesion.text = string.Format("{0:D2}:{1:D2}", minutos, segundos);

        if (timeSeesion <= 10f)
        {
            textTimeSeesion.color = Color.red;
        }
        else
        {
            textTimeSeesion.color = Color.white;
        }
        if (timeSeesion <= 0)
        {
            FinishSessionGame();
        }
    }

    public void FinishSessionGame()
    {
        FinishSetValueRequest();
        FinishEventRequest();

    }
    public void FinishSetValueRequest()
    {
        timeSeesion = 0;
        isPlayer.canMoveShip = false;
        canStartSession = false;
        managerSpawnEnemyInGamePlayScene.StopSpawnEnemy();
    }
    public void FinishEventRequest()
    {
        eventFinishGameSession.Invoke();
    }
    void AddPointInScoore(int addValue)
    {
        scooreInSession += addValue;
        textPoints.text = scooreInSession.ToString();
        textPointAndGame.text = scooreInSession.ToString();
    }
    void SetPlayer(CharacterBase character)
    {

        isPlayer = character;
        managerSpawnEnemyInGamePlayScene.isPlayer = isPlayer.transform;
        virtualCamera.Follow = isPlayer.transform;
        virtualCamera.LookAt = isPlayer.transform;
    }
}
