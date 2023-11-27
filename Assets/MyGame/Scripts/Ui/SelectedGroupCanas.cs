using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedGroupCanas : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] canvasGroups;

    public void ActiveCanvasGroup(CanvasGroup canvasGroup)
    {
        DesactiveAllCanvasGroup();

        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }
    public void DesactiveAllCanvasGroup()
    {
        if (canvasGroups == null) return;
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;

        }
    }
}
