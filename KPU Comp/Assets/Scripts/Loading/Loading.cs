using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Loading : MonoBehaviour
{
    private Image top;
    private Image bottom;

    public bool isLoading { get; set; }

    public static Loading Instance;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this);

        isLoading = false;
        top = this.transform.Find("top").GetComponent<Image>();
        bottom = this.transform.Find("bottom").GetComponent<Image>();
        top.rectTransform.localScale = new Vector3(1,0,1);
        bottom.rectTransform.localScale = new Vector3(1, 0, 1);
    }

    public void doLoading()
    {
        StartCoroutine(BarAnimated(1, true));
    }

    public void endLoading()
    {
        StartCoroutine(BarAnimated(0, false));
    }

    public void doCutScene()
    {
        StartCoroutine(BarAnimated(0.3f, true));
    }

    private IEnumerator BarAnimated(float factor, bool action)
    {
        float _duration = 0.4f;
        top.rectTransform.DOScaleY(factor, _duration).Play();
        bottom.rectTransform.DOScaleY(factor, _duration).Play();

        yield return new WaitForSeconds(_duration);
        isLoading = action;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 30, 50, 20), "Loading"))
        {
            if (!isLoading)
                doLoading();
            else
                endLoading();
        }

        if (GUI.Button(new Rect(70, 30, 50, 20), "Cut Scene"))
        {
            doCutScene();
        }
    }
}

