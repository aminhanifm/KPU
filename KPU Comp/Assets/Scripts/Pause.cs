using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Pause : MonoBehaviour
{
    public Image fader;
    public CanvasGroup CG;
    public Button pausedbtn;
    private bool ispaused = false;

    // Start is called before the first frame update
    void Start()
    {
        FadingOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kemenu()
    {
        FadingIn(true);
    }

    public void paused()
    {
        ispaused = !ispaused;

        if (ispaused)
        {
            playsoundbutton();
            pausedbtn.interactable = false;
            CG.interactable = true;
            CG.DOFade(1, 0.5f * Time.unscaledDeltaTime);
            fader.DOFade(0.5f, 0.5f * Time.unscaledDeltaTime);
            Time.timeScale = 0;
        }
        else
        {
            playsoundbutton();
            pausedbtn.interactable = true;
            CG.interactable = false;
            CG.DOFade(0, 0.5f * Time.unscaledDeltaTime);
            fader.DOFade(0, 0.5f * Time.unscaledDeltaTime);
            Time.timeScale = 1;
        }
    }

    public void FadingIn(bool menu)
    {
        fader.DOFade(1, 2.5f * Time.unscaledDeltaTime);
        if (menu)
        {
            StartCoroutine(keluar());
        }
    }

    public void FadingOut()
    {
        fader.DOFade(0, 2.5f);
    }

    IEnumerator keluar()
    {
        // return new WaitForSeconds(2.5f * Time.unscaledDeltaTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        yield return null;
    }

    public void playsoundbutton()
    {
        SoundsManager.PlaySound("Button 3");
    }
}
