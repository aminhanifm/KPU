using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DialogResult : MonoBehaviour
{
    public List<TMP_Text> texts;
    private CanvasGroup canvasGroup;

    private Color wrongColor = new Color(255, 0, 0);
    private Color rightColor = new Color(45, 0, 255);

    private void Start()
    {
        gameObject.SetActive(false);
        canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void setAllText()
    {
        gameObject.SetActive(true);
        foreach (var txt in texts)
        {
            int i = texts.IndexOf(txt);
            if (LevelHandler.GameStates.machineSelects[i] != LevelHandler.GameStates.playerSelects[i])
            {
                txt.color = wrongColor;
                txt.SetText("X");
            }
            else
            {
                txt.color = rightColor;
                txt.SetText("O");
            }
                
        }

        canvasGroup.DOFade(1, 0.5f);
    }

    public void CloseDialog()
    {
        StartCoroutine(closeDialogAnim());
    }

    private IEnumerator closeDialogAnim()
    {
        Tween tm = canvasGroup.DOFade(0, 0.5f);

        yield return tm.WaitForCompletion();

        CardEventHandler.current.DoneSelectCalon(-1);
    }
}
