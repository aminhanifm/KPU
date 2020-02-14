using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class CoblosContainer : MonoBehaviour
{
    public GameObject selected { get; set; }
    public Vector2 newPos { get; set; }
    private GameObject alat;
    private GameObject lubang;
    private Image Kertas;

    private List<Sprite> spritesKertas;

    AnimatorClipInfo[] _CurrentClipInfo;

    public Components components;

    private void Awake()
    {
        alat = components.alat;
        lubang = components.lubang;
        spritesKertas = components.spritesKertas;
        Kertas = components.Kertas;

        CardEventHandler.current.onSelectCard += InitKertas;
        CardEventHandler.current.onDoneSelectCard += showKertas;
    }

    private void InitKertas(int id)
    {
        Kertas.sprite = spritesKertas[id];
        lubang.SetActive(false);
    }

    private void showKertas()
    {
        Kertas.gameObject.SetActive(true);
        Kertas.GetComponent<CanvasGroup>().alpha = 0;
        Kertas.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
    }

    private void hideKertas()
    {
        Kertas.GetComponent<CanvasGroup>().DOFade(0, 0.4f);
        Kertas.gameObject.SetActive(false);
    }

    public void onNyoblos(int idCalon)
    {
        StartCoroutine(PlayNyoblos(idCalon));
    }

    IEnumerator PlayNyoblos(int idCalon)
    {
        Vector3 temp = alat.transform.localPosition;
        Vector3 to = alat.transform.localPosition + new Vector3(100f, 100f);
        alat.transform.DOLocalMove(to, 0.3f);

        yield return new WaitForSeconds(0.3f);

        alat.transform.DOLocalMove(temp, 0.3f);
        yield return new WaitForSeconds(0.2f);

        lubang.SetActive(true);
        lubang.transform.position = newPos;
        yield return new WaitForSeconds(0.3f);

        hideKertas();

        yield return new WaitForSeconds(0.4f);
        CardEventHandler.current.DoneSelectCalon(idCalon);
    }

    [Serializable]
    public class Components
    {
        public GameObject alat;
        public GameObject lubang;
        public Image Kertas;
        public List<Sprite> spritesKertas;
    }
}
