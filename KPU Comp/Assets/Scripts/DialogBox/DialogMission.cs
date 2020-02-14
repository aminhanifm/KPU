using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DialogMission : MonoBehaviour
{
    public List<TMP_Text> texts;
    private CanvasGroup canvasGroup;

    public void init()
    {
        gameObject.SetActive(false);
        canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void setAllText()
    {
        gameObject.SetActive(true);
        foreach(var txt in texts)
        {
            int idx = texts.IndexOf(txt);
            int num = LevelHandler.GameStates.machineSelects[idx];

            if (idx == 2) {
                txt.SetText(LevelHandler.GameStates.DPR[num]);
            }
            else if (idx == 3)
            {
                txt.SetText(LevelHandler.GameStates.DPRD_Jatim[num]);
            }
            else if (idx == 4)
            {
                txt.SetText(LevelHandler.GameStates.DPRD_Surabaya[num]);
            }
            else
            {
                //buat presiden & DPD
                txt.SetText((num + 1).ToString());
            }
        }

        canvasGroup.DOFade(1, 0.5f);
    }

    public void CloseDialog()
    {
        StartCoroutine(CloseDialogAnim());
    }

    private IEnumerator CloseDialogAnim()
    {
        Tween tween = canvasGroup.DOFade(0, 0.5f);
        yield return tween.WaitForCompletion();

        gameObject.SetActive(false);
        LevelHandler.GameStates.moveAllowed = true;
    }
}
