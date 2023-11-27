using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] private string nameScene;
    public void LoadingScene()
    {
        GameManager  Gm =   FindAnyObjectByType<GameManager>();
        if(Gm != null)
        {
            Gm.ManagerLoading.LoadCene(nameScene);
        }
        else
        {
            Debug.Log("GameManager is null");
        }
    }
}
