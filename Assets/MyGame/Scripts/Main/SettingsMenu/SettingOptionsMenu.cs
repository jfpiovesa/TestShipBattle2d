using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingOptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider slider_sessionTime;
    [SerializeField] private Slider slider_spawnTimeEnemy;
    [SerializeField] private TMP_Text text_sessionTime;
    [SerializeField] private TMP_Text text_spawnTimeEnemy;


    private void Start()
    {
        GetValuesSavePlayerPrefs();
    }
    public void SetupSettingOptionsMenu()
    {
        SetValueSettingsOptionsMenu();
    }

    void SetValueSettingsOptionsMenu()
    {
        slider_sessionTime.minValue = 60;
        slider_sessionTime.maxValue = 180;
        slider_spawnTimeEnemy.minValue = 0.1f;
        slider_spawnTimeEnemy.maxValue = 30f;

        slider_sessionTime.onValueChanged.RemoveAllListeners();
        slider_spawnTimeEnemy.onValueChanged.RemoveAllListeners();

        slider_sessionTime.onValueChanged.AddListener(SlideValueSessionTime);
        slider_spawnTimeEnemy.onValueChanged.AddListener(SlideSpawnTimeEnemy);

        slider_sessionTime.value = GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.gameSessionTime;
        slider_spawnTimeEnemy.value = GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.enemyAppearanceTime;
    }
    void SlideValueSessionTime(float valueSlide)
    {
        GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.gameSessionTime = valueSlide;
        PlayerPrefs.SetFloat("SessionTime", valueSlide);
        text_sessionTime.text = valueSlide.ToString("F0");
    }
    void SlideSpawnTimeEnemy(float valueSlide)
    {
        GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.enemyAppearanceTime = valueSlide;
        PlayerPrefs.SetFloat("SpawnTimeEnemy", valueSlide);
        text_spawnTimeEnemy.text = valueSlide.ToString("F0");
    }
    void GetValuesSavePlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("SessionTime"))
        {
            GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.gameSessionTime = 60;
            text_sessionTime.text = "60";
        }
        else
        {
            GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.gameSessionTime = PlayerPrefs.GetFloat("SessionTime");
            slider_sessionTime.value = GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.gameSessionTime;
            text_sessionTime.text = GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.gameSessionTime.ToString("F0");

        }

        if (!PlayerPrefs.HasKey("SpawnTimeEnemy"))
        {
            GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.enemyAppearanceTime = 10;
            text_spawnTimeEnemy.text = "10";
        }
        else
        {
            GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.enemyAppearanceTime = PlayerPrefs.GetFloat("SpawnTimeEnemy");
            slider_spawnTimeEnemy.value = GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.enemyAppearanceTime;
            text_spawnTimeEnemy.text = GameManager.instaceGameManager.ManagerSceneInGame.settingGamePlayInScene.enemyAppearanceTime.ToString("F0");
        }
    }
}

