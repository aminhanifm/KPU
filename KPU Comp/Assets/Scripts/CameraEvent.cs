using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CameraEvent : MonoBehaviour
{
    private bool isfadingin = false;
    private bool isfadingout = false;
    public Image fader;
    public CanvasGroup CG;
    public RectTransform leaderboard;
    public CanvasGroup CGKembali;

    public void Start()
    {
        FadingOut();
        isfadingout = true;
    }

    public void Update()
    {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 50, 0.005f);
    }

    public void FixedUpdate()
    {
        if (fader.color.a == 0 && isfadingout)
        {
            buttonfadeIn();
            print("stillgoing");
            isfadingout = false;
        }
    }

    public void FadingIn(bool mulai)
    {
        fader.DOFade(1, 5);
        if (mulai)
        {
            StartCoroutine(bermain());
        }
    }

    public void FadingOut()
    {
        fader.DOFade(0, 5);
    }

    public void buttonfadeIn()
    {
        CG.DOFade(1, 1);
        CG.interactable = true;
    }

    public void buttonfadeOut()
    {
        CG.DOFade(0, 1);
        CG.interactable = false;
    }

    public void mulaipermainan()
    {
        playsoundbutton();
        buttonfadeOut();
        FadingIn(true);
    }

    public void skortertinggi()
    {
        playsoundbutton();
        buttonfadeOut();
        leaderboard.DOScale(new Vector3(6, 6, 6), 1);
        CGKembali.DOFade(1, 1);
        CGKembali.interactable = true;
    }

    public void keluarpermainan()
    {
        playsoundbutton();
        buttonfadeOut();
        FadingIn(false);
        Application.Quit();
    }

    public void kembali()
    {
        playsoundbutton();
        buttonfadeIn();
        leaderboard.DOScale(new Vector3(0, 0, 0), 1);
        CGKembali.DOFade(0, 1);
        CGKembali.interactable = false;
    }

    public void playsoundbutton()
    {
        SoundsManager.PlaySound("Button 3");
    }

    IEnumerator bermain()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

}
