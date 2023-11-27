using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLoading : MonoBehaviour
{
    public AsyncOperation asyncOperation;

    [Header("Animator For Fade")]
    [Tooltip("Animator For Fade in scenes"), Space(5)]
    [SerializeField] private Animator animator;
    public void LoadCene(string nameScene)
    {
        StartCoroutine(RequetLoadScene(nameScene));
    }
    public void StartFad()
    {
        StartCoroutine(RequetFad());
    }
    IEnumerator RequetFad()
    {
        animator.SetTrigger("FadIn");
        float timeStady = animator.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(timeStady);
        animator.SetTrigger("FadOut");
    }
    IEnumerator RequetLoadScene(string nameScene)
    {

        animator.SetTrigger("FadIn");
        float timeStady = animator.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(timeStady);

        asyncOperation = SceneManager.LoadSceneAsync(nameScene);
        while (!asyncOperation.isDone)
        {
            yield return new WaitForSeconds(0.5f);
        }
        animator.SetTrigger("FadOut");
    }

}
